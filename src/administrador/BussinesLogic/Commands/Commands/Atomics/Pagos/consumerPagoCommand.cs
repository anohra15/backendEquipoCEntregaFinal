using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.MQ;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace administrador.Commands.Atomics.Pagos;

public class consumerPagoCommand : Command<PagosDTO>
{
    private PagosDTO _response;
    public consumerPagoCommand()
    {
    }

    public override void Execute()
    {
        AdminMQ dao = AdministradorDAOFactory.createAdminMQ();
        _response = JsonConvert.DeserializeObject<PagosDTO>(dao.Consumer());
    }

    public override PagosDTO GetResult()
    {
        return _response;
    }
}