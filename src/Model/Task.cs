﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AssigneeId { get; set; }
        public Assignee Assignee { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
} 