using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
   public  class InMemoryBrandDal : IBranDal
    {

        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandId =1 , BrandName = "Fort"},
                new Brand{BrandId =1 , BrandName = "Hyundai"},
                new Brand{BrandId =1 , BrandName = "Fiat"},
                new Brand{BrandId =1 , BrandName = "Tofaş"}
            };
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand DeleteBrand = _brands.First(p => p.BrandId == brand.BrandId);

            _brands.Remove(DeleteBrand);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetBrandsId(int Branid)
        {
            return _brands.Where(p => p.BrandId == Branid).ToList();
        }

        public Brand GetT(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand brand)
        {
            Brand BrandUpdate = _brands.SingleOrDefault(p=>p.BrandId==brand.BrandId);
            BrandUpdate.BrandName = brand.BrandName;


        }
    }
}
