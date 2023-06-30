using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _IColorDal;

        public ColorManager(IColorDal color)
        {
            _IColorDal = color;
        }

        public IResult Add(Color color)
        {
            _IColorDal.Add(color);
            return  new Result(true,Messages.CarAdded);

        }

        public IResult Delete(Color color)
        {
            _IColorDal.Delete(color);
            return new Result(true, Messages.CarDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_IColorDal.GetAll());
        }

        public IResult Update(Color color)
        {
            _IColorDal.Update(color);
            return new Result(true);
        }
    }
}
