using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListWeb.API.Data;

namespace TodoListWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles= "Regular")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        // Complete a task
        // /api/User/CompleteTask/{id}

         [HttpGet("CompleteTask/{id}")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var task = await _repo.GetTaskById(id);
            if( task == null)
                return BadRequest("There are no task");

            task.IsDone = true;

            if(await _repo.SaveAll())
                return Ok();

            throw new Exception($"Update task {id} failed on save");
        }

        // Todays Task for User
        // /api/User/GetTodaysTaskByUserId/{userId}
        
        [HttpGet("GetTodaysTaskByUserId/{userId}")]
        public async Task<IActionResult> GetTodaysTaskByUserId(int userId)
        {
            var tasks = await _repo.GetTodatsTaskByUserId(userId);
            return Ok(tasks);
        }
    }
}