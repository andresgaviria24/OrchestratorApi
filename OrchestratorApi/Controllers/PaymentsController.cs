using CsvHelper;
using Entities.DTO.Parameters;
using Entities.Model.Parameters;
using Logic.DataTransformation.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OrchestratorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentLogic paymentLogic;

        public PaymentsController(IPaymentLogic paymentLogic)
        {
            this.paymentLogic = paymentLogic;
        }

        /// <summary>
        /// Allows to get all payments
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProducts()
        {
            
            return Ok(await paymentLogic.GetAllAsync());
         
        }


        /// <summary>
        /// Allows to create a product
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> AddPayment([FromBody] PaymentDTO payment)
        {
            if (payment == null)
                return BadRequest();




            await paymentLogic.AddAsync(payment);

            return Created("Product Added", true);
        }
    }
}
