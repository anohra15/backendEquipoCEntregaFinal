﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using administrador.BussinesLogic.DTOs;
using administrador.Commands.Atomics.PolizasDAO;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("Poliza")]
    public class PolizaController : Controller
    {
        private readonly IPolizaDAO _polizaDAO;
        private readonly ILogger<PolizaController> _logger;

        public PolizaController(ILogger<PolizaController> logger, IPolizaDAO polizaDAO)
        {
            _polizaDAO = polizaDAO;
            _logger = logger;
        }
        
        [HttpPost("Agregar")]
        public ApplicationResponse<string> addPolicy([FromBody] PolizaSimpleDTO policy)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                var commandAddPolicy = new createPolizaCommand(policy);
                commandAddPolicy.Execute();
                response.Data = commandAddPolicy.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        [HttpPost("Eliminar")]
        public ApplicationResponse<Task<bool>> deletePolicy([FromBody] Guid policy)
        {
            var response = new ApplicationResponse<Task<bool>>();
            try
            {
                var commandDeletePolicy = new deletePolizaCommand(policy);
                commandDeletePolicy.Execute();
                response.Data = commandDeletePolicy.GetResult();
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        
        /*Me trae una poliza por su CI*/
        [HttpPost("Consultar")] //cambiar
        public ApplicationResponse<List<PolizaAseguradoDTO>> getPolicy([FromBody] int ci)
        {
            var response = new ApplicationResponse<List<PolizaAseguradoDTO>>();
            try
            {
                var commandGetPolicy = new getPolizaInsuredCommand(ci);
                commandGetPolicy.Execute();
                response.Data = commandGetPolicy.GetResult();
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
