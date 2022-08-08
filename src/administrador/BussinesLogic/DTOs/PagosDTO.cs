namespace administrador.BussinesLogic.DTOs;

public class PagosDTO
{
    public Guid idAnalisis {get; set;}
    public Guid idTaller {get; set;}
    public DateTime fechaInicio {get; set;}
    public DateTime fechaFin {get; set;}
    public int costo {get; set;}
}