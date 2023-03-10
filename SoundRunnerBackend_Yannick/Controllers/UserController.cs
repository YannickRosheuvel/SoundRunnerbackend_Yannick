using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributedSkateWorld.DAL;
using DistributedSkateWorld.Interfaces;
using DistributedSkateWorld.Logic;
using DistributedSkateWorld.Models;
using DistributedSkateWorld.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DistributedSkateWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDAL userDAL;
        UserBLL userBLL;
        public UserController()
        {
            userDAL = new UserDAL();
            userBLL = new UserBLL(userDAL);
        }

        [HttpGet("{id}/user")]
        public User GetUserXP(int id)
        {

            return userBLL.GetUserByID(id);

        }


        [HttpPost("{id}/login")]
        public User LoginUser([FromBody] LoginViewModel loginData) 
        {
            User user = userBLL.Login(loginData.EmailAdress, loginData.Password);

            return user;

        }

        [HttpPost("{id}/register")]
        public User RegisterUser([FromBody] User registerData)
        {
            //User userToRegister = new User();
            //userToRegister.Address = registerData.Address;
            //userToRegister.Email = registerData.EmailAdress;

            User user = userBLL.RegisterUser(registerData);

            return user;
         }
    }

}
