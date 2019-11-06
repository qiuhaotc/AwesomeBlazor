using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlazorApp.Shared
{
    public class XDataTable<T>
    {
        List<T> data;

        public List<string> Columns { get; set; } = new List<string>();
        public List<T> Data
        {
            get => data;
        }

        public List<XDataItem> Rows { get; set; } = new List<XDataItem>();
        public List<PropertyInfo> ColumnPropertyInfos { get; set; }
        public void SetColumnsAndItems(List<T> data)
        {
            var itemType = typeof(T);
            this.data = data;
            ColumnPropertyInfos = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
            Columns = ColumnPropertyInfos.Select(u => u.Name).ToList();
            Rows = Data.Select(u => GetDataItem(u)).ToList();
        }

        XDataItem GetDataItem(T item)
        {
            var dataItem = new XDataItem();
            dataItem.Values = ColumnPropertyInfos.Select(u => u.GetValue(item)).ToArray();

            return dataItem;
        }
    }
}
