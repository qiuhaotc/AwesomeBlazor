using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp.Shared
{
    public class XFilter
    {
        public string FilterName { get; set; }
        public string FilterCode { get; set; }
        public FilterType FilterType { get; set; }
        public string FilterText { get; set; }
    }
}
