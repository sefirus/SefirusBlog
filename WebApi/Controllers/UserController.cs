using Core.Entities;
using Core.Interfaces;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IAuthService _authService;
    //private readonly IUserService _userService;
    //private readonly IVmMapper<CreateUserViewModel, User> _createMapper;

    public UserController(
        IAuthService authService)
        //IUserService userService,
        //IVmMapper<CreateUserViewModel, User> createMapper)
    {
        _authService = authService;
        //_userService = userService;
        //_createMapper = createMapper;
    }
    
    [HttpPost("api/login")]
    public async Task<string> LoginAsync([FromBody]LoginViewModel loginViewModel)
    {
        var token = await _authService.Login(loginViewModel.Email, loginViewModel.Password);
        return token;
    }

    // [HttpPost("api/register")]
    // public async Task<string> RegisterAsync([FromBody]CreateUserViewModel registerViewModel)
    // {
    //     var newUser = _createMapper.Map(registerViewModel);
    //     await _userService.CreateUser(newUser, registerViewModel.Password);
    //     var token = await _authService.Login(newUser.Email, registerViewModel.Password);
    //     return token;
    // }
}