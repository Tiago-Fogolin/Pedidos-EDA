using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Solucao2.Application.Services;
using Solucao2.Domain;

namespace Solucao2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
        {
            await _pedidoService.CriarPedido(pedido);
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            Pedido pedido = await _pedidoService.PegarPedidoPorId(id);
            
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.PegarPedidoTodos();
            return Ok(pedidos);
        }

        [HttpPost("{id}/faturar")]
        public async Task<IActionResult> FaturarPedido(Guid id)
        {
            Pedido pedido = await _pedidoService.FaturarPedido(id);
            return Ok(pedido);
        }

        [HttpPost("{id}/cancelar")]
        public async Task<IActionResult> CancelarPedido(Guid id)
        {
            Pedido pedido = await _pedidoService.CancelarPedido(id);
            return Ok(pedido);
        }

        [HttpPost("{id}/enviar")]
        public async Task<IActionResult> EnviarPedido(Guid id)
        {
            Pedido pedido = await _pedidoService.EnviarPedido(id);
            return Ok(pedido);
        }
    }
}
