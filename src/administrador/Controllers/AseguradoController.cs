using Microsoft.AspNetCore.Mvc;
using administrador.BussinesLogic.DTOs;
using administrador.Commands.Atomics;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("Asegurado")]
    public class AseguradoController : Controller
    {
        private readonly IAseguradoDAO _aseguradoDAO;
        private readonly ILogger<AseguradoController> _logger;

        public AseguradoController(ILogger<AseguradoController> logger, IAseguradoDAO insuredDAO)
        {
            _aseguradoDAO = insuredDAO;
            _logger = logger;
        }
        
        [HttpPost("Agregar")]
        public ApplicationResponse<string> addInsured([FromBody] AseguradoDTO insured)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                var commandAddInsured = new createInsuredCommand(insured);
                commandAddInsured.Execute();
                response.Data = commandAddInsured.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        [HttpPost("Consultar-Todos")]
        public ApplicationResponse<List<PAseguradoDTO>> getInsuredAll()
        {
            var response = new ApplicationResponse<List<PAseguradoDTO>>();
            try
            {
                var commandGetAllInsured = new getInsuredAllCommand();
                commandGetAllInsured.Execute();
                response.Data = commandGetAllInsured.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        /*Consulta un asegurado por su CI*/
        [HttpPost("Consultar-Asegurado")]
        public ApplicationResponse<PAseguradoDTO> getInsuredSpecific([FromBody] int ci)
        {
            var response = new ApplicationResponse<PAseguradoDTO>();
            try
            {
                var commandGetInsured = new getInsuredCommand(ci);
                commandGetInsured.Execute();
                response.Data = commandGetInsured.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
    }
}