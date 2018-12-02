using DemoF.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoF.Web.Controllers
{
    [ServiceFilter(typeof(ApiExceptionFilter))]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class BaseApiController : ControllerBase
    {
        public BaseApiController()
        {
            // Instantiate a single JsonSerializerSettings object
            // that can be reused multiple times.
            JsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };
        }

        protected JsonSerializerSettings JsonSettings { get; private set; }
    }
}
