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
            for (var i = 0; i < pageSize; i++)
            {
                data.Add(new DemoModel()
                {
                    AddDate = DateTime.Now,
                    Name = $"Demo Data: {pageSize} + {page} + {i}",
                    PK = Guid.NewGuid()
                });
            }

            return data;
        }
    }
}