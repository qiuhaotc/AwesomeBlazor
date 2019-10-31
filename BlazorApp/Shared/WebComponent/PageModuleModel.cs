using System;
using System.Collections.Generic;
namespace BlazorApp.Shared
{
    public class PageModuleModel<T>
    {
        public PageInfo PageInfo { get; set; }
        public XDataTable<T> XDataTable { get; set; }
    }
}
