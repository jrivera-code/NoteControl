using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using NoteControl.Source.DataAccess.InitialData;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DALogin : IDisposable
    {
        private readonly NoteControlContext _db = new NoteControlContext();
        private Usuario usuarioEncontrado;
        
        public Usuario getUser()
        {
           
            return this.usuarioEncontrado;
        }
        public bool userExist(string userName, string password) {
           var usuario = from user in _db.Usuarios
                           where (user.Nombre == userName
                           && user.Clave == password)
                           select user;
            if (usuario.Count() != 0) {
                usuarioEncontrado = usuario.First();
                return true;
            }
            else{
                return false;
            }
        }

        public void CreateDataBase()
        {
            Data initialData = new Data();
            Curso curso = new Curso() { CursoCode = "A10", Nombre = "Primero Basico", Descripcion = "Conocimiento de sí mismo e ingreso al mundo de la lectura y escritura" };
            _db.Cursos.Add(curso);
            for (int i = 0; i < initialData.NombresAlum.Length; i++)
            {
                Alumno alum = new Alumno() { Rut = initialData.RutAlum[i], Nombre = initialData.NombresAlum[i], Apellido = initialData.ApellidosAlum[i], Curso = curso };
                _db.Alumnos.Add(alum);
                _db.SaveChanges();
            }
            Perfil perfil = new Perfil() { Nombre = "Administrador" };
            _db.Perfiles.Add(perfil);
            for (int i = 0; i < initialData.privilegios.Length; i++)
            {
                Privilegio privilegio = new Privilegio() { Nombre = initialData.privilegios[i] };
                _db.Privilegios.Add(privilegio);
                _db.SaveChanges();
                _db.PerfilesPrivilegios.Add(new PerfilPrivilegio() { PrivilegioId = i + 1, PerfilId = 1 });
            }
            for (int i = 0; i < initialData.ProfesoresNombre.Length; i++)
            {
                Profesor profe = new Profesor() { Rut = initialData.RutProfesor[i], Nombre = initialData.ProfesoresNombre[i],Apellido =
                    initialData.ProfesoresApellido[i]};
                _db.Profesores.Add(profe);
                _db.SaveChanges();
            }
            for (int i = 0; i < initialData.asignaturas.Length; i++)
            {
                Asignatura asig = new Asignatura() { AsignaturaCode = i.ToString(), Nombre = initialData.asignaturas[i] };
                _db.Asignaturas.Add(asig);
                _db.SaveChanges();
            }
            _db.Usuarios.Add(new Usuario() { Nombre = "JMOLINA", Clave = "1234", Estado = 1, Perfiles = perfil });
            _db.SaveChanges();
        }

        public bool DataBaseExist()
        {
            return _db.Database.Exists();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
