using Microsoft.AspNetCore.Mvc;
using web_service_calculadora_despliegue.Data;
using web_service_calculadora_despliegue.Models;

namespace web_service_calculadora_despliegue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AritmeticaController : ControllerBase
    {
        private readonly OperacionesDbContext _context;

        public AritmeticaController(OperacionesDbContext context)
        {
            _context = context;
        }

        [HttpGet("sumar")]
        public async Task<IActionResult> Sumar(double op1, double op2)
        {
            var resultado = op1 + op2;
            await Guardar(op1, op2, "Suma", resultado);
            return Ok(resultado);
        }

        [HttpGet("restar")]
        public async Task<IActionResult> Restar(double op1, double op2)
        {
            var resultado = op1 - op2;
            await Guardar(op1, op2, "Resta", resultado);
            return Ok(resultado);
        }

        [HttpGet("multiplicar")]
        public async Task<IActionResult> Multiplicar(double op1, double op2)
        {
            var resultado = op1 * op2;
            await Guardar(op1, op2, "Multiplicación", resultado);
            return Ok(resultado);
        }

        [HttpGet("dividir")]
        public async Task<IActionResult> Dividir(double op1, double op2)
        {
            if (op2 == 0)
                return BadRequest("No se puede dividir entre cero");

            var resultado = op1 / op2;
            await Guardar(op1, op2, "División", resultado);
            return Ok(resultado);
        }

        private async Task Guardar(double num1, double num2, string tipo, double resultado)
        {
            var operacion = new Operacion
            {
                Num1 = num1,
                Num2 = num2,
                TipoOperacion = tipo,
                Resultado = resultado
            };

            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();
        }
    }
}

