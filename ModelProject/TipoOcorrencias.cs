//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoOcorrencias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoOcorrencias()
        {
            this.Ocorrencias = new HashSet<Ocorrencias>();
        }
    
        public int ID { get; set; }
        public string Designacao { get; set; }
        public Nullable<int> PermissoesUtilizador { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ocorrencias> Ocorrencias { get; set; }
        public virtual TipoUtilizador TipoUtilizador { get; set; }
    }
}
