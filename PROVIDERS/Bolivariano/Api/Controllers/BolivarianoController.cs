using System;
using System.Collections.Generic;
using System.IO;
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
            //if ()
            //{
            //    // Create a file to write to.   
            //    using (StreamWriter sw = File.CreateText(filepath))
            //    {
            //        sw.WriteLine(Message);
            //    }
            //}
            //else
            //{
            //    using (StreamWriter sw = File.AppendText(filepath))
            //    {
            //        sw.WriteLine(Message);
            //    }
            //}
            return filepath;
        }
    }
}