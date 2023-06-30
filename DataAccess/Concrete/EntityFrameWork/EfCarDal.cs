using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess;
using Entities.DTOS;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.Car
                             join co in context.Color on c.ColorId equals co.ColorId
                             join b in context.Brand on c.BrandId equals b.BrandId

                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.BrandId,
                                 CarName = c.Description,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice

                             };

                return result.ToList();
            }

        }
    }



}
