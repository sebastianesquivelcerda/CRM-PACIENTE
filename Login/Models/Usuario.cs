using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre debe contener maximo 50 caracteres")]
        public string? nombre { get; set; }

        
        public string? password { get; set; }

        public bool? externo { get; set; }
        [StringLength(30, ErrorMessage = "El anexo debe contener maximo 10 digitos")]
        public string? anexo { get; set; }

       
        [MinLength(9, ErrorMessage = "El rut debe contener entre 8 y 9 digitos")]
        [MaxLength(10,ErrorMessage ="El rut debe contener entre 8 y 9 digitos")]
        public string? rut { get; set; }
        [StringLength(64 , ErrorMessage = "El email debe contener maximo 64 caracteres")]
        public string? email { get; set; }

        public bool estado { get; set; }

        public int usuario_intentoLogin { get; set; }

        public bool usuario_bloqueado { get; set; }

        public bool usuario_cambiaPassword { get; set; }

        public bool usuario_resetPassword { get; set; }


    }
}
