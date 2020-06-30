using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiASP.Models
{
    public class Libro
    {   
        [Key]
        public long Id { get; set; }
        

        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set;}

        [Column(TypeName = "varchar(50)")]
        public string Autor { get; set; }
    }
}
