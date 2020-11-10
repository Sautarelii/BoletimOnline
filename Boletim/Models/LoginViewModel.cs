using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boletim.Models
{
    public class LoginViewModel
    {

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um e-mail válido")]
        [Required(ErrorMessage = "Informe o E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha ")]
        [DataType(DataType.Password)]
    public string Senha { get; set; }
    }
}