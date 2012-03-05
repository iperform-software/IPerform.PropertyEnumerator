using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IPerform.PropertyEnumerator
{
    // FIXME remove this whole thing, replace with PropertyEnumerator.
    public static class PropertyIterator
    {
        public static void ForEach<TPropType>(object o, Action<TPropType> action)
        {
            ForEach(new PropertyEnumerator<TPropType>(o, "."), o, (p, v, o_) => action(v));
        }

        public static void ForEach<TPropType>(object o, Action<PropertyInfo, TPropType, object> action)
        {
            ForEach(new PropertyEnumerator<TPropType>(o, "."), o, action);
        }

        public static void ForEach<TPropType>(object o, string regexp, Action<TPropType> action)
        {
            ForEach(new PropertyEnumerator<TPropType>(o, regexp), o, (p, v, o_) => action(v));
        }

        public static void ForEach<TPropType>(object o, string regexp, Action<PropertyInfo, TPropType, object> action)
        {
            ForEach(new PropertyEnumerator<TPropType>(o, regexp), o, action);
        }

        public static void ForEach<TPropType>(PropertyEnumerator<TPropType> propEnumerator, object o, Action<PropertyInfo, TPropType, object> action)
        {
            foreach (var p in propEnumerator)
            {
                if (action != null)
                {
                    action(p.PropertyInfo, p.Value, p.Instance);
                }
            }
        }
    }
}