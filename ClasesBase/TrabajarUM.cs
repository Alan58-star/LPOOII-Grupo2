using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class TrabajarUM
    {
        public Unidad_Medida TraerUM()
        {
            Unidad_Medida oUnidad_Medida = new Unidad_Medida();
            oUnidad_Medida.Um_Descrip = "";
            oUnidad_Medida.Um_Abrev = "";
            return oUnidad_Medida;
        }
    }
}
