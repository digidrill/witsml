﻿//----------------------------------------------------------------------- 
// PDS.Witsml.Server, 2016.1
//
// Copyright 2016 Petrotechnical Data Systems
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Energistics.DataAccess;
using log4net;
using Witsml131 = Energistics.DataAccess.WITSML131;
using Witsml141 = Energistics.DataAccess.WITSML141;

namespace PDS.Witsml.Server.Data
{
    public class WitsmlQueryTemplate<T>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(WitsmlQueryTemplate<T>));
        private static readonly IList<Type> ExcludeTypes = new List<Type>();
        private static readonly DateTime DefaultDateTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly DateTimeOffset DefaultDateTimeOffset = DateTimeOffset.MinValue.AddYears(1899);
        private T _instance;

        static WitsmlQueryTemplate()
        {
            Exclude<Witsml131.ComponentSchemas.CustomData>();
            Exclude<Witsml131.ComponentSchemas.DocumentInfo>();

            Exclude<Witsml141.ComponentSchemas.CustomData>();
            Exclude<Witsml141.ComponentSchemas.DocumentInfo>();
            Exclude<Witsml141.ComponentSchemas.ExtensionAny>();
            Exclude<Witsml141.ComponentSchemas.ExtensionNameValue>();
        }

        public WitsmlQueryTemplate()
        {
        }

        public WitsmlQueryTemplate(T instance)
        {
            _instance = instance;
        }

        private static void Exclude<V>()
        {
            ExcludeTypes.Add(typeof(V));
        }

        public T AsObject()
        {
            if (_instance == null)
                _instance = (T)CreateTemplate(typeof(T));

            return _instance;
        }

        public List<T> AsList()
        {
            return new List<T>() { AsObject() };
        }

        public string AsXml()
        {
            return ToXml(AsObject());
        }

        public string AsXml<TList>() where TList : IEnergisticsCollection
        {
            var list = CreateTemplate(typeof(TList));
            return ToXml(list);
        }

        protected object CreateTemplate(Type objectType)
        {
            if (objectType == null || ExcludeTypes.Contains(objectType))
            {
                return null;
            }
            if (objectType == typeof(string))
            {
                return "abc";
            }
            if (objectType == typeof(bool))
            {
                return false;
            }
            if (objectType == typeof(short) || objectType == typeof(int) || objectType == typeof(long) || 
                objectType == typeof(double) || objectType == typeof(float) || objectType == typeof(decimal))
            {
                return Convert.ChangeType(1, objectType);
            }
            if (objectType == typeof(DateTime))
            {
                return DefaultDateTime;
            }
            if (objectType == typeof(DateTimeOffset))
            {
                return DefaultDateTimeOffset;
            }
            if (objectType == typeof(Timestamp))
            {
                return new Timestamp(DefaultDateTimeOffset);
            }
            if (objectType.IsEnum)
            {
                return Enum.GetValues(objectType).GetValue(0);
            }
            if (objectType.IsGenericType)
            {
                var genericType = objectType.GetGenericTypeDefinition();

                if (genericType == typeof(Nullable<>))
                {
                    return Activator.CreateInstance(objectType, CreateTemplate(Nullable.GetUnderlyingType(objectType)));
                }
                if (genericType == typeof(List<>))
                {
                    var childType = objectType.GetGenericArguments()[0];
                    var list = Activator.CreateInstance(objectType) as IList;
                    list.Add(CreateTemplate(childType));
                    return list;
                }
            }
            if (objectType.IsAbstract)
            {
                var concreteType = objectType.Assembly.GetTypes()
                    .Where(x => !x.IsAbstract && objectType.IsAssignableFrom(x))
                    .FirstOrDefault();

                return CreateTemplate(concreteType);
            }

            var dataObject = Activator.CreateInstance(objectType);

            foreach (var property in objectType.GetProperties())
            {
                try
                {
                    if (property.CanWrite && !IsIgnored(property))
                    {
                        if (property.PropertyType == typeof(string) && property.IsDefined(typeof(RegularExpressionAttribute)))
                        {
                            var attribute = property.GetCustomAttribute<RegularExpressionAttribute>();
                            var xeger = new Fare.Xeger(attribute.Pattern);
                            property.SetValue(dataObject, xeger.Generate());
                            continue;
                        }

                        property.SetValue(dataObject, CreateTemplate(property.PropertyType));
                    }
                }
                catch
                {
                    Console.WriteLine("Error setting property value. Type: {0}; Property: {1}", objectType.FullName, property.Name);
                }
            }

            return dataObject;
        }

        private bool IsIgnored(PropertyInfo property)
        {
            return property.GetCustomAttributes<XmlIgnoreAttribute>().Any();
        }

        private string ToXml(object instance)
        {
            return WitsmlParser.ToXml(instance);
        }
    }
}
