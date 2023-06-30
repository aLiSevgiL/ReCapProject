using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.TransactionAspect;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttringConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Entities.DTOS;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {      
                _carDal.Add(car);
                return new Result(true, Messages.CarAdded);          
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult <List<Car>>(_carDal.GetAll());
        }

        private bool CheckCarValidation(Car car)
        {

            var validationResults = new List<bool>() { CheckCarDescription(car), CheckCarPrice(car) };

            return !validationResults.Any(x => x == false);

        }

        private bool CheckCarDescription(Car car)
        {

            int MIN_DESCRTIPTON_LENGHTH = 2;
            return car.Description.Length >= MIN_DESCRTIPTON_LENGHTH;
        }

        private bool CheckCarPrice(Car car)
        {
            decimal MIN_PRICE = 0;

            return car.DailyPrice > MIN_PRICE;

        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true,Messages.CarDeleted);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return  new Result(true,Messages.CarUpdated);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("Geldi yine tipiniii");
            }
            Add(car);
            return null;
        }

       

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }

        public IDataResult<List<CarDetailDto>> GetCarsBrandId(int BrandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsBrandId(2));
        }
    }
}
