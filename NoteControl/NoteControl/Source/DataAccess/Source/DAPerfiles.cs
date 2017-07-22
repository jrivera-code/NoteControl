using NoteControl.Source.DataAccess.Interfaces;
using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
   public class DAPerfiles : IDAPerfiles
    {
        private readonly NoteControlContext _db = new NoteControlContext();

        //metodo para agregar un nuevo perfil
        public void crearPerfil(Perfil perfil) {
            _db.Perfiles.Add(perfil);
            _db.SaveChanges();
        }

        //metodo para listar todos los perfil
        public List<Perfil> listarPerfiles()
        {
            List<Perfil> lista = _db.Perfiles.ToList();
            return lista;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
