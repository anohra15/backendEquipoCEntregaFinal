using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using administrador.BussinesLogic.DTOs;
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
                response.Data = _aseguradoDAO.createInsured(insured);
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
                response.Data = _aseguradoDAO.getInsured();
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
                response.Data = _aseguradoDAO.getInsured(ci);
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