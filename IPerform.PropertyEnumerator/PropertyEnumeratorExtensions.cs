using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPerform.PropertyEnumerator
{
    public static class PropertyEnumeratorExtensions
    {
        public static PropertyEnumerator<TType> GivePropertyEnumerator<TType>(this object @this, string regexp = "*")
        {
            return new PropertyEnumerator<TType>(@this, regexp);
        }
    }
}
