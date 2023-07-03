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
        IDataResult<List<CarDetailDto>> GetCarsBrandId(int BrandId);
        IDataResult<List<CarDetailDto>> GetCarsColorId(int ColorId);

    }
}
