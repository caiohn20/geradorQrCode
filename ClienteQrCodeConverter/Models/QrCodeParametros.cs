using System.Drawing;

namespace ClienteQrCodeConverter.Models
{
    public class QrCodeParametros
    {
        public string parametroEntrada { get; set; }
        public string textConverted { get; set; }
        public Bitmap bitMapConverted { get; set; }
        public byte[] bytesConverted { get; set; }
    }
}
