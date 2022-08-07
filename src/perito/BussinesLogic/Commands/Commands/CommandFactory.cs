
using perito.BussinesLogic.DTOs;
using perito.Commands.Atomics.Perito;

namespace perito.Commands
{
    public class CommandFactory
    {
        //Perito
        public static InsertAnalisisCommand createCreateAnalisisCommand(AnalisisDTO analisis)
        {
            return new InsertAnalisisCommand(analisis);
        }
        public static SendAnalisisToTallerCommand createSendPeritoCommand(AnalisisDTO analisis)
        {
            return new SendAnalisisToTallerCommand(analisis);
        }
    }
}