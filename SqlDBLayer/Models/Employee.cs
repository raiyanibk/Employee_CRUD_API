using System;
using System.Collections.Generic;

#nullable disable

namespace SqlDBLayer.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
    }
}
