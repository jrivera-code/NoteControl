using NoteControl.Source.BusinessLogic;
using NoteControl.Source.MVVM.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;

namespace NoteControl.Source.MVVM.ViewModel.DataGridRowModel
{
    public class AsigNotasModel : ValidationRule,INotifyPropertyChanged
    {
        private BLNotas _blNotas = new BLNotas();
        private string _asignaturaCode;
        public string AsignaturaCode
        {
            get { return _asignaturaCode; }
            set { _asignaturaCode = value; }
        }
        private string _rut;
        public string Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
        private string _nombreApellido;

        public string NombreApellido
        {
            get { return _nombreApellido; }
            set { _nombreApellido = value; }
        }
        private float _nota1;

        public float Nota1
        {
            get { return _nota1; }
            set {
                _nota1 = value;
                if (_nota1 != 0) {
                    GuardarNota(_nota1,_asignaturaCode,_rut,1);
                    NotifyProperty("Nota1");
                } 
                else _nota1 = 0; 
            }
        }
        private float _nota2;

        public float Nota2
        {
            get { return _nota2; }
            set {
                _nota2 = value;
                if (_nota2 != 0) {
                    GuardarNota(_nota2, _asignaturaCode, _rut,2);
                    NotifyProperty("Nota2");
                }
                else _nota2 = 0; 
            }
        }
        private float _nota3;

        public float Nota3
        {
            get { return _nota3; }
            set {
                _nota3 = value;
                if (_nota3 != 0) {
                    GuardarNota(_nota3, _asignaturaCode, _rut,3);
                    NotifyProperty("Nota3"); }
                else _nota3 = 0; 
            }
        }
        private float _nota4;

        public float Nota4
        {
            get { return _nota4; }
            set {
                _nota4 = value;
                if (_nota4 != 0) {
                    GuardarNota(_nota4, _asignaturaCode, _rut,4);
                    NotifyProperty("Nota4"); }
                else _nota4 = 0; 
            }
        }
        private float _nota5;

        public float Nota5
        {
            get { return _nota5; }
            set {
                _nota5 = value;
                if (_nota5 != 0) {
                    GuardarNota(_nota5, _asignaturaCode, _rut,5);
                    NotifyProperty("Nota5"); }
                else _nota5 = 0; 
            }
        }
        private float _nota6;

        public float Nota6
        {
            get { return _nota6; }
            set {
                _nota6 = value;
                if (_nota6 != 0) {
                    GuardarNota(_nota6, _asignaturaCode, _rut,6);
                    NotifyProperty("Nota6"); }
                else _nota6 = 0; 
            }
        }
        private float _nota7;

        public float Nota7
        {
            get { return _nota7; }
            set {
                _nota7 = value;
                if (_nota7 != 0) {
                    GuardarNota(_nota7, _asignaturaCode, _rut,7);
                    NotifyProperty("Nota7"); }
                else _nota7 = 0; 
            }
        }
        private float _nota8;

        public float Nota8
        {
            get { return _nota8; }
            set {

                _nota8 = value;
                if (_nota8 != 0) {
                    GuardarNota(_nota8, _asignaturaCode, _rut,8);
                    NotifyProperty("Nota8"); }
                else _nota8 = 0; 
            }
        }
        private float _nota9;

        public float Nota9
        {
            get { return _nota9; }
            set {
                _nota9 = value;
                if (_nota9 != 0) {
                    GuardarNota(_nota9, _asignaturaCode, _rut,9);
                    NotifyProperty("Nota9"); }
                else _nota9 = 0;
            }
        }
        private float _nota10;
        public float Nota10
        {
            get { return _nota10; }
            set {
                _nota10 = value;
                if (_nota10 != 0 ) {
                    GuardarNota(_nota10, _asignaturaCode, _rut,10);
                    NotifyProperty("Nota10"); }
                else _nota10 = 0; 
            }
        }
       

        private void GuardarNota(float calificacion,string asignaturaCode,string rut,int numeroNota) {
            if(calificacion != 0 && asignaturaCode != "" && asignaturaCode != null)
            _blNotas.AgregarNuevaNota(calificacion, asignaturaCode, int.Parse(rut), numeroNota);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyProperty(string propertyName)
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
