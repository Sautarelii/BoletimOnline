//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Boletim
{
    using System;
    using System.Collections.Generic;
    
    public partial class ATIVIDADE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ATIVIDADE()
        {
            this.ATIVIDADE_PROFMT = new HashSet<ATIVIDADE_PROFMT>();
            this.ALUNO = new HashSet<ALUNO>();
        }
    
        public int COD_ATIVIDADE { get; set; }
        public string NOME_ATIVIDADE { get; set; }
        public System.DateTime DATA_ENTREGA { get; set; }
        public Nullable<byte> TIPO_ATIVIDADE { get; set; }
        public int COD_MATERIA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATIVIDADE_PROFMT> ATIVIDADE_PROFMT { get; set; }
        public virtual MATERIA MATERIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALUNO> ALUNO { get; set; }
    }
}
