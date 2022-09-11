﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;

namespace ShoppingListApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
   
        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if(!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exeptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(detail: exeptionHandlerFeature.Error.StackTrace,
                 title: exeptionHandlerFeature.Error.Message);
        }

        [Route("/error")]
        public IActionResult HandleError()
        {
            return Problem();   
        }

        [HttpGet("Throw")]
        public IActionResult Throw()
        {
            throw new Exception("Sample Exception");
        }

    }
}