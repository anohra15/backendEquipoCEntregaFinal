using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using perito.BussinesLogic.DTOs;
using perito.Persistence.DAOs.Interfaces;
using perito.Persistence.Database;
using perito.Persistence.Entities;

namespace perito.Persistence.DAOs.Implementations
{
    public class AnalisisDAO:IAnalisisDAO
    {
       // public readonly IRCVDbContext _context;
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IRCVDbContext _context = desing.CreateDbContext(null);
        public AnalisisEntity Analisis = new AnalisisEntity();
        public int error = 0;
        public string mensajeError = "Ocurrio un error inesperado";
        public ICollection<PiezaEntity> listapiezas = new List<PiezaEntity>();

        public AnalisisDAO(){}
        public AnalisisDAO(IRCVDbContext context)
        {
            _context = context;
        }
        
        public bool validarEspaciosBlancos(string texto)
        {
            var cantidad_espacios = 0;
            foreach (var caracter in texto)
            {
                if (caracter.Equals(' '))
                {
                    cantidad_espacios++;
                    Console.WriteLine(caracter); 
                }
            }

            if (cantidad_espacios == texto.Length)
            {
                return true;
            }

            return false;
        }
        
        public void crearAnalisisEntity(AnalisisDTO P)
        {
            this.Analisis.piezas = listapiezas;
            this.Analisis.id_incidente = P.id_incidente;
            this.Analisis.id_perito = P.id_perito;
            this.Analisis.culpable = P.culpable;
            this.Analisis.CreatedAt = DateTime.Now;
            this.Analisis.UpdatedAt = null;
            this.Analisis.CreatedBy = null;
            this.Analisis.UpdatedBy = null;
        }
        
        
        public AnalisisDTO CreateAnalisis(AnalisisDTO analisisnew)
        {
            var i = 0;
            crearAnalisisEntity(analisisnew);
            var data = _context.analisis.Add(this.Analisis);
            i = _context.DbContext.SaveChanges();
            /*var dataRespuesta = _context.analisis.Include(analisis=>analisis).Where(analisis => analisis.Id.Equals(analisisnew.Id))
                .Select(analisis => new AnalisisDTO
                {
                    id_carro = analisis.id_carro,
                    id_incidente = analisis.id_incidente,
                    id_perito = analisis.id_perito,
                    piezas = listapiezas,
                    culpable = analisis.culpable
                });*/
            return analisisnew;
        }
       
        
        public AnalisisEntity traerAnalisis(IRCVDbContext context,Guid id_analisis)
        {
            if (context.analisis.Any(x => x.Id == id_analisis ))
            {
                var analisis1 = context.analisis.
                    Where(b => b.Id==id_analisis).
                    Single();
                return analisis1;
            }
            return null;
        }
        
        public string EliminarAnalisis(Guid id_analisis)
        {
            var i=0;
            
                var data =traerAnalisis(_context,id_analisis);
               
                    var a=_context.analisis.Remove(data);
                    i=_context.DbContext.SaveChanges();   
                
   
            
            return "Se Elimino correctamente";
        }
        
         /* public AnalisisDTO ActualizarAnalisis(AnalisisEntity analisisCambios,Guid id_analisis)
        {
            
                var data =traerAnalisis(_context,id_analisis);
               
                    
                            data.id_carro = analisisCambios.id_carro;   
                       
                    
                            data.id_incidente = analisisCambios.id_incidente;
                      
                            data.id_perito = analisisCambios.id_perito;   
                      
                            data.piezas = analisisCambios.piezas;
                            data.culpable = analisisCambios.culpable;
                        


                    _context.analisis.Update(data);
                    _context.DbContext.SaveChanges();   
                
   
            
            return _context.analisis.Where(x=>x.Id==data.Id).Select(x=>new AnalisisDTO
            {
                id_carro = x.id_carro,
                id_incidente = x.id_incidente,
                id_perito = x.id_perito,
                piezas = listapiezas,
                culpable = x.culpable
                
            }).Single();;
        }
    */      
    }
}