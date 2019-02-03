using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using FTAdverts.Entities;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace FTAdverts.Controllers
{
    [ApiController]
    [ApiVersion( "1.0" )]
    [Produces("application/json")]	
    [Route( "api/v{version:apiVersion}/[controller]" )] 
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        // GET: api/Payments
        [HttpGet]
        public IActionResult Get()
        {
            //return new ObjectResult(await _paymentRepository.GetAllPayments());
            return Ok(Mapper.Map<IEnumerable<PaymentDTO>>(_paymentRepository.GetAllPayments()));
        }

        // GET: api/Payments/name
        [HttpGet("{name}", Name = "Get")]
        public IActionResult Get(string name)
        {
            var payments = _paymentRepository.GetPayment(name);

            if (payments == null)
                return new NotFoundResult();

            return new ObjectResult(payments);
        }

        // POST: api/Payment
        [HttpPost]
        public IActionResult Post([FromBody]PaymentCreationDTO paymentCreationDTO)
        {
            var payment = Mapper.Map<Payment>(paymentCreationDTO);
            payment.Date = DateTime.Now;

            _paymentRepository.Create(payment);

            var paymentDTO = Mapper.Map<PaymentDTO>(payment);
            return Ok(paymentDTO);
        }

        // PUT: api/Payment/5
        [HttpPut("{name}")]
        public IActionResult Put(string name, [FromBody]Payment payment)
        {
            var paymentFromDb = _paymentRepository.GetPayment(name);

            if (paymentFromDb == null)
                return new NotFoundResult();

            payment.Id = paymentFromDb.Id;

            _paymentRepository.Update(payment);

            return new OkObjectResult(payment);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var paymentFromDb = _paymentRepository.GetPayment(name);

            if (paymentFromDb == null)
                return new NotFoundResult();

            _paymentRepository.Delete(name);

            return new OkResult();
        }
    }
}