using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DAPerfilPrivilegio
    {
        private readonly NoteControlContext _db = new NoteControlContext();

        //metodo para agregar un nuevo perfil
        public void crearRelacionPerfilPrivilegio(Perfil perfil ,int indexPrivilegio)
        {
            PerfilPrivilegio perfilprivilegio = new PerfilPrivilegio();
            perfilprivilegio.PerfilId = perfil.PerfilId;
            perfilprivilegio.PrivilegioId = indexPrivilegio;
            _db.PerfilesPrivilegios.Add(perfilprivilegio);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
