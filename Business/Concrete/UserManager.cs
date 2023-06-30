using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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
    public class UserManager : IUserService
    {

        IUserDal _IUserDal;

        public UserManager(IUserDal user)
        {
            _IUserDal = user;
        }

        public IResult Add(User user)
        {
            _IUserDal.Add(user);
            return new Result(true, Messages.CarAdded);

        }

        public IResult Delete(User user)
        {
            _IUserDal.Delete(user);
            return new Result(true, Messages.CarDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_IUserDal.GetAll());
        }

        public User GetByMail(string email)
        {
            return _IUserDal.Get(u=>u.Email==email);
            
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _IUserDal.GetClaims(user);
        }

        public IResult Update(User user)
        {
            _IUserDal.Update(user);
            return new Result(true);
        }

    }
}
