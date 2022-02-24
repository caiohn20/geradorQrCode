using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace QrCodeConverter.Services
{
    public class BitmapService
    {
        public static string ConverterToBase64(Bitmap Parametro)
        {
            MemoryStream ms = new MemoryStream();
            Parametro.Save(ms, ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage);

            return SigBase64;
        }

        public static byte[] ConverterToBytes(Bitmap Parametro)
        {
            MemoryStream ms = new MemoryStream();
            Parametro.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }
    }
}
