using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPerform.PropertyEnumerator.Examples.Basic
{
    public class TableHeaderAttribute : Attribute
    {
        readonly string _headerText;
        readonly bool _includeDateTime;

        public string HeaderText
        {
            get
            {
                if (_includeDateTime == true)
                {
                    return string.Format(_headerText, DateTime.Now);
                }
                else
                {
                    return _headerText;
                }
            }
        }

        public TableHeaderAttribute(string headerText, bool includeDateTime = false)
        {
            _headerText = headerText;
            _includeDateTime = includeDateTime;
        }
    }
}
