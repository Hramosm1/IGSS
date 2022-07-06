using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaSalud
{
    public class PersonaViewModel
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal dpi { get; set; }
        public DateTime fecha { get; set; }
        public string telefono { get; set; }
        public string Salud { get; set; }
        public string Igss { get; set; }

    }
    public class PatronModel
    {
        public int codigo_patron { get; set; }
        public string nombre { get; set; }
    }

    public class ControbucionesModel
    {
        public decimal dpi { get; set; } 
        public int codigo_patron { get; set; }
        public int año { get; set; }
        public int mes { get; set; }
        public string razon { get; set; }
        public string aporte { get; set; }
        public string nombre_patrono { get; set; }
    }
    public class ModelIgss
    {
        public decimal dpi { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public string Telefono { get; set; }
        public int codigo_patron { get; set; }
        public string nombre_patrono { get;set; }
        public int año { get; set; }
        public int mes { get; set; }
        public string razon { get; set; }
        public string aporte { get; set; }

    }
}
