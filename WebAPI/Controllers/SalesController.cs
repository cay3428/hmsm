using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {

            var result = _salesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbysid")]
        public IActionResult GetAllById(int salesId)
        {
            var result = _salesService.GetbySId(salesId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int customerId)
        {
            var result = _salesService.GetById(customerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyunitprice")]
        public IActionResult GetByUnitPrice(decimal min, decimal max)
        {
            var result = _salesService.GetByUnitPrice(min,max);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }








 

        [HttpPost("add")]
        public IActionResult Add(Sales sales)
        {
            var result = _salesService.Add(sales);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(Sales sales)
        {
            var result = _salesService.Update(sales);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("delete")]
        public ActionResult Delete(int salesId)
        {

            var result = _salesService.Delete(salesId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}


 