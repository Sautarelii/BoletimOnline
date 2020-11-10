using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boletim.Models
{
    public class MateriaViewModel
    {
        public int COD_MATERIA { get; set; }
        [Required(ErrorMessage = "Informe a materia")]
        public string NOME { get; set; }
    }
}