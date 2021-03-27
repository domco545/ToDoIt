using System;
using System.Collections.Generic;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public int Post(Assignee task)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}