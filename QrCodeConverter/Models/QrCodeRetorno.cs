using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Drawing;
using QRCoder;
using System.IO;
using System.Drawing.Imaging;

namespace QrCodeConverter.Models
{
    public class QrCodeRetorno
    {
        public string ParametroEntrada { get; set; }
        public string TextConverted { get; set; }
        public Bitmap BitMapConverted { get; set; }
        public byte[] BytesConverted { get; set; }
    }
}
