using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
        [HttpGet("[action]")]
        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Microservices Book",
                    ProductDescription = "Building Microservices with .NET Core2.0",
                    ProductPrice = 655,
                    CategoryDescription = "Books"
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Mango",
                    ProductDescription = "A juicy mango",
                    ProductPrice = 135,
                    CategoryDescription = "Fruits"
                }
            };
            return products;
        }

        public class Product
        {
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public string ProductImage { get; set; }
            public decimal ProductPrice { get; set; }
            public Guid CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string CategoryDescription { get; set; }
        }
        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
