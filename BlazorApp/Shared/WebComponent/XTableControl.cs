using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class PageModuleModel<T>
    {
        public PageModuleModel(string baseUrl, Action refreshState)
        {
            BaseUrl = baseUrl;
            RefreshState = refreshState;
        }

        public virtual async Task<List<T>> GetDataAsync()
        {
            var client = new HttpClient();
            var requestUrl = $"{BaseUrl}{GetDataUri}?pagesize={PageInfo.PageSize}&page={PageInfo.CurrentPage}&{FilterBar.GetFilterStr()}";
            Console.WriteLine(requestUrl);
            var response = await client.GetAsync(requestUrl);
            return await response.Content.ReadAsAsync<List<T>>();
        }
        public string GetDataUri { get; set; }
        public XPageInfo<T> PageInfo { get; set; }
        public XDataTable<T> DataTable { get; set; }
        public XFilterBar FilterBar { get; set; }

        public async Task RefreshData()
        {
            var newPageData = await GetDataAsync();
            DataTable.SetColumnsAndItems(newPageData);
            RefreshState.Invoke();
        }

        public string BaseUrl { get; set; }
        public Action RefreshState { get; }
    }
}
