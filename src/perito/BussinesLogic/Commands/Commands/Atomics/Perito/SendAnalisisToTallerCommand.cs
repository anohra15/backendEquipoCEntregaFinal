using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.MQ;

namespace perito.Commands.Atomics.Perito{

    public class SendAnalisisToTallerCommand : Command<AnalisisDTO>
    {
        private readonly AnalisisDTO _analisis;

            public SendAnalisisToTallerCommand(AnalisisDTO analisis)
            {
                _analisis = analisis;
            }

            public override void Execute()
            {
                AnalisisMQ dao = PeritoDAOFactory.createAnalisisMQ();
                dao.Producer(_analisis);
            }

            public override AnalisisDTO GetResult()
            {
                throw new NotImplementedException();
            }
        
    }

}