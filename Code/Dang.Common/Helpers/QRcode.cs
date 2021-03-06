using QRCoder;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Text;

namespace Dang.Common.Helpers
{
    public static class QRcode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static Bitmap GetQRCode(string content, int pixel)
        {

            var generator = new QRCodeGenerator();

            var codeData = generator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q, true);

            var qrcode = new QRCoder.QRCode(codeData);

            var qrImage = qrcode.GetGraphic(pixel, Color.Black, Color.White, false);

            return qrImage;

        }

    }
}
