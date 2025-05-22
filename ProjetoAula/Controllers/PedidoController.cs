using ProjetoAula.Objects.Models;
using ProjetoAula.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoAula.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            this._pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAll();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetById(id);
            if (pedido == null)
                return NotFound("Pedido não encontrada");
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pedido pedido)
        {
            try
            {
                await _pedidoService.Create(pedido);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar inserir uma nova pedido");
            }
            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pedido pedido)
        {
            try
            {
                await _pedidoService.Update(pedido, id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar atualizar os dados da pedido: " + ex.Message);
            }
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pedidoService.Remove(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar remover a pedido");
            }
            return Ok("Pedido removida com sucesso");
        }
    }
}
