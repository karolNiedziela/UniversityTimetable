﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityTimetable.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
