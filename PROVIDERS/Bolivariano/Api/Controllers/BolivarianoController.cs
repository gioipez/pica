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
    using System.IO;

    [Route("api/[controller]")]
    [ApiController]
    public class BolivarianoController : ControllerBase
    {
        public bool success = false;

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

        [HttpPost]
        [Route("cancelarTransporte")]
        public IActionResult cancelarTransporte(TransporteViewModel transporte)
        {
            success = !success;

            if (success)
            {
                return Ok();
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
            if (System.IO.File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = System.IO.File.CreateText(filepath))
                {

                    sw.WriteLine($"{Message.nombre},{Message.apellido},{Message.fecha_salida},{Message.num_viaje},{Message.num_silla},");
                }
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