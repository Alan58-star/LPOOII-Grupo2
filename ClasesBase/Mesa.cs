using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Mesa : INotifyPropertyChanged
    {
        private int mesa_Id;

        public int Mesa_Id
        {
            get { return mesa_Id; }
            set { mesa_Id = value;
            Notificador("Mesa_Id");
            }
        }
        private int mesa_Posicion;

        public int Mesa_Posicion
        {
            get { return mesa_Posicion; }
            set { mesa_Posicion = value;
            Notificador("Mesa_Posicion");
            }
        }
        private string mesa_Estado;

        public string Mesa_Estado
        {
            get { return mesa_Estado; }
            set { mesa_Estado = value;
            Notificador(Mesa_Estado);
            }
        }
        public Mesa(int mesaId, int posicion, string estado)
        {
            mesa_Id = mesaId;
            mesa_Posicion = posicion;
            mesa_Estado = estado;
         
        }
        public Mesa() { }
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notificador(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
