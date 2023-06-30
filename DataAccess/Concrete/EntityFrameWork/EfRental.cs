using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRental :EfEntityRepositoryBase<Rental, NorthwindContext>, IRental
    {
        public List<RentalDetailDto> GetRentalDetailDtos()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from r in context.Rentals
                             join c in context.Car on r.CarId equals c.Id
                             join cus in context.Customers on r.CustomerId equals cus.CustomerId
                             join us in context.Users on cus.UserId equals us.Id

                             select new RentalDetailDto
                             {                                 
                                 CarName = c.Description,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }

        }

    }
}
