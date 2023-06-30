using Entities.Concrete;
using Entities.DTOS;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {

        List<CarDetailDto> GetCarDetailDtos(); 
  

    }
}
