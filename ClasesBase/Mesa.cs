using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Mesa
    {
        private int mesa_Id;

        public int Mesa_Id
        {
            get { return mesa_Id; }
            set { mesa_Id = value; }
        }
        private int mesa_Posicion;

        public int Mesa_Posicion
        {
            get { return mesa_Posicion; }
            set { mesa_Posicion = value; }
        }
        private string mesa_Estado;

        public string Mesa_Estado
        {
            get { return mesa_Estado; }
            set { mesa_Estado = value; }
        }
    }
}
