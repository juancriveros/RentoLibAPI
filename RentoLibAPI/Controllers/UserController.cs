using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentoLibAPI.DTO;
using RentoLibBusiness;
using RentoLibData.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentoLibAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<ActionResult<UserDTO>> LoginUser([FromBody] UserLoginDTO userLogin)
        {
            var user = await userService.UserLogin(userLogin.Username, userLogin.Password);
            if(user == null)
            {
                return NotFound();
            }

            var userDto = mapper.Map<UserDTO>(user);
            return userDto;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await userService.GetById(id);
            if (user == null)
            { 
                return NotFound();
            }

            var userDto = mapper.Map<UserDTO>(user);
            return userDto;
        }
    }
}
