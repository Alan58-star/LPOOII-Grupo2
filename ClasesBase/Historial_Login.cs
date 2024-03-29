﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Historial_Login
    {
        private int log_Id;

        public int Log_Id
        {
            get { return log_Id; }
            set { log_Id = value; }
        }
        private int usr_Id;

        public int Usr_Id
        {
            get { return usr_Id; }
            set { usr_Id = value; }
        }
        private DateTime log_Fecha_Hora;

        public DateTime Log_Fecha_Hora
        {
            get { return log_Fecha_Hora; }
            set { log_Fecha_Hora = value; }
        }
        private string log_Descrip;

        public string Log_Descrip
        {
            get { return log_Descrip; }
            set { log_Descrip = value; }
        }

        private Usuario usuario;
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value;}
        }

        public Historial_Login() { }

        public Historial_Login(int logId, DateTime fechaHora, string descrip, int usuId)
        {
            log_Id = logId;
            log_Fecha_Hora = fechaHora;
            log_Descrip = descrip;
            usr_Id = usuId;

        }

        public Historial_Login(int logId, DateTime fechaHora, string descrip, int usuId, Usuario usu)
        {
            log_Id = logId;
            log_Fecha_Hora = fechaHora;
            log_Descrip = descrip;
            usr_Id = usuId;
            usuario = usu;
        }
    }
}
