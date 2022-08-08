using System;
using System.Collections.Generic;
using administrador.BussinesLogic.DTOs;
using administrador.Persistence.DAOs.Implementations;

namespace administrador.Commands.Atomics.PolizasDAO
{
    public class createPolizaCommand : Command<string>
    {
        private readonly PolizaSimpleDTO _poliza;
        private string _result;
            
        public createPolizaCommand(PolizaSimpleDTO poliza)
        {
            _poliza = poliza;
        }
            
        public override void Execute()
        {
            PolizaDAO dao = AdministradorDAOFactory.CreatePolizaDAO();
            _result = dao.createPoliza(_poliza);
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}