using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using System.Threading;

namespace Api.Controllers
{
    using OfficeOpenXml;
    using System.Globalization;
    using System.IO;

    [Route("api/[controller]")]
    [ApiController]
    public class BolivarianoController : ControllerBase
    {
        public bool success = false;
        public string worksheet = "data";

        [HttpPost]
        [Route("reservarPasaje")]
        public IActionResult reservarPasaje(TransporteViewModel transporte)
        {

            success = !success;

            if (success)
            {
                return Ok(WriteToFile(transporte));
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("cancelarTransporte")]
        public IActionResult cancelarTransporte(TransporteViewModel transporte)
        {
            success = !success;

            if (success)
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosCompartidos\\touresbalon_orden_" + transporte.orderId + ".csv";
                if (System.IO.File.Exists(filepath))
                {
                    using (StreamWriter sw = System.IO.File.AppendText(filepath))
                    {
                        sw. Write($",C");
                    }
                    return Ok();
                }
                else {
                    return BadRequest("reserva no existente");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private string WriteToFile(TransporteViewModel Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosCompartidos";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\ArchivosCompartidos\\touresbalon_orden_" + Message.orderId + ".csv";

            if (!System.IO.File.Exists(filepath))
            {
                var records = new object[]
                                       {
                                            Message.nombre,
                                            Message.apellido,
                                            Message.fecha_salida,
                                            Message.num_viaje,
                                            Message.num_silla,
                                       };

                // Build the file content
                var data = new StringBuilder();
                data.AppendLine(string.Join(",", records));
                byte[] buffer = Encoding.ASCII.GetBytes($"{data.ToString()}");
                System.IO.File.WriteAllBytes($"{filepath}", buffer);
            }
            else
            {
                using (StreamWriter sw = System.IO.File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            return filepath;
        }
    }
}