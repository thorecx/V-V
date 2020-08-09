namespace VYV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Asignatura")]
    public partial class Asignatura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asignatura()
        {
            AsigProfesor = new List<AsigProfesor>();
            DetalleSeleccion = new List<DetalleSeleccion>();
        }

        [Key]
        [StringLength(25)]
        public string CodAsignatura { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public int? Cuatrimestre { get; set; }

        public int? Creditos { get; set; }

        public int? Año { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<AsigProfesor> AsigProfesor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<DetalleSeleccion> DetalleSeleccion { get; set; }
    }
}
