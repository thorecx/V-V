namespace VYV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grupo")]
    public partial class Grupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grupo()
        {
            DetalleSeleccion = new List<DetalleSeleccion>();
        }

        [Key]
        [StringLength(25)]
        public string CodGrupo { get; set; }

        [StringLength(25)]
        public string Ubicacion { get; set; }

        [StringLength(25)]
        public string Aula { get; set; }

        public DateTime? Fecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<DetalleSeleccion> DetalleSeleccion { get; set; }
    }
}
