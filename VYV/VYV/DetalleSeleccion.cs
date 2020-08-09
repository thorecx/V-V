namespace VYV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleSeleccion")]
    public partial class DetalleSeleccion
    {
        [Key]
        public int CodDetalle { get; set; }

        [StringLength(25)]
        public string CodEstudiante { get; set; }

        [StringLength(25)]
        public string CodAsignatura { get; set; }

        [StringLength(25)]
        public string CodProfesor { get; set; }

        [StringLength(25)]
        public string CodGrupo { get; set; }

        public DateTime? Fecha { get; set; }

        [StringLength(25)]
        public string Estatus { get; set; }

        public virtual Asignatura Asignatura { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}
