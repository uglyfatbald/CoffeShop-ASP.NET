using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using es.bimaxpro.coffeshop.api.models;
using es.bimaxpro.coffeshop.api.valueObjects;

// Clase Controller
// Se hace cargo del GET, POST y DELETE sobre los pedidos
// Utiliza el contexto de base de datos directamente
namespace es.bimaxpro.coffeshop.api.controllers
{
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private CoffeShopContext _context;

        public PedidosController(CoffeShopContext context)
        {
            _context = context;
        }

        // GET api/pedidos
        [HttpGet]
        public IEnumerable<PedidoEntity> Get()
        {
            return _context.Pedido.ToList();
        }
        
        // GET api/pedidos/{id}
        [HttpGet("{id}", Name = "GetPedido")]
        public IActionResult Get(int id)
        {
            var item = _context.Pedido.Single(b => b.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/pedidos
        [HttpPost]
        public IActionResult Post([FromBody] PedidoInput item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            PedidoEntity pedido = new PedidoEntity();
            pedido.nombre = item.nombre;
            pedido.bebida = item.bebida;
            _context.Pedido.Add(pedido);
            _context.SaveChanges();
            return new ObjectResult(pedido);
        }

        // DELETE api/pedidos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _context.Pedido.Single(b => b.id == id);
            if (pedido == null)
            {
                return NotFound();
            }
            _context.Pedido.Remove(pedido);
            _context.SaveChanges();
            return new EmptyResult();
        }
    }
}
