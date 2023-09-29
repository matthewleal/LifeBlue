﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeBlue.Core.Models
{
    public class VisitorRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address  { get; set; }
        [Required]
        public string Phone  { get; set; }
        [Required]
        public string Budget { get; set; }
    }
}
