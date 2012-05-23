using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPerform.PropertyEnumerator
{
    public class PropertyEnumerator<TPropertyType> : IEnumerable<Property<TPropertyType>>
    {
        readonly PropertyInfoEnumerator<TPropertyType> _enumerator;

        public PropertyEnumerator(object enumeratedObject)
            : this(enumeratedObject, ".")
        { }

        public PropertyEnumerator(object enumeratedObject, string regexp)
        {
          _enumerator = new PropertyInfoEnumerator<TPropertyType>(enumeratedObject, regexp);
        }

        public IEnumerable<TAttribute> GetClassAttributes<TAttribute>(bool inherit = false)
        {
            var attributes = _enumerator.Instance.GetType().GetCustomAttributes(typeof(TAttribute), inherit);

            if (attributes != null)
            {
                return attributes.Cast<TAttribute>();
            }
            else
            {
                return Enumerable.Empty<TAttribute>();
            }
        }

        public IEnumerator<Property<TPropertyType>> GetEnumerator()
        {
            foreach (var pi in _enumerator)
            {
                yield return new Property<TPropertyType>(_enumerator.Instance, pi);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class PropertyEnumerator : PropertyEnumerator<object>
    {
        public PropertyEnumerator(object enumeratedObject)
            : base(enumeratedObject)
        { }

        public PropertyEnumerator(object enumeratedObject, string regexp)
            : base(enumeratedObject, regexp)
        { }
    }
}
