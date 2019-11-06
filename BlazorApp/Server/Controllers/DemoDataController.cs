using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoDataController : ControllerBase
    {
        public List<DemoModel> GetDemoData(int page, int pageSize)
        {
            var data = new List<DemoModel>();
            var nameFilter = Request.Query["Name"];
            for (var i = 0; i < pageSize; i++)
            {
                if(!string.IsNullOrEmpty(nameFilter))
                {
                    data.Add(new DemoModel()
                    {
                        AddDate = DateTime.Now,
                        Name = $"Demo Data: {pageSize} + {page} + {i}, equal to {nameFilter}",
                        PK = Guid.NewGuid()
                    });
                }
                else
                {
                    data.Add(new DemoModel()
                    {
                        AddDate = DateTime.Now,
                        Name = $"Demo Data: {pageSize} + {page} + {i}",
                        PK = Guid.NewGuid()
                    });
                }
            }

            return data;
        }
    }
}