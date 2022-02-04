using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
        public class Userscontroller : BaseApiController
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _map;

        public Userscontroller(IUserRepository userRepo, IMapper map)
        {
            _map = map;
            _userRepo = userRepo;
        }

         // this method without automapper queryble extensions
         //this is not effiecient because it gets all props which are unnecessory
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers(){
        //     var users = await _userRepo.GetUsersAsync();
        //     var usersToReturn = _map.Map<IEnumerable<MemberDto>>(users);
        //     return Ok(usersToReturn);
        // }        
       
        // this method with automapper queryble extensions
         //this is effiecient because it gets only required props code differenece in repository
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetMemebers(){
            var users = await _userRepo.GetMembersAsync();
            return Ok(users);
        }    
      
        [HttpGet("{userName}")]
        public async Task<ActionResult<MemberDto>> GetMemebersByName(string userName){
            return await _userRepo.GetMemberByNameAsync(userName);        
        }
    }
}