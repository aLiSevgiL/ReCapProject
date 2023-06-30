using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }


        [HttpGet("getdetailall")]  
        public IActionResult GetRentalDetailDto()
        {
            var result = _rentalService.GetRentalDetailDtos();

            if (result.Success)
            {
                return Ok(result);
            }
            else

                return BadRequest(result);
        }
    }
}
