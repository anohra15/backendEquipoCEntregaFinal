using administrador.BussinesLogic.DTOs;
using administrador.BussinesLogic.Mappers;
using administrador.Commands;
using administrador.Commands.Atomics.IncidentesDAO;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
using Microsoft.AspNetCore.Mvc;
namespace administrador.Controllers.Administrador;

[ApiController]
[Route("Pagos")]
public class PagosController
{
    private readonly IIncidenteDAO _incidenteDAO;
    private readonly ILogger<IncidenteController> _logger;

    public PagosController(ILogger<IncidenteController> logger, IIncidenteDAO incidenteDAO)
    {
        _incidenteDAO = incidenteDAO;
        _logger = logger;
    }
    
    [HttpPost("Consumir")]
    public ApplicationResponse<string> getPay()
    {
        var response = new ApplicationResponse<string>();
        try
        {
           /*// createAccidentCommand commandAddIncident = CommandFactory.createCreateAccidentCommand(entityAcident);
            var entityPago = PagosMapper.mapDtoToEntity(incidente);
            
            commandAddIncident.Execute();
            response.Data = commandAddIncident.GetResult();*/
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