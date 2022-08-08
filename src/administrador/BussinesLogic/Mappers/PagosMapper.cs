using administrador.BussinesLogic.DTOs;
using administrador.Persistence.Entities;

namespace administrador.BussinesLogic.Mappers;

public class PagosMapper
{
    public static PagosEntity mapDtoToEntity(PagosDTO dto)
    {
        var entity = new PagosEntity
        {
            AnalisisEntityId = dto.idAnalisis,
            UserEntityId = dto.idTaller,
            fechaInicio = dto.fechaInicio,
            fechaFin = dto.fechaFin,
            costo = dto.costo,
        };
        return entity;
    }
}