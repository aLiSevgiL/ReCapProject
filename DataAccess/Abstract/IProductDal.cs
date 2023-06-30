using Entities.Concrete;
using System.Collections.Generic;


namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Car> GetAll();

    }
}
