using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {

        //  GET test
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "test " + id;
        }

        // GET task/
        [HttpGet]
        public IEnumerable<Task> Get(string searchTerm)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public int Post(Task task)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public void Put(Task task)
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