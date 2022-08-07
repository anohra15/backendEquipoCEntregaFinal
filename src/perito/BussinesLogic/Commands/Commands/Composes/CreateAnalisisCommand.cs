using perito.BussinesLogic.DTOs;
using perito.Commands;
using perito.Commands.Atomics.Perito;
using perito.Persistence.Entities;

namespace perito.Commands.Composes

{

    public class CreateAnalisisCommand : Command<string>
    {
        private readonly AnalisisEntity _analisis;
        private readonly AnalisisDTO _analisis2;
        private string _result;

        public CreateAnalisisCommand(AnalisisEntity analisis)
        {
            _analisis = analisis;
        }

        public override void Execute()
        {
            InsertAnalisisCommand command = CommandFactory.createCreateAnalisisCommand(_analisis2);
            command.Execute();
            SendAnalisisToTallerCommand command2 = CommandFactory.createSendPeritoCommand(_analisis.Id);
            command2.Execute();
        }

        public override string GetResult()
        {
            return _result;
        }
    }
}