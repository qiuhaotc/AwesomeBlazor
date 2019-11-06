using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlazorApp.Shared
{
    public class XFilterBar
    {
        public List<XFilter> Filters { get; set; } = new List<XFilter>();
        public string GetFilterStr()
        {
            return string.Join("&", Filters.Select(u => $"{u.FilterCode}={HttpUtility.UrlEncode(u.FilterText)}"));
        }
    }
}
