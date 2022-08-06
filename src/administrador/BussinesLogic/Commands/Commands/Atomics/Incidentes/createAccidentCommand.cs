using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics.IncidentesDAO
{
    public class createAccidentCommand : Command<string>
    {
        private readonly IncidentesDTO _incidentes;
        private string _result;
        
        public createAccidentCommand(IncidentesDTO incidentes)
        {
            _incidentes = incidentes;
        }
        
        public override void Execute()
        {
            IncidenteDAO dao = AdministradorDAOFactory.CreateIncidenteDAO();
            _result = dao.createAccident(_incidentes);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}