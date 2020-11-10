using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletim.Models
{
    public class Atividade_ProfmtViewModel
    {
        public int COD_ATIVIDADE { get; set; }
        public string NOME_ATIVIDADE { get; set; }
        public System.DateTime DATA_ENTREGA { get; set; }
        public Nullable<byte> TIPO_ATIVIDADE { get; set; }
        public int COD_PROF { get; set; }
        public int COD_MATERIA { get; set; }
        public int COD_TURMA { get; set; }
        public int PERIODO_LETIVO { get; set; }

    }
}