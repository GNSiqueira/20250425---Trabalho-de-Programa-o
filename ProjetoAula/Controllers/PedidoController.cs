using ProjetoAula.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProjetoAula.Objects.DTOs;

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

        # region Métodos CRUD
        [HttpPost]
        public async Task<IActionResult> Post(PedidoDTO pedido)
        {
            try
            {
                await _pedidoService.Create(pedido);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar inserir uma nova pedido");
            }
            return Ok(pedido);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAll();
            return Ok(pedidos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pedido = await _pedidoService.GetById(id);
                return Ok(pedido);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(PedidoDTO pedido)
        {
            try
            {
                await _pedidoService.Update(pedido);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
            return Ok("Pedido atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pedidoService.Remove(id);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar remover a pedido");
            }
            return Ok("Pedido removida com sucesso");
        }
        #endregion

        # region State
        [HttpPatch("{id:int}/pagar")]
        public async Task<IActionResult> Pagar(int id)
        {
            try
            {
                await _pedidoService.Pagar(id);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar pagar a pedido");
            }
            return Ok("Pedido pago com sucesso");
        }

        [HttpPatch("{id:int}/enviar")]
        public async Task<IActionResult> Enviar(int id)
        {
            try
            {
                await _pedidoService.Enviar(id);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar enviar a pedido");
            }
            return Ok("Pedido enviado com sucesso");
        }

        [HttpPatch("{id:int}/cancelar")]
        public async Task<IActionResult> Cancelar(int id)
        {
            try
            {
                await _pedidoService.Cancelar(id);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar cancelar a pedido");
            }
            return Ok("Pedido cancelado com sucesso");
        }
        #endregion

        #region Template
        [HttpGet("{id:int}/frete")]
        public async Task<IActionResult> GetInfoFrete(int id)
        {
            try
            {
                var frete = await _pedidoService.GetInfoFrete(id);
                return Ok(frete);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao tentar enviar a pedido");
            }
        }
        #endregion
    }
}
