using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyWallet.Application.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkyWallet.Controllers
{
    [Route("api/[controller]")]
    public class ORCodeController : Controller
    {
        private readonly IQrCodeService _qrCodeService;

        public ORCodeController(IQrCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        public IActionResult GetQrCode()
        {
            return  Ok(_qrCodeService.QrCodeGenerator());
        }
    }
}
