using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Core.Entities.Concrete;
using System;
using Entities.Concrete;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            



            EfCarDal efCarDalDto = new EfCarDal();

            foreach (var cardto in efCarDalDto.GetCarDetailDtos())
            {
                Console.WriteLine(cardto.BrandName);
                Console.WriteLine(cardto.CarName);
                Console.WriteLine(cardto.ColorName);
            }


            UserCustomerAddedTest();
            


        }

     private  static  void UserCustomerAddedTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());


            Customer customer = new Customer();

            customer.CompanyName = "Egemen";
            customer.UserId = 1;
            customer.CustomerId = 1;

            customerManager.Add(customer);



            User user1 = new User();
            user1.Id = 1;
            user1.FirstName = "Ali";
            user1.LastName = "Sevgil";
            user1.Email = "realchaos 1wasd";
            
            

            userManager.Add(user1);

       




        }


        private void RentalAdd()
        {


        }

    }
}
