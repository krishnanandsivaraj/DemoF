using System.Collections.Generic;
using System.Threading.Tasks;
using DemoF.Core.Contracts;
using DemoF.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DemoF.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userServices;

        public UserController(IUserService userService)
        {
            _userServices = userService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return _userServices.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            if (id == 0)
                throw new KeyNotFoundException("This is a special exception for id = 0");

            return await _userServices.GetUserAsync(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
