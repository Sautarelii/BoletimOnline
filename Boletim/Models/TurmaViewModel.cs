using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boletim.Models
{
    public class TurmaViewModel
    {

        [Key]
        [HiddenInput(DisplayValue = false)]
        public int TurmaId { get; set; }
        [Required(ErrorMessage = "Informe a Turma")]
        [StringLength(100)]
        [System.Web.Mvc.Remote("VerificaTurma", "TURMA", ErrorMessage = "Turma já cadastrada")]
        public int SERIE { get; set; }
        [Required(ErrorMessage = "Informe o periodo letivo")]
        [StringLength(100)]
        public int PERIODO_LET { get; set; }
    }
}