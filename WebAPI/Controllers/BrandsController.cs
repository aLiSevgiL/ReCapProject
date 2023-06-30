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
    public class BrandsController : ControllerBase
    {

        IBranService _brandService;
        public BrandsController(IBranService BrandService)
        {
            _brandService = BrandService;

        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _brandService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else

                return BadRequest(result);

        }

        [HttpPost("add")]

        public IActionResult Add(Brand Brand)
        {
            var result = _brandService.Add(Brand);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }



        [HttpPost("update")]

        public IActionResult Update(Brand Brand)
        {
            var result = _brandService.Update(Brand);

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }




        [HttpPost("delete")]
        public IActionResult Delete(Brand Brand)
        {
            var result = _brandService.Delete(Brand);

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest();

        }




    }
}
