using DutchTreatAspNetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreatAspNetCore.Controllers
{

    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IDutchRepository _rep;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IDutchRepository rep, ILogger<ProductsController> logger)
        {
            _rep = rep;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_rep.GetAllProducts());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception occurred: {ex}");
                return BadRequest(ex.Message);
            }

        }

    }
}
