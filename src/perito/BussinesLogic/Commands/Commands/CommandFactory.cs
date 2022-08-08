
using perito.BussinesLogic.DTOs;
using perito.Commands.Atomics.Perito;
using perito.Commands.Composes;
using perito.Persistence.Entities;

namespace perito.Commands
{
    public class CommandFactory
    {
        //Perito
        public static InsertAnalisisCommand createCreateAnalisisCommand(AnalisisEntity analisis)
        {
            return new InsertAnalisisCommand(analisis);
        }
        public static SendAnalisisToTallerCommand createSendAnalisisCommand(Guid response)
        {
            return new SendAnalisisToTallerCommand(response);
        }

        public static InsertPeritoCommand createCreatePeritoCommand(UsuarioPeritoEntity reponse)
        {
            return new InsertPeritoCommand(reponse);
        }
        
        public static InsertPiezaCommand createCreatePiezaCommand(PiezaEntity reponse)
        {
            return new InsertPiezaCommand(reponse);
        }

        public static CreateAnalisisCommand CreateCreateAnalisisCommand(AnalisisEntity response)
        {
            return new CreateAnalisisCommand(response);
        }
        

        /*public static getAnalisisCommand createGetAnalisisCommand(Guid respnse)
        {
            return getAnalisisCommand(respnse);
        }*/
    }
}