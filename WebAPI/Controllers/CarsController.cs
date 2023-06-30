using Business;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService  carService)
        {
            _carService = carService;

        }

        [HttpGet("getall")]
       // [Authorize(Roles ="CarList")]
        public IActionResult Get()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else

                return BadRequest(result);          
        
        }






        [HttpGet("getdetailall")]
        // [Authorize(Roles ="CarList")]
        public IActionResult GetCarDetailDto()
        {
            var result = _carService.GetCarDetailDtos();

            if (result.Success)
            {
                return Ok(result);
            }
            else

                return BadRequest(result);
        }



        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(); 
        
        }



        [HttpPost("update")]

        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }




        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }


        [HttpPost("addtransaciton")]

        public IActionResult AddTransactionalTest(Car car)
        {
            var result = _carService.AddTransactionalTest(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }

        [HttpGet("getbrandId")]
        // [Authorize(Roles ="CarList")]
        public IActionResult GetCarsBrandId()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else

                return BadRequest(result);

        }



    }
}
