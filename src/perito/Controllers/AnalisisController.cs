using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using perito.BussinesLogic.DTOs;
using perito.Commands;
using perito.Commands.Atomics.Perito;
using perito.Exceptions;
using perito.Persistence.DAOs.Interfaces;
using perito.Responses;

namespace perito.Controllers.Perito
{
    [ApiController]
    [Route("analisis")]
public class AnalisisController : Controller
{
        private readonly IAnalisisDAO _analisisDAO;
        private readonly ILogger<AnalisisController> _logger;

        public AnalisisController(ILogger<AnalisisController> logger, IAnalisisDAO analisisDAO)
        {
            _logger = logger;
            _analisisDAO = analisisDAO;

        }

     
        
        [HttpDelete("eliminar/analisis/{id_analisis}")]
        public ApplicationResponse<AnalisisDTO> eliminarAnalisis([Required][FromRoute]Guid id_analisis)
        {
            var ressponse = new ApplicationResponse<AnalisisDTO>();
            try
            {
               // ressponse.DataInsert = _analisisDAO.EliminarAnalisis(id_analisis);
                ressponse.Message = "se elimino exitosamente el analisis de id="+id_analisis;
                ressponse.Data = null;
            }
            catch (RCVExceptions ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Mensaje;
            }
            return ressponse;
        }
        
        [HttpPut("actualizar/analisis/{id_analisis}")]
        public ApplicationResponse<AnalisisDTO> editarAnalisis([Required][FromBody]AnalisisDTO analisisCambios,[Required][FromRoute]Guid id_analisis)
        {
            var ressponse = new ApplicationResponse<AnalisisDTO>();
            try
            {
               // ressponse.DataInsert = _analisisDAO.ActualizarAnalisis(analisisCambios,id_analisis);
                ressponse.Message = "se edito exitosamente el analisis de id="+id_analisis;
                ressponse.Data = null;
            }
            catch (RCVExceptions ex)
            {
                ressponse.Success = false;
                ressponse.Message = ex.Mensaje;
            }
            return ressponse;
        }
        
       
        
        [HttpPost("create/analisis")]

        public ApplicationResponse<AnalisisDTO> createAnalisis([Required][FromBody] AnalisisDTO analisisDTO)
        {
            var response = new ApplicationResponse<AnalisisDTO>();
            try
            {
               // response.DataInsert = _analisisDAO.CreateAnalisis(analisisDTO);
               InsertAnalisisCommand command = CommandFactory.createCreateAnalisisCommand(analisisDTO);
               command.Execute(); 
               response.Message = "se registro exitosamente";
               response.Data = analisisDTO;
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

       
    }
}