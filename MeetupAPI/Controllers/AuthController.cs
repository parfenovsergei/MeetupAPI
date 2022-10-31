using AutoMapper;
using MeetupAPI.BLL.Services.AuthService;
using MeetupAPI.Domain.Entity;
using MeetupAPI.ViewModels.UserViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

namespace MeetupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register(RegisterUserViewModel request)
        {
            if(ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<RegisterUserViewModel, User>());
                var mapper = new Mapper(config);
                User user = mapper.Map<RegisterUserViewModel, User>(request);

                var response = await _authService.Register(user);

                return response;
            }
            return BadRequest("Bad request");
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginUserViewModel request)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<LoginUserViewModel, User>());
                var mapper = new Mapper(config);
                User user = mapper.Map<LoginUserViewModel, User>(request);

                var response = await _authService.Login(user);

                return Ok(response);
            }
            return BadRequest("Bad request");
        }
    }
}
