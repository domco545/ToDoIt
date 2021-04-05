using System;
using System.Collections.Generic;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        //  GET test
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "test " + id;
        }



        // GET task/
        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_taskService.GetTasks(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Task task)
        {
            try
            {
                return Ok(_taskService.CreateTask(task));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Task task)
        {
            try
            {
                return Ok(_taskService.UpdateTask(task));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("updateStatus/{id}")]
        public IActionResult UpdateTaskStatus(int id, [FromBody] TaskStatusUpdateDto taskDto)
        {
            try
            {
                return Ok(_taskService.UpdateTaskStatus(id, taskDto.IsCompleted));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_taskService.DeleteTask(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}