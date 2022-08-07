using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Implementations;
using perito.Persistence.DAOs.Interfaces;

namespace perito.Commands.Atomics.Perito
{

    public class InsertAnalisisCommand : Command<AnalisisDTO>
    {
        private readonly AnalisisDTO _analisis;
        private readonly IAnalisisDAO _analisisDAO;
        private AnalisisDTO _result;

        public InsertAnalisisCommand(AnalisisDTO analisis)
        {
            _analisis = analisis;
        }

        public override void Execute()
        {
            AnalisisDAO dao = PeritoDAOFactory.createAnalisisDAO();
            _result = dao.CreateAnalisis(_analisis);
        }

        public override AnalisisDTO GetResult()
        {
            return _result;
        }
    }
}