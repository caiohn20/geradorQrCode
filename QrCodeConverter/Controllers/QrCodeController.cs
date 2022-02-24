using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QrCodeConverter.Models;
using QrCodeConverter.Services;

namespace QrCodeConverter.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeController : Controller
    {
        // POST: QrCodeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(QrCodeParametrosEntrada qrCodeItem)
        {
            if (qrCodeItem.Parametro == null) return NotFound();

            var bitmap = QrCodeService.ConverterToBitmap(qrCodeItem.Parametro);
            string text = BitmapService.ConverterToBase64(bitmap);
            byte[] bytes = BitmapService.ConverterToBytes(bitmap);

            var qrCodeItemNew = new QrCodeRetorno
            {
                ParametroEntrada = qrCodeItem.Parametro,
                TextConverted = text,
                BitMapConverted = bitmap,
                BytesConverted = bytes
            };

            return Ok(qrCodeItemNew);
        }
    }
}
