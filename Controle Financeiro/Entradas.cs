using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Controle_Financeiro
{
    public class Entradas
    {
        public string descEntrada;
        public double valorEntrada;
        public Entradas(string descEntrada, double valorEntrada)
        {
            this.descEntrada = descEntrada;
            this.valorEntrada = valorEntrada;
        }
        public Entradas()
        {

        }
    }
}
