﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MasterWithApi.models
{
    public class EmployeeGet
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }
}
