using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess
{
    public class NoteControlContext : DbContext
    {
        // pasa como parametro al contructor del padre el nombre la cadena de conexion
        // que existe en app.config
        public NoteControlContext() : base("name=NoteControlContext")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Privilegio> Privilegios { get; set; }
        public DbSet<PerfilPrivilegio> PerfilesPrivilegios { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<AsignaturaProfesor> AsignaturaProfesor { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<EspecialidadProfesor> EspecialidadProfesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoAsignatura> CursoAsignaturas { get; set; }
    }
}
