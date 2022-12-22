using Core.Concrete.EntityFramework;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (NorthwindContext context = new())
            {
                var result = from o in context.Orders
                             join c in context.Customers
                             on o.CustomerId equals c.CustomerId
                             select new CustomerDetailDto
                             {
                                 OrderId = o.OrderId,
                                 ContactName = c.ContactName,
                                 CompanyName = c.CompanyName,
                                 City = c.City
                             };
                return result.ToList();
            }
        }
    }
}
