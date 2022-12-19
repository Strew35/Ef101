using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public int OrderId { get; set; }
        public string? ContactName { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
    }
}
