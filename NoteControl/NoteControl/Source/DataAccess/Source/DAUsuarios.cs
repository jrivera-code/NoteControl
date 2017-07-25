using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
   public class DAUsuarios : IDisposable
    {
        private readonly NoteControlContext _db = new NoteControlContext();
        
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
