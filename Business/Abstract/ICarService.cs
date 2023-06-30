using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOS;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult  Update(Car car);
        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
       public IDataResult<List<CarDetailDto>> GetCarsBrandId(int BrandId);

    }
}
