using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DAPrivilegiosExtra
    {
        private readonly NoteControlContext _db = new NoteControlContext();

        public DAPrivilegiosExtra()
        {

        }
        public void CrearRelacionUsuarioPrivilegioExtras(Usuario user, int indexPrivilegio)
        {
            PrivilegioExtra privilegiosExtra = new PrivilegioExtra();
            privilegiosExtra.Usuario.Rut = user.Rut;
            privilegiosExtra.PrivilegioId = indexPrivilegio;
            _db.PrivilegioExtras.Add(privilegiosExtra);
            _db.SaveChanges();
        }
        public List<PrivilegioExtra> ListarPrivilegiosExtra(Usuario user)
        {
            List<PrivilegioExtra> list = _db.PrivilegioExtras.Where(e => e.Rut == user.Rut).ToList();
            return list;
        }
    }
}
