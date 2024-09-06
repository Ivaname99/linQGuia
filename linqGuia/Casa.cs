using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqGuia
{
    // Define la clase Casa con sus propiedades
    public class Casa
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int NumeroHabitaciones { get; set; }
        public string dameDatosCasa() // Método que retorna una cadena con información sobre el habitante
        {
            return $"Direcion es {Direccion} en la ciudad de {Ciudad} con numero de habitaciones {NumeroHabitaciones}";
        }
    }
}
