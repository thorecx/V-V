namespace VYV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AsigProfesor")]
    public partial class AsigProfesor
    {
        [Key]
        public int CodAsigProf { get; set; }

        [StringLength(25)]
        public string CodAsignatura { get; set; }

        [StringLength(25)]
        public string CodProfesor { get; set; }

        public DateTime? Fecha { get; set; }

        public virtual Asignatura Asignatura { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}
