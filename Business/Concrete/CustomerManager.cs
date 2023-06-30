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
   public class CustomerManager:ICustomerService
    {
        ICustomerDal _ICustomerDal;

        public CustomerManager(ICustomerDal Customer)
        {
            _ICustomerDal = Customer;
        }

        public IResult Add(Customer Customer)
        {
            _ICustomerDal.Add(Customer);
            return new Result(true, Messages.CarAdded);

        }

        public IResult Delete(Customer Customer)
        {
            _ICustomerDal.Delete(Customer);
            return new Result(true, Messages.CarDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_ICustomerDal.GetAll());
        }

        public IResult Update(Customer Customer)
        {
            _ICustomerDal.Update(Customer);
            return new Result(true);
        }


    }
}
