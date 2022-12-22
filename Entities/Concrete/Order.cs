using Core.Entities;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public string? CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ShipCity { get; set; }
    }
}
