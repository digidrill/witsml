﻿//----------------------------------------------------------------------- 
// PDS.Witsml, 2016.1
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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using Energistics.DataAccess;
using log4net;
using PDS.Framework;

namespace PDS.Witsml.Data
{
    public abstract class DataObjectNavigator<TContext> where TContext : DataObjectNavigationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataObjectNavigator{TContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected DataObjectNavigator(TContext context)
        {
            Logger = LogManager.GetLogger(GetType());
            Context = context;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        protected TContext Context { get; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        protected ILog Logger { get; private set; }

        /// <summary>
        /// Determines whether the specified element name is ignored.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns></returns>
        protected virtual bool IsIgnored(string elementName)
        {
            return Context.Ignored != null && Context.Ignored.Contains(elementName);
        }

        /// <summary>
        /// Navigates the specified element.
        /// </summary>
        /// <param name="element">The XML element.</param>
        protected void Navigate(XElement element)
        {
            NavigateElement(element, Context.DataObjectType);
        }

        protected void NavigateElement(XElement element, Type type, string parentPath = null)
        {
            if (IsIgnored(element.Name.LocalName)) return;

            var properties = GetPropertyInfo(type);
            var groupings = element.Elements().GroupBy(e => e.Name.LocalName);

            foreach (var group in groupings)
            {
                if (IsIgnored(group.Key)) continue;

                var propertyInfo = GetPropertyInfoForAnElement(properties, group.Key);
                NavigateElementGroup(propertyInfo, group, parentPath);
            }

            foreach (var attribute in element.Attributes())
            {
                if (attribute.IsNamespaceDeclaration || attribute.Name == Xsi("nil") || attribute.Name == Xsi("type"))
                    continue;

                var attributeProp = GetPropertyInfoForAnElement(properties, attribute.Name.LocalName);
                NavigateAttribute(attributeProp, attribute, parentPath);
            }
        }

        protected void NavigateElementGroup(PropertyInfo propertyInfo, IGrouping<string, XElement> elements, string parentPath)
        {
            if (propertyInfo == null) return;

            var fieldName = GetPropertyPath(parentPath, propertyInfo.Name);
            var propType = propertyInfo.PropertyType;
            var values = elements.ToList();
            var count = values.Count;

            if (count == 1)
            {
                var element = values.FirstOrDefault();

                if (propType.IsGenericType)
                {
                    var genericType = propType.GetGenericTypeDefinition();

                    if (genericType == typeof(Nullable<>))
                    {
                        var underlyingType = Nullable.GetUnderlyingType(propType);
                        NavigateElementType(underlyingType, element, fieldName);
                    }
                    else if (genericType == typeof(List<>))
                    {
                        var childType = propType.GetGenericArguments()[0];
                        NavigateElementType(childType, element, fieldName);
                    }
                }
                else if (propType.IsAbstract)
                {
                    var concreteType = GetConcreteType(element, propType);
                    NavigateElementType(concreteType, element, fieldName);
                }
                else
                {
                    NavigateElementType(propType, element, fieldName);
                }
            }
            else
            {
                var childType = propType.GetGenericArguments()[0];

                foreach (var value in values)
                {
                    NavigateElementType(childType, value, fieldName);
                }
            }
        }

        protected void NavigateElementType(Type elementType, XElement element, string propertyPath)
        {
            var textProperty = elementType.GetProperties().FirstOrDefault(x => x.IsDefined(typeof(XmlTextAttribute), false));

            if (textProperty != null)
            {
                var uomProperty = elementType.GetProperty("Uom");
                var fieldName = GetPropertyPath(propertyPath, textProperty.Name);
                var fieldType = textProperty.PropertyType;

                if (uomProperty != null)
                {
                    var uomPath = GetPropertyPath(propertyPath, uomProperty.Name);
                    var uomValue = ValidateMeasureUom(element, uomProperty, element.Value);

                    NavigateProperty(uomProperty.PropertyType, uomPath, uomValue);
                }

                NavigateProperty(fieldType, fieldName, element.Value);
            }
            else if (element.HasElements || element.HasAttributes)
            {
                NavigateElement(element, elementType, propertyPath);
            }
            else
            {
                NavigateProperty(elementType, propertyPath, element.Value);
            }
        }

        protected void NavigateAttribute(PropertyInfo propertyInfo, XAttribute attribute, string parentPath = null)
        {
            var propertyPath = GetPropertyPath(parentPath, propertyInfo.Name);
            var propertyType = propertyInfo.PropertyType;

            NavigateProperty(propertyType, propertyPath, attribute.Value);
        }

        protected void NavigateProperty(Type propertyType, string propertyPath, string propertyValue)
        {
            if (string.IsNullOrWhiteSpace(propertyValue))
            {
                HandleNullValue(propertyType, propertyPath, propertyValue);
            }
            else if (propertyType == typeof(string))
            {
                HandleStringValue(propertyType, propertyPath, propertyValue);
            }
            else if (propertyType.IsEnum)
            {
                var value = ParseEnum(propertyType, propertyValue);
                HandleObjectValue(propertyType, propertyPath, propertyValue, value);
            }
            else if (propertyType == typeof(DateTime))
            {
                DateTime value;

                if (!DateTime.TryParse(propertyValue, out value))
                    throw new WitsmlException(ErrorCodes.InputTemplateNonConforming);

                HandleDateTimeValue(propertyType, propertyPath, propertyValue, value);
            }
            else if (propertyType == typeof(Timestamp))
            {
                DateTimeOffset value;

                if (!DateTimeOffset.TryParse(propertyValue, out value))
                    throw new WitsmlException(ErrorCodes.InputTemplateNonConforming);

                HandleTimestampValue(propertyType, propertyPath, propertyValue, new Timestamp(value));
            }
            else if (propertyValue.Equals("NaN") && propertyType.IsNumeric())
            {
                HandleNaNValue(propertyType, propertyPath, propertyValue);
            }
            else if (typeof(IConvertible).IsAssignableFrom(propertyType))
            {
                var value = Convert.ChangeType(propertyValue, propertyType);
                HandleObjectValue(propertyType, propertyPath, propertyValue, value);
            }
            else
            {
                HandleStringValue(propertyType, propertyPath, propertyValue);
            }
        }

        protected virtual void HandleStringValue(Type propertyType, string propertyPath, string propertyValue)
        {
        }

        protected virtual void HandleDateTimeValue(Type propertyType, string propertyPath, string propertyValue, DateTime dateTimeValue)
        {
        }

        protected virtual void HandleTimestampValue(Type propertyType, string propertyPath, string propertyValue, Timestamp timestampValue)
        {
        }

        protected virtual void HandleObjectValue(Type propertyType, string propertyPath, string propertyValue, object objectValue)
        {
        }

        protected virtual void HandleNaNValue(Type propertyType, string propertyPath, string propertyValue)
        {
        }

        protected virtual void HandleNullValue(Type propertyType, string propertyPath, string propertyValue)
        {
        }

        /// <summary>
        /// Gets the property information for an element.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="name">The name of the property.</param>
        /// <returns>The property info for the element.</returns>
        protected PropertyInfo GetPropertyInfoForAnElement(IEnumerable<PropertyInfo> properties, string name)
        {
            foreach (var prop in properties)
            {
                var elementAttribute = prop.GetCustomAttribute<XmlElementAttribute>();
                if (elementAttribute != null)
                {
                    if (elementAttribute.ElementName.EqualsIgnoreCase(name))
                        return prop;
                }

                var arrayAttribute = prop.GetCustomAttribute<XmlArrayAttribute>();
                if (arrayAttribute != null)
                {
                    if (arrayAttribute.ElementName.EqualsIgnoreCase(name))
                        return prop;
                }

                var attributeAttribute = prop.GetCustomAttribute<XmlAttributeAttribute>();
                if (attributeAttribute != null)
                {
                    if (attributeAttribute.AttributeName.EqualsIgnoreCase(name))
                        return prop;
                }
            }
            return null;
        }

        /// <summary>
        /// Validates the uom/value pair for the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="uomProperty">The uom property.</param>
        /// <param name="measureValue">The measure value.</param>
        /// <returns>The uom value if valid.</returns>
        /// <exception cref="WitsmlException"></exception>
        protected string ValidateMeasureUom(XElement element, PropertyInfo uomProperty, string measureValue)
        {
            var xmlAttribute = uomProperty.GetCustomAttribute<XmlAttributeAttribute>();

            // validation not needed if uom attribute is not defined
            if (xmlAttribute == null)
                return null;

            var uomValue = element.Attributes()
                .Where(x => x.Name.LocalName == xmlAttribute.AttributeName)
                .Select(x => x.Value)
                .FirstOrDefault();

            // uom is required when a measure value is specified
            if (!string.IsNullOrWhiteSpace(measureValue) && string.IsNullOrWhiteSpace(uomValue))
            {
                throw new WitsmlException(ErrorCodes.MissingUnitForMeasureData);
            }

            return uomValue;
        }

        /// <summary>
        /// Gets the concrete type of the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="propType">Type of the property.</param>
        /// <returns>The concrete type</returns>
        protected Type GetConcreteType(XElement element, Type propType)
        {
            var xsiType = element.Attributes()
                .Where(x => x.Name == Xsi("type"))
                .Select(x => x.Value.Split(':'))
                .FirstOrDefault();

            var @namespace = element.Attributes()
                .Where(x => x.Name == Xmlns(xsiType.FirstOrDefault()))
                .Select(x => x.Value)
                .FirstOrDefault();

            var typeName = xsiType.LastOrDefault();

            return propType.Assembly.GetTypes()
                .FirstOrDefault(t =>
                {
                    var xmlType = t.GetCustomAttribute<XmlTypeAttribute>();
                    return ((xmlType != null && xmlType.TypeName == typeName) &&
                        (string.IsNullOrWhiteSpace(@namespace) || xmlType.Namespace == @namespace));
                });
        }

        protected object ParseEnum(Type enumType, string enumValue)
        {
            if (Enum.IsDefined(enumType, enumValue))
            {
                return Enum.Parse(enumType, enumValue);
            }

            var enumMember = enumType.GetMembers().FirstOrDefault(x =>
            {
                if (x.Name.EqualsIgnoreCase(enumValue))
                    return true;

                var xmlEnumAttrib = x.GetCustomAttribute<XmlEnumAttribute>();
                return xmlEnumAttrib != null && xmlEnumAttrib.Name.EqualsIgnoreCase(enumValue);
            });

            // must be a valid enumeration member
            if (!enumType.IsEnum || enumMember == null)
            {
                throw new WitsmlException(ErrorCodes.InvalidUnitOfMeasure);
            }

            return Enum.Parse(enumType, enumMember.Name);
        }

        protected IList<PropertyInfo> GetPropertyInfo(Type t)
        {
            return t.GetProperties()
                .Where(p => !p.IsDefined(typeof(XmlIgnoreAttribute), false))
                .ToList();
        }

        /// <summary>
        /// Gets the Mongo collection field path for the property.
        /// </summary>
        /// <param name="parentPath">The parent path.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The Mongo collection field path for the property.</returns>
        protected string GetPropertyPath(string parentPath, string propertyName)
        {
            var prefix = string.IsNullOrEmpty(parentPath) ? string.Empty : string.Format("{0}.", parentPath);
            return string.Format("{0}{1}", prefix, propertyName.ToPascalCase());
        }

        protected XName Xmlns(string attributeName)
        {
            return XNamespace.Xmlns.GetName(attributeName);
        }

        protected XName Xsi(string attributeName)
        {
            return WitsmlParser.Xsi.GetName(attributeName);
        }
    }
}