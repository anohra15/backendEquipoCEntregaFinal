using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using perito.BussinesLogic.DTOs;
using perito.BussinesLogic.Mappers;
using perito.Commands;
using perito.Commands.Atomics.Perito;
using perito.Commands.Composes;
using perito.Exceptions;
using perito.Persistence.DAOs.Interfaces;
using perito.Responses;

namespace perito.Controllers.Perito
{
    [ApiController]
    [Route("analisis")]
public class AnalisisController : Controller
{
        private readonly ILogger<AnalisisController> _logger;

        public AnalisisController(ILogger<AnalisisController> logger)
        {
            this._logger = logger;
        }

     /*
        
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
        */
       
        
        [HttpPost("create/analisis")]

        public string createAnalisis([Required][FromBody] AnalisisDTO analisisDTO)
        {
            try
            {
                var analisisEntidad = AnalisisMapper.MapDtoToEntity(analisisDTO);
               
               CreateAnalisisCommand command = CommandFactory.CreateCreateAnalisisCommand(analisisEntidad);
               command.Execute(); 
               Console.WriteLine(command.GetResult());
               return "exito";
            }
            catch (RCVExceptions ex)
            {
                return  ex.Message;
            }

        }
        
        [HttpPost("Consultar-analisis")]
        public ApplicationResponse<AnalisisDTO> getAnalisis([FromBody] Guid id)
        {
            var response = new ApplicationResponse<AnalisisDTO>();
            try
            {
                var commandGetAnalisis = new getAnalisisCommand(id);
                commandGetAnalisis.Execute();
                response.Data = commandGetAnalisis.GetResult();
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