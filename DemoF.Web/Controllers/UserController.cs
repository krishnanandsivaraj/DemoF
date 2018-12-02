using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoF.Core.Contracts;
using DemoF.Core.Domain;
using DemoF.Web.Extensions;
using DemoF.Web.ViewModels;
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

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return _userServices.All();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            if (id <= 0)
                throw new KeyNotFoundException("Just added this special exception for id = 0");

            return await _userServices.GetUserAsync(id);
        }

        [HttpPost]
        public async Task<User> Post([FromBody] UserViewModel model)
        {
            var newUser = new User()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                ValidFrom = DateTime.UtcNow,
                ValidUntill = DateTime.UtcNow + TimeSpan.FromDays(30)
            };

            await _userServices.AddAsync(newUser);
            return newUser;
        }

        [HttpPut("{id}")]
        public async Task<User> Put(int id, [FromBody] UserViewModel model)
        {
            var updateUser = new User()
            {
                Id = id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName
            };

            await _userServices.UpdateAsync(id, updateUser);
            return updateUser;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userServices.RemoveAsync(id);
            return new OkResult();
        }
    }
}
