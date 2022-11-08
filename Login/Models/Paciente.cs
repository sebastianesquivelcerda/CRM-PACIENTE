using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        public int id { get; set; }
        public string rut { get; set; }
        public string nombres { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string direccion { get; set; }
  
        public string sexo { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string movil { get; set; }
        public string mail1  { get; set; }
        public string mail2 { get; set; }
        public string prevision { get; set; }
        public bool seguroSalud { get; set; }
        public Int16 numEnfermedades { get; set; }
        public string situacionLaboral { get; set; }
        public string observaciones { get; set; }
        public string comuna { get; set; }

    }
}
