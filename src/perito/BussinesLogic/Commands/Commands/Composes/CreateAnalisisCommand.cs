using perito.BussinesLogic.DTOs;
using perito.Commands;
using perito.Commands.Atomics.Perito;

namespace perito.Commands.Composes

{

    public class CreateAnalisisCommand : Command<AnalisisDTO>
    {
        private readonly AnalisisDTO _analisis;
        private AnalisisDTO _result;

        public CreateAnalisisCommand(AnalisisDTO analisis)
        {
            _analisis = analisis;
        }

        public override void Execute()
        {
            InsertAnalisisCommand command = CommandFactory.createCreateAnalisisCommand(_analisis);
            command.Execute();
        }

        public override AnalisisDTO GetResult()
        {
            return _result;
        }
    }
}