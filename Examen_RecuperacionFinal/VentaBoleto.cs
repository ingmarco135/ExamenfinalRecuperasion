using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_RecuperacionFinal
{
    public class VentaBoleto
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public int RutaTuristicaID { get; set; }
        public int CantidadPersonas { get; set; }
        public double MontoTotal { get; set; }
    }
}
