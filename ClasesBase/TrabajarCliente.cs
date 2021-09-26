using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class TrabajarCliente
    {
        public Cliente TraerCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.Cli_Apellido = "";
            oCliente.Cli_Nombre = "";
            oCliente.Cli_Telefono = "";
            return oCliente;
        }
    }
}
