using System;
using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("Incidentes")]
    public class IncidenteController : Controller
    {
        private readonly IIncidenteDAO _incidenteDAO;
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger, IIncidenteDAO incidenteDAO)
        {
            _incidenteDAO = incidenteDAO;
            _logger = logger;
        }
        
        [HttpPost("Agregar")]
        public ApplicationResponse<string> createAccident([FromBody] IncidentesDTO incidente)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _incidenteDAO.createAccident(incidente);
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        [HttpPost("Consultar")]
        public ApplicationResponse<List<IncidentesSimpleDTO>> getAccident([FromBody] Guid id) 
        {
            var response = new ApplicationResponse<List<IncidentesSimpleDTO>>();
            try
            {
                response.Data = _incidenteDAO.getAccident(id);
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        /*Me elimina un incidente por su ID*/
        [HttpPost("Borrar")]
        public ApplicationResponse<string> deleteAccident([FromBody] Guid id) 
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _incidenteDAO.deleteAccident(id);
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