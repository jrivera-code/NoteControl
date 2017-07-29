using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DAPrivilegios : IDisposable
    {
        private readonly NoteControlContext _db = new NoteControlContext();
        public List<Privilegio> ListarPrivilegios()
        {
            List<Privilegio> lista = _db.Privilegios.ToList();
            return lista;
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
