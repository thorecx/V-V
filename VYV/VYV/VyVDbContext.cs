namespace VYV
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VyVDbContext : DbContext
    {
        public VyVDbContext()
            : base("name=VyVDbContext")
        {
        }

        public virtual DbSet<Asignatura> Asignatura { get; set; }
        public virtual DbSet<AsigProfesor> AsigProfesor { get; set; }
        public virtual DbSet<DetalleSeleccion> DetalleSeleccion { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignatura>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<Asignatura>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<AsigProfesor>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<AsigProfesor>()
                .Property(e => e.CodProfesor)
                .IsUnicode(false);

            modelBuilder.Entity<DetalleSeleccion>()
                .Property(e => e.CodEstudiante)
                .IsUnicode(false);

            modelBuilder.Entity<DetalleSeleccion>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<DetalleSeleccion>()
                .Property(e => e.CodProfesor)
                .IsUnicode(false);

            modelBuilder.Entity<DetalleSeleccion>()
                .Property(e => e.CodGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<DetalleSeleccion>()
                .Property(e => e.Estatus)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.CodEstudiante)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Carrera)
                .IsUnicode(false);

            modelBuilder.Entity<Grupo>()
                .Property(e => e.CodGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<Grupo>()
                .Property(e => e.Ubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Grupo>()
                .Property(e => e.Aula)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.CodProfesor)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Epecialidad)
                .IsUnicode(false);
        }
    }
}
