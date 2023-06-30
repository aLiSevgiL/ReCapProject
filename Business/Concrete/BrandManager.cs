using Business.Abstract;
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
    public class BrandManager : IBranService
    {
        public IBranDal _brandDAL { get; set; }

        public BrandManager(IBranDal brandDAL)
        {
            _brandDAL = brandDAL;
        }

        public IResult Add(Brand brand)
        {
            _brandDAL.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brandDAL.Delete(brand);
            return new SuccessResult();

        }

        public IDataResult<List<Brand>> GetAll()
        {
            var Data = _brandDAL.GetAll();
            return new SuccessDataResult<List<Brand>> (Data);
        }

        public IResult Update(Brand brand)
        {
            _brandDAL.Update(brand);
            return new SuccessResult();
        }
    }
}
