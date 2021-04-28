using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListWeb.API.Data;
using TodoListWeb.API.Dtos;
using TodoListWeb.API.Models;

namespace TodoListWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles= "Admin")]
    public class AdminController: ControllerBase
    {
         private readonly IAdminRepository _repo;
        private readonly IMapper _mapper;
        public AdminController(IAdminRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        // For Create Task
        // /api/Admin
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskForCreationDtos taskForCreationDtos)
        {
            if(! await _repo.IsUserExists(taskForCreationDtos.UserId))
                return BadRequest("User doesn't Exist");

            var createdTask = _mapper.Map<Tasks>(taskForCreationDtos);

            _repo.Add<Tasks>(createdTask);

            if(await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest();
        }

        // Delete Task By Task ID
        // /api/Admin/DeleteTask/{id}

        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _repo.GetTaskById(id);
            if( task == null)
                return BadRequest("There are no task");

            task.IsDeleted = true;
            task.DeletedDate = DateTime.Now;

            if(await _repo.SaveAll())
                return Ok();

            throw new Exception($"Delete task {id} failed");
        }


        // To Complete a Task
        // /api/Admin/CompleteTask/{id}

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

        // Get Todays Task For User 
        //  /api​/Admin​/GetTodaysTaskByUserId​/{userId}

        [HttpGet("GetTodaysTaskByUserId/{userId}")]
        public async Task<IActionResult> GetTodaysTaskByUserId(int userId)
        {
            var tasks = await _repo.GetTodatsTaskByUserId(userId);
            return Ok(tasks);
        }

        // Get All User
        // /api/Admin/GetUsers

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<ICollection<UserForDetailsDtos>>(users);
            return Ok(usersToReturn);
        }

        // Get All Task 
        // /api/Admin/GetTasks

        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _repo.GetTasks();
            return Ok(tasks);
        }

        // Get Completd All Task performed by User
        // /api/Admin/GetCompletedTasks
        
        [HttpGet("GetCompletedTasks")]
        public async Task<IActionResult> GetCompletedTasks()
        {
            var tasks = await _repo.GetCompletedTasks();
            return Ok(tasks);
        }



        

    }
}