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

        public PropertyInfo PropertyInfo { get; private set; }
        public object Instance { get; private set; }
    }
}
