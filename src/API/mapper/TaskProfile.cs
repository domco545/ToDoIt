using System;
using API.dtos;
using AutoMapper;
using Model;

namespace API.mapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<Assignee, AssigneeDto>();

        }

    }
}
