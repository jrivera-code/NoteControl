using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.ViewModel.DataGridRowModel
{
    public class UsuarioRowModel
    {
        string _rut;
        string _nombreUsuario;
        string _estado;
        string _perfil;
        string _telefono;
        string _correo;

        public string Rut
        {
            get
            {
                return _rut;
            }
            set
            {
                _rut = value;
            }
        }
        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }
        public string Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;
            }
        }
        public string Perfil
        {
            get
            {
                return _perfil;
            }
            set
            {
                _perfil = value;
            }
        }
        public string Correo
        {
            get
            {
                return _correo;
            }
            set
            {
                _correo = value;
            }
        }
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }
    }
}
