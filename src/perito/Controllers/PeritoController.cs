using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using perito.BussinesLogic.DTOs;
using perito.Exceptions;
using perito.Persistence.DAOs.Interfaces;
using perito.Responses;

namespace perito.Controllers.Perito
{
    [ApiController]
    [Route("perito")]
    public class PeritoController : Controller
    {
        private readonly IPeritoDAO _peritoDAO;
        private readonly ILogger<PeritoController> _logger;

        public PeritoController(ILogger<PeritoController> logger, IPeritoDAO peritoDAO, IDireccionDAO direccionDao, IPiezaDAO piezaDAO, IAnalisisDAO analisisDAO)
        {
            _peritoDAO = peritoDAO;
            _logger = logger;

        }

        [HttpPost("create/perito")]
        public ApplicationResponse<PeritoDTO> createPerito([Required][FromBody] PeritoDTO peritoDTO)
        {
            var response = new ApplicationResponse<PeritoDTO>();
            try
            {
                //response.DataInsert = _peritoDAO.CreatePerito(peritoDTO);
                response.Message = "se registro exitosamente";
                response.Data = peritoDTO;
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        

        [HttpPut("actualizar/perito/{id_perito}")]
        public ApplicationResponse<PeritoDTO> editarPerito([Required][FromBody]PeritoDTO peritoCambios,[Required][FromRoute]Guid id_perito)
        {
            var ressponse = new ApplicationResponse<PeritoDTO>();
            try
            {
               // ressponse.DataInsert = _peritoDAO.ActualizarPerito(peritoCambios,id_perito);
                ressponse.Message = "se edito exitosamente el perito de id="+id_perito;
                ressponse.Data = null;
            }
            catch (RCVExceptions ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Mensaje;
            }
            return ressponse;
        }
        
        [HttpDelete("eliminar/perito/{id_perito}")]
        public ApplicationResponse<PeritoDTO> eliminarPerito([Required][FromRoute]Guid id_perito)
        {
            var ressponse = new ApplicationResponse<PeritoDTO>();
            try
            {
               // ressponse.DataInsert = _peritoDAO.EliminarPerito(id_perito);
                ressponse.Message = "se elimino exitosamente el perito de id="+id_perito;
                ressponse.Data = null;
            }
            catch (RCVExceptions ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Mensaje;
            }
            return ressponse;
        }
        
    }
}