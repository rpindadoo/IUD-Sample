using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using IUD.Api.Models;
using IUD.Service.EntityServices;

namespace IUD.Api.Controllers
{
    public class UserController : ApiController
    {
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        private IUserService _userService { get; set; }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            IQueryable<DataAccess.Entities.User> data = _userService.GetAll();
            IEnumerable<User> users = Mapper.Map<IQueryable<DataAccess.Entities.User>, IEnumerable<User>>(data);
            if (users == null)
            {
                return InternalServerError();
            }
            return await Task.FromResult(Ok(users));
        }


        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            DataAccess.Entities.User data = _userService.GetById(id);
            User user = Mapper.Map<DataAccess.Entities.User, User>(data);
            if (user == null)
            {
                return NotFound();
            }
            return await Task.FromResult(Ok(user));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DataAccess.Entities.User userToBeSaved = Mapper.Map<User, DataAccess.Entities.User>(user);
            _userService.Add(userToBeSaved);
            _userService.SaveChanges();
            User userCreated = Mapper.Map<DataAccess.Entities.User, User>(userToBeSaved);

            return await Task.FromResult(Ok(userCreated));

            //return Created<User>(Request.RequestUri + userCreated.Id.ToString(), userCreated);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DataAccess.Entities.User userToUpdate = Mapper.Map<User, DataAccess.Entities.User>(user);
            _userService.Update(userToUpdate);
            _userService.SaveChanges();
            User userUpdated = Mapper.Map<DataAccess.Entities.User, User>(userToUpdate);

            return await Task.FromResult(Ok(userUpdated));
        }


        [HttpDelete]
        public async Task<IHttpActionResult> Remove(int id)
        {
            DataAccess.Entities.User user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.Remove(user);
            _userService.SaveChanges();
            return await Task.FromResult(Ok());
        }
    }
}