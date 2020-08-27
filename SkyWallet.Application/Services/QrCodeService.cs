using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using MongoDB.Driver;
using QRCoder;
using SkyWallet.Application.Services.Interfaces;

namespace SkyWallet.Application.Services
{
    public class QrCodeService : IQrCodeService
    {
        public byte[] QrCodeGenerator()
        {
         QRCodeGenerator qrGenerator=new QRCodeGenerator();
         QRCodeData qrCodeData = qrGenerator.CreateQrCode("the text which should be encoded", QRCodeGenerator.ECCLevel.Q);
         QRCode qrCode=new QRCode(qrCodeData);
         Bitmap qrCodeImage = qrCode.GetGraphic(20);

         var bitmapBytes = BitmapToBytes(qrCodeImage);
         return bitmapBytes;
        }

        private static  byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
