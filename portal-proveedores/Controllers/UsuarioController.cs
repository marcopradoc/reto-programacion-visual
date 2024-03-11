using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using portal_proveedores.Data;
using portal_proveedores.Models;
using System.ComponentModel.DataAnnotations;

namespace portal_proveedores.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        PortalContext context;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
            context = new PortalContext();
        }

        [HttpGet("GetAllUsuarios")]
        public async Task<IActionResult> GetAll()
        {
            ServiceResponse<List<Usuario>> response = new ServiceResponse<List<Usuario>>();

            List<Usuario> listUsuarios = context.Set<Usuario>().ToList();

            var apiResponse = new ServiceResponse<List<Usuario>>
            {
                Result = listUsuarios
            };

            return Ok(apiResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest authenticateRequest)
        {
            Usuario usuario = context.Set<Usuario>().ToList().FirstOrDefault(x => x.Usuario1.Equals(authenticateRequest.Username) && x.Clave.Equals(authenticateRequest.Password));

            var apiResponse = new ServiceResponse<Usuario>
            {
                Result = usuario
            };

            if (usuario == null)
            {
                apiResponse.HasError = true;
                apiResponse.Message = "Usuario y/o contraseña incorrectos";
                return BadRequest(apiResponse);
            }

            return Ok(apiResponse);
        }
    }

    public class AuthenticateRequest
    {
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
