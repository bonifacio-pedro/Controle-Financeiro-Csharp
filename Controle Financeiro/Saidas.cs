using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Financeiro
{
    public class Saidas
    {
        public string descSaida;
        public double valSaida;
        public DateTime dataSaida;
        public Saidas(string descSaida, double valSaida, DateTime dataSaida)
        {
            this.descSaida = descSaida;
            this.valSaida = valSaida;
            this.dataSaida = dataSaida;
        }
        public Saidas()
        {

        }
    }
}
