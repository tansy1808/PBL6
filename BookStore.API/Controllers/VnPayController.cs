using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.DTO;
using BookStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/vnpay")]
    public class VnPayController : Controller
    {
        private readonly IVnpayServices _vnpayServices;

        public VnPayController(IVnpayServices vnpayServices)
        {
            _vnpayServices = vnpayServices;
        }

        [HttpPost]
        public ActionResult CreateVnpay(int id, [FromBody] OrderVnpay orderVnpay, string returnUrl)
        {
            var a = _vnpayServices.CreateOrder(id,orderVnpay, returnUrl);
            return Ok(a);
        }
    }
}