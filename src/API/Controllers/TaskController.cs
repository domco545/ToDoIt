using System;
using System.Collections.Generic;
using API.dtos;
using AutoMapper;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public ActionResult<Task> GetById(int id)
        {
            try
            {
                return _taskService.GetById(id);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        // GET task/
        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get([FromQuery] Filter filter)
        {
            try
            {
                var filteredList = _taskService.GetTasks(filter);
                var taskDtoList = new List<TaskDto>();

                foreach (var task in filteredList.List)
                {
                    var assigneeDto = _mapper.Map<AssigneeDto>(task.Assignee);
                    var taskDto = _mapper.Map<TaskDto>(task);
                    taskDto.AssigneeDto = assigneeDto;
                    taskDtoList.Add(taskDto);
                }
                return Ok(taskDtoList);
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