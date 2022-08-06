﻿using System;
using administrador.BussinesLogic.DTOs;
using administrador.Commands.Atomics;
using administrador.Commands.Atomics.IncidentesDAO;
using administrador.Commands.Atomics.MarcaDAO;
using administrador.Commands.Atomics.MarcasDAO;
using administrador.Commands.Atomics.PolizasDAO;

namespace administrador.Commands
{
    public class CommandFactory
    {
        //Asegurado
        public static createInsuredCommand createCreateInsuredCommand(AseguradoDTO insured)
        {
            return new createInsuredCommand(insured);
        }
        
        public static getInsuredCommand createGetInsuredCommand(int ci)
        {
            return new getInsuredCommand(ci);
        }
        
        public static getInsuredAllCommand createGetInsuredAllCommand()
        {
            return new getInsuredAllCommand();
        }
        public static sendInsuredCommand createSendInsuredCommand(string response)
        {
            return new sendInsuredCommand(response);
        }
        //Carro
        public static createCarCommand createCreateCarCommand(CarroDTO carro)
        {
            return new createCarCommand(carro);
        }
        public static getCarCommand createGetCarCommand(string placa)
        {
            return new getCarCommand(placa);
        }
        //Incident
        public static createAccidentCommand createCreateAccidentCommand(IncidentesDTO incident)
        {
            return new createAccidentCommand(incident);
        }
        public static deleteAccidentCommand createDeleteAccidentCommand(Guid id)
        {
            return new deleteAccidentCommand(id);
        }
        public static getAccidentCommand createGetAccidentCommand(Guid id)
        {
            return new getAccidentCommand(id);
        }
        //Marcas
        public static createMarcaCommand createCreateMarcaCommand(string marca)
        {
            return new createMarcaCommand(marca);
        }
        public static getMarcaCommand createGetMarcaCommand(string marca)
        {
            return new getMarcaCommand(marca);
        }
        //Polizas
        public static createPolizaCommand createCreatePolizaCommand(PolizaSimpleDTO poliza)
        {
            return new createPolizaCommand(poliza);
        }
        public static deletePolizaCommand createDeletePolizaCommand(Guid poliza)
        {
            return new deletePolizaCommand(poliza);
        }
        public static getPolizaInsuredCommand createGetPolizaInsuredCommand(int ci)
        {
            return new getPolizaInsuredCommand(ci);
        }
    }
}