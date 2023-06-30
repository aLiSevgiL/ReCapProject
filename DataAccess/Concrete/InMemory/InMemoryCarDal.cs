using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {BrandId=1,ColorId=1,DailyPrice = 12,Description="Şahin",Id=1,ModelYear=Convert.ToDateTime("14.10.2000")},
                new Car {BrandId=1,ColorId=2,DailyPrice = 5,Description="Doğan",Id=2,ModelYear=Convert.ToDateTime("14.10.2010")},
                new Car {BrandId=2,ColorId=3,DailyPrice = 3,Description="Kartal",Id=3,ModelYear=Convert.ToDateTime("14.10.2020")},
                new Car {BrandId=2,ColorId=3,DailyPrice = 2,Description="Pejo ",Id=4,ModelYear=Convert.ToDateTime("14.10.2030")},
                new Car {BrandId=2,ColorId=1,DailyPrice = 5,Description="Ford",Id=5,ModelYear=Convert.ToDateTime("14.10.2050")},
                new Car {BrandId=1,ColorId=2,DailyPrice = 2,Description="Pasat",Id=6,ModelYear=Convert.ToDateTime("14.10.2040")},
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);

            Console.WriteLine(car.Description + "Eklendi");
        }

        public void Delete(Car car)
        {
            Car CarToDetele = _cars.SingleOrDefault(p=>p.Id==car.Id);
            _cars.Remove(CarToDetele);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int Branid)
        {
            return _cars.Where(p=>p.BrandId==Branid).ToList();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges(Car car)
        {
            Car CarUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);

            CarUpdate.BrandId = car.BrandId;
            CarUpdate.ColorId = car.ColorId;
            CarUpdate.DailyPrice = car.DailyPrice;
            CarUpdate.Description = car.Description;
        }

        public void Update(Car car)
        {

            Car CarUpdate = _cars.SingleOrDefault(p=>p.Id ==car.Id);

            CarUpdate.BrandId = car.BrandId;
            CarUpdate.ColorId = car.ColorId;
            CarUpdate.DailyPrice = car.DailyPrice;
            CarUpdate.Description = car.Description;


        }
    }
}
