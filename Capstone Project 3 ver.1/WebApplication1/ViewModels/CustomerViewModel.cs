﻿using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class CustomerViewModel
    {
        public Customer customer { get; set; }
        public List<ValidationResult> errors { get; set; }

        public CustomerViewModel()
        {
            customer = new Customer();
            errors = new List<ValidationResult>();
        }
    }
}
