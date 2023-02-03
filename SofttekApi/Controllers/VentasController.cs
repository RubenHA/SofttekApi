using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SofttekApi.Data;
using SofttekApi.Models;
using System.Security.Claims;

namespace SofttekApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly VentaContext _context;

        public VentasController(VentaContext context)
        {
            _context = context;
            if(_context.Ventas.Count() == 0)
            {
                List<Venta> venta = new List<Venta>();
                //venta.Add(new Venta { producto = "Platos", cliente = "Ricardo Ortiz", usuario = "UsuarioSofttek", cantidad = 1, precio = 3.5, fecha = DateTime.Parse("02/02/2023") });
                //venta.Add(new Venta { producto = "Cubiertos", cliente = "Paola Estrella", usuario = "UsuarioSofttek", cantidad = 1, precio = 4.5, fecha = DateTime.Parse("02/02/2023") });
                //venta.Add(new Venta { producto = "Mesas", cliente = "Nahomy Aguirre", usuario = "UsuarioSofttek", cantidad = 1, precio = 2.5, fecha = DateTime.Parse("02/02/2023") });
                _context.Ventas.AddRange(venta);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return NotFound();


            var ventas = await _context.Ventas.ToListAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return NotFound();

            var ventas = await _context.Ventas.FirstOrDefaultAsync(obj => obj.id == id);
            if(ventas == null)
            {
                return NotFound();
            }
            return Ok(ventas);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Venta venta)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return NotFound();

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = venta.id }, venta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Venta venta)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return NotFound();

            if (id == venta.id)
            {
                _context.Entry(venta).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return NotFound();

            var detalle = await _context.Ventas.FindAsync(id);
            if(detalle == null)
            {
                return NotFound();
            }
            _context.Ventas.Remove(detalle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
