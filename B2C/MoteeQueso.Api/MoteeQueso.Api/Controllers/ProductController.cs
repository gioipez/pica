using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoteeQueso.Api.ViewModels;

namespace MoteeQueso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Consultar productos (Escenario sin autorizacion)
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        public IActionResult GetProducts()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            products.Add(new ProductViewModel
            {
                Id = 1,
                Name = "Final Conmebol Libertadores 2019",
                Description = "La final está programada para que se juegue en el estadio Nacional. Será la primera vez en la historia de la competencia que habrá final con sede neutral",
                City = "Santiago de Chile, Chile",
                Date = new DateTime(2019, 11, 23),
                Price = 2000000,
                ImageUrl = "libertadores2019.png"
            });

            products.Add(new ProductViewModel
            {
                Id = 2,
                Name = "Final Conmebol Sudamericana 2019",
                Description = "La final está programada para que se juegue en el estadio La Nueva Olla. Será la primera vez en la historia de la competencia que habrá final con sede neutral",
                City = "Asunción, Paraguay",
                Date = new DateTime(2019, 11, 9),
                Price = 1500000,
                ImageUrl = "sudamericana2019.png"
            });

            products.Add(new ProductViewModel
            {
                Id = 3,
                Name = "Final Uefa Champions League 2020",
                Description = "El Estadio Olímpico Atatürk, con capacidad para 76.000 espectadores y que alberga los partidos de la Selección de fútbol de Turquía, fue el elegido para acoger la final del torneo",
                City = "Estambul, Turquia",
                Date = new DateTime(2020, 5, 30),
                Price = 5000000,
                ImageUrl = "champions2020.png"
            });

            products.Add(new ProductViewModel
            {
                Id = 4,
                Name = "Final Uefa Europa League 2019",
                Description = "El Arena Gdansk, será la sede de la final del torneo.",
                City = "Gdansk, Polonia",
                Date = new DateTime(2020, 5, 27),
                Price = 4000000,
                ImageUrl = "europaleague2020.png"
            });

            products.Add(new ProductViewModel
            {
                Id = 5,
                Name = "Copa America 2020",
                Description = "La Copa América 2020 será la XLVII edición de este torneo, la principal competencia futbolística entre las selecciones nacionales de América del Sur y la más antigua del mundo",
                City = "Argentina / Colombia",
                Date = new DateTime(2020, 6, 10),
                Price = 20000000,
                ImageUrl = "copaamerica2020.png"
            });

            products.Add(new ProductViewModel
            {
                Id = 6,
                Name = "Eurocopa 2020",
                Description = "La Eurocopa de fútbol 2020 o Euro 2020 será la decimosexta edición del torneo europeo de selecciones nacionales.",
                City = "Inglaterra / Italia / España / Holanda / Alemania",
                Date = new DateTime(2020, 6, 12),
                Price = 40000000,
                ImageUrl = "eurocopa2020.png"
            });

            return Ok(products);
        }
    }
}