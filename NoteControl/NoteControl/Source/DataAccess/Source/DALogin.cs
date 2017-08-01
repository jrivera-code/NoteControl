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
        private Usuario _usuarioEncontrado;
        
        public Usuario GetUser()
        {
            return this._usuarioEncontrado;
        }
        public bool UserExist(string userName, string password) {
           var usuario = from user in _db.Usuarios
                           where (user.Nombre == userName
                           && user.Clave == password)
                           select user;
            if (usuario.Count() != 0) {
                _usuarioEncontrado = usuario.First();
                return true;
            }
            else{
                return false;
            }
        }

        public void CreateDataBase()
        {
            Data initialData = new Data();
            for (int i = 0; i < initialData.ProfesoresNombre.Length; i++)
            {
                Profesor profe = new Profesor()
                {
                    Rut = initialData.RutProfesor[i],
                    Nombre = initialData.ProfesoresNombre[i],
                    Apellido =
                    initialData.ProfesoresApellido[i]
                };
                _db.Profesores.Add(profe);
                _db.SaveChanges();
            }
            for (int i = 0; i < initialData.curso.Length; i++) {
                if (i < 5)
                {
                    Curso curso = new Curso()
                    {
                        CursoCode = "A" + i,
                        Nombre = initialData.curso[i],
                        Descripcion = "Descripcion del curso",
                        Profesor = _db.Profesores.Local.ElementAt(i),
                        Anio = 2017
                    };
                    _db.Cursos.Add(curso);
                }
                else {
                    Curso curso = new Curso()
                    {
                        CursoCode = "A" + i,
                        Nombre = initialData.curso[i],
                        Descripcion = "Descripcion del curso",
                        Profesor = _db.Profesores.Local.ElementAt(i),
                        Anio = 2017
                    };
                    _db.Cursos.Add(curso);
                }
                _db.SaveChanges();
            }
            
           
            for (int i = 0; i < initialData.NombresAlum.Length; i++)
            {
                if (i < 5)
                {
                    Alumno alum = new Alumno()
                    {
                        Rut = initialData.RutAlum[i],
                        Nombre = initialData.NombresAlum[i],
                        Apellido = initialData.ApellidosAlum[i],
                        Curso = _db.Cursos.Where(e => e.CursoCode == "A0").FirstOrDefault()
                    };
                    _db.Alumnos.Add(alum);
                }
                else {
                    Alumno alum = new Alumno()
                    {
                        Rut = initialData.RutAlum[i],
                        Nombre = initialData.NombresAlum[i],
                        Apellido = initialData.ApellidosAlum[i],
                        Curso = _db.Cursos.Where(e => e.CursoCode == "A1").FirstOrDefault()
                    };
                    _db.Alumnos.Add(alum);
                }
                
                _db.SaveChanges();
            }
            Perfil perfiladmin = new Perfil() { Nombre = "Administrador" };
            _db.Perfiles.Add(perfiladmin);
            Perfil perfilprofe = new Perfil() { Nombre = "Profesor" };
            _db.Perfiles.Add(perfilprofe);
            Perfil perfilsecretaria = new Perfil() { Nombre = "Secretaria" };
            _db.Perfiles.Add(perfilsecretaria);
            for (int i = 0; i < initialData.privilegios.Length; i++)
            {
                Privilegio privilegio = new Privilegio() { Nombre = initialData.privilegios[i] };
                _db.Privilegios.Add(privilegio);
                _db.SaveChanges();
                _db.PerfilesPrivilegios.Add(new PerfilPrivilegio() { PrivilegioId = i + 1, PerfilId = 1 });
                if (i == 5)
                { //add privilegio profesor y secretaria
                    _db.PerfilesPrivilegios.Add(new PerfilPrivilegio() { PrivilegioId = i, PerfilId = 2 });
                    _db.PerfilesPrivilegios.Add(new PerfilPrivilegio() { PrivilegioId = i, PerfilId = 3 });
                }
            }
           
           
            for (int i = 0; i < initialData.asignaturas.Length; i++)
            {
                Asignatura asig = new Asignatura() { AsignaturaCode = i.ToString(), Nombre = initialData.asignaturas[i] };
                _db.Asignaturas.Add(asig);
                _db.SaveChanges();
            }
            _db.Usuarios.Add(new Usuario() {Rut = 181404858, Nombre = "JMOLINA", Clave = "1234",Telefono = "123456",
                Email = "jmolina@gmail.com", Estado = 1, Perfiles = perfiladmin });
            _db.Usuarios.Add(new Usuario()
            {
                Rut = 181303859,
                Nombre = "JRIVERA",
                Clave = "1234",
                Telefono = "123456",
                Email = "jrivera@gmail.com",
                Estado = 1,
                Perfiles = perfilprofe
            });
            _db.Usuarios.Add(new Usuario()
            {
                Rut = 112342342,
                Nombre = "IPETERS",
                Clave = "1234",
                Telefono = "123456",
                Email = "ipeters@gmail.com",
                Estado = 1,
                Perfiles = perfilprofe
            });
            _db.SaveChanges();
            for (int i = 0; i < 8; i++) {
                int asig = i + 1;
                if (i < 5)
                {
                    CursoProfeAsignatura cpa = new CursoProfeAsignatura()
                    {
                        Profesores = _db.Profesores.Where(e => e.Rut == 181303859).FirstOrDefault(),
                        Asignaturas = _db.Asignaturas.Where(e => e.AsignaturaCode == asig.ToString()).FirstOrDefault(),
                        Cursos = _db.Cursos.Where(e => e.CursoCode == "A0").FirstOrDefault()
                    };
                    _db.CursoProfeAsignaturas.Add(cpa);

                }
                else {
                    
                    CursoProfeAsignatura cpa = new CursoProfeAsignatura()
                    {
                        Profesores = _db.Profesores.Where(e => e.Rut == 112342342).FirstOrDefault(),
                        Asignaturas = _db.Asignaturas.Where(e => e.AsignaturaCode == asig.ToString()).FirstOrDefault(),
                        Cursos = _db.Cursos.Where(e => e.CursoCode == "A1").FirstOrDefault()
                    };
                    _db.CursoProfeAsignaturas.Add(cpa);
                }
                _db.SaveChanges();
            }
            
           
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
