using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics
{
    public class createInsuredCommand : Command<string>
    {
        private readonly AseguradoDTO _insured;
        private string _result;
        
        public createInsuredCommand(AseguradoDTO insured)
        {
            _insured = insured;
        }
        
        public override void Execute()
        {
            AseguradoDAO dao = AdministradorDAOFactory.createAseguradoDAO();
            _result = dao.createInsured(_insured);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}