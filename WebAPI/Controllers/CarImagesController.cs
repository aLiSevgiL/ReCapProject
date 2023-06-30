using Business.Abstract;
using Entities.Concrete;
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

    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImageService;

        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImageService = carImagesService;
        }



        [HttpPost("add")]

        public IActionResult Add([FromForm(Name =("Image"))] IFormFile file,[FromForm] CarImage carimage)
        {
            var result = _carImageService.Add(file,carimage);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }





        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else

                return BadRequest(result);

        }




        [HttpPost("update")]

        public IActionResult Update([FromForm]IFormFile file,CarImage carimage)
        {
            var result = _carImageService.Update(file,carimage);

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }



        [HttpPost("delete")]
        public IActionResult Delete(CarImage carimage)
        {
            var carDeleteImage = _carImageService.GetByImageId(carimage.CarId).Data;
            var result = _carImageService.Delete(carimage);

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }



        [HttpGet("gettbycarid")]
        public IActionResult GetByCarId(int carId)
        {

            var result = _carImageService.GetByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }

        [HttpGet("gettbyimageid")]
        public IActionResult GetByImageId(int imageid)
        {

            var result = _carImageService.GetByImageId(imageid);

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }



    }
}
