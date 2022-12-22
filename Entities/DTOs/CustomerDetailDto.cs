using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public int OrderId { get; set; }
        public string? ContactName { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
    }
}
