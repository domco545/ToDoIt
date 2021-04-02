using System;
using System.Collections.Generic;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssigneeController : Controller
    {
        private readonly IAssigneeService _assigneeService;

        public AssigneeController(IAssigneeService assigneeService)
        {
            _assigneeService = assigneeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Assignee>> Get()
        {
            try
            {
                return Ok(_assigneeService.GetAllAssignees());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Assignee assignee)
        {
            try
            {
                return Ok(_assigneeService.CreateNewAssignee(assignee));
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
                return Ok(_assigneeService.DeleteAssignee(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}