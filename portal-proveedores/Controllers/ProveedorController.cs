using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portal_proveedores.Data;
using portal_proveedores.Models;

namespace portal_proveedores.Controllers
{
    [Route("api/proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        PortalContext context;

        public ProveedorController(IConfiguration configuration)
        {
            _configuration = configuration;
            context = new PortalContext();
        }

        [HttpGet("GetAllProveedores")]
        public async Task<IActionResult> GetAll()
        {
            ServiceResponse<List<Proveedor>> response = new ServiceResponse<List<Proveedor>>();
                        
            List<Proveedor> listproveedores = context.Set<Proveedor>().ToList();

            var apiResponse = new ServiceResponse<List<Proveedor>>
            {
                Result = listproveedores
            };

            return Ok(apiResponse);
        }

        [HttpPost("AddProveedor")]
        public async Task<IActionResult> Add(Proveedor proveedor)
        {
            context.Proveedors.Add(proveedor);
            context.SaveChanges();

            var apiResponse = new ServiceResponse<Proveedor>
            {
                Result = proveedor
            };

            return Ok(apiResponse);
        }
    }
}
