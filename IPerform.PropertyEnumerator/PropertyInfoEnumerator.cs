using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace IPerform.PropertyEnumerator
{
    public class PropertyInfoEnumerator<TPropertyType> : IEnumerable<PropertyInfo>
    {
        readonly object _instance;
        readonly string _regexp;

        public object Instance { get { return _instance; } }

        public PropertyInfoEnumerator(object enumeratedObject, string regexp)
        {
            this._instance = enumeratedObject;
            this._regexp = regexp;
        }

        public IEnumerator<PropertyInfo> GetEnumerator()
        {
            Type type = _instance.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (typeof(TPropertyType).IsAssignableFrom(property.PropertyType) && Regex.IsMatch(property.Name, _regexp))
                {
                    yield return property;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class PropertyInfoEnumerator : PropertyInfoEnumerator<object>
    {
        public PropertyInfoEnumerator(object enumeratedObject, string regexp)
            : base (enumeratedObject, regexp)
        { }
    }
}
