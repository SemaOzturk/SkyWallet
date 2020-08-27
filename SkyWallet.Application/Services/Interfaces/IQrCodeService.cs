using System;
using System.Collections.Generic;
using System.Text;

namespace SkyWallet.Application.Services.Interfaces
{
    public interface IQrCodeService
    {
        public byte[] QrCodeGenerator();
    }
}
