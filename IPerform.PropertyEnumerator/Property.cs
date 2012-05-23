using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IPerform.PropertyEnumerator
{
    public class Property<TPropertyType>
    {
        public Property(object instance, PropertyInfo propertyInfo)
        {
            Instance = instance;
            PropertyInfo = propertyInfo;
        }

        // TODO: at some point, place a proxy class in between for property access to speed things up a bit.
        public TPropertyType Value 
        {
            get
            {
                return (TPropertyType)PropertyInfo.GetValue(Instance, null);
            }

            set
            {
                PropertyInfo.SetValue(Instance, value, null);
            }
        }

        public IEnumerable<TAttribute> GetAttribute<TAttribute>(bool inherit = false)
        {
            var attributes = PropertyInfo.GetCustomAttributes(typeof(TAttribute), inherit);

            if (attributes != null)
            {
                return attributes.Cast<TAttribute>();
            }
            else
            {
                return Enumerable.Empty<TAttribute>();
            }
        }

        public PropertyInfo PropertyInfo { get; private set; }
        public object Instance { get; private set; }
    }
}
