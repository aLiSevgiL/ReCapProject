using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImagesService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelper;
        
        public CarImageManager(ICarImageDal carImageDal,IFileHelperService fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }


        public IResult Add(IFormFile file,CarImage carimage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carimage.CarId));
            
            if (result != null)
            {
                return result;
            }

            carimage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carimage.Date = DateTime.Now.ToString();
            _carImageDal.Add(carimage);

            return new SuccessResult(Messages.CarImagesAdded);

        }

        public IResult Delete(CarImage carimage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carimage.ImagePath);
            _carImageDal.Delete(carimage);

            return new Result(true, Messages.CarImagesDelete);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
           return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile file, CarImage carimage)
        {
            carimage.ImagePath = _fileHelper.Update(file,PathConstants.ImagesPath+carimage.ImagePath,PathConstants.ImagesPath);
            _carImageDal.Update(carimage);

            return new Result(true, Messages.CarImagesUpdate);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }




        public IDataResult<CarImage> GetByImageId(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carId));
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }

        private IResult CheckCarImage (int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage {CarId = carId,Date =DateTime.Now.ToString(),ImagePath="DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

     
    }
}
