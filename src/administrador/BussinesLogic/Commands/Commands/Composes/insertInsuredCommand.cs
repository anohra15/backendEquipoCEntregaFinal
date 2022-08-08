using administrador.BussinesLogic.DTOs;
using administrador.Commands.Atomics;

namespace administrador.Commands.Composes
{
    public class insertInsuredCommand : Command<string>
    {
        private readonly AseguradoDTO _insured;
        private string _result;

        public insertInsuredCommand(AseguradoDTO insured)
        {
            _insured = insured;
        }

        public override void Execute()
        {
            createInsuredCommand commandCreate = CommandFactory.createCreateInsuredCommand(_insured);
            commandCreate.Execute();
            _result = commandCreate.GetResult();
            sendInsuredCommand commandSend = CommandFactory.createSendInsuredCommand(_result);
            commandSend.Execute();

        }

        public override string GetResult()
        {
            return _result;
        }
    }
}