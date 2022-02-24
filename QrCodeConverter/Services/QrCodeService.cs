using QRCoder;
using System.Drawing;

namespace QrCodeConverter.Services
{
    public class QrCodeService
    {
        public static Bitmap ConverterToBitmap(string Parametro)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Parametro, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}
