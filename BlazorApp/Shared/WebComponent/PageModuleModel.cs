using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class PageModuleModel<T>
    {
        public PageModuleModel()
        {
        }

        public virtual async Task<List<T>> GetDataAsync()
        {
            var client = new HttpClient();
            var requestUrl = $"{BaseUrl}{GetDataUri}?pagesize={PageInfo.PageSize}&page={PageInfo.CurrentPage}";
            System.Console.WriteLine(requestUrl);
            var response = await client.GetAsync(requestUrl);
            return await response.Content.ReadAsAsync<List<T>>();
        }
        public string GetDataUri { get; set; }
        public PageInfo PageInfo { get; set; }
        public XDataTable<T> XDataTable { get; set; }
        public object BaseUrl => "http://localhost:4507/"; // TODO: Not hard coded
    }
}
