﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeServices.Model
{
    public class Employee
    {
        public Guid EId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
    }
}
