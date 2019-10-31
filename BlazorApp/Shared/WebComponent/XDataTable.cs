using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp.Shared
{
    public class XDataTable<T>
    {
        public string[] Columns { get; set; }
        public List<T> Data { get; set; }
    }
}
