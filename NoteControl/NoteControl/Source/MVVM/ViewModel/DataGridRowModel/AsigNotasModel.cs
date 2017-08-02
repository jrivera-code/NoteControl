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

namespace NoteControl.Source.MVVM.ViewModel.DataGridRowModel
{
    public class AsigNotasModel : DataGridTextColumn,INotifyPropertyChanged
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
        private string _nota1;

        public string Nota1
        {
            get { return _nota1; }
            set {
                _nota1 = StaticMethods.NumberValidationTextBox(value);
                if (_nota1 != null ) {
                    GuardarNota(_nota1,_asignaturaCode,_rut);
                    NotifyProperty("Nota1");
                } 
                else _nota1 = ""; 
            }
        }
        private string _nota2;

        public string Nota2
        {
            get { return _nota2; }
            set {
                _nota2 = StaticMethods.NumberValidationTextBox(value);
                if (_nota2 != null) {
                    GuardarNota(_nota2, _asignaturaCode, _rut);
                    NotifyProperty("Nota2");
                }
                else _nota2 = ""; 
            }
        }
        private string _nota3;

        public string Nota3
        {
            get { return _nota3; }
            set {
                _nota3 = StaticMethods.NumberValidationTextBox(value);
                if (_nota3 != null) {
                    GuardarNota(_nota3, _asignaturaCode, _rut);
                    NotifyProperty("Nota3"); }
                else _nota3 = ""; 
            }
        }
        private string _nota4;

        public string Nota4
        {
            get { return _nota4; }
            set {
                _nota4 = StaticMethods.NumberValidationTextBox(value);
                if (_nota4 != null) {
                    GuardarNota(_nota4, _asignaturaCode, _rut);
                    NotifyProperty("Nota4"); }
                else _nota4 = ""; 
            }
        }
        private string _nota5;

        public string Nota5
        {
            get { return _nota5; }
            set {
                _nota5 = StaticMethods.NumberValidationTextBox(value);
                if (_nota5 != null) {
                    GuardarNota(_nota5, _asignaturaCode, _rut);
                    NotifyProperty("Nota5"); }
                else _nota5 = ""; 
            }
        }
        private string _nota6;

        public string Nota6
        {
            get { return _nota6; }
            set {
                _nota6 = StaticMethods.NumberValidationTextBox(value);
                if (_nota6 != null) {
                    GuardarNota(_nota6, _asignaturaCode, _rut);
                    NotifyProperty("Nota6"); }
                else _nota6 = ""; 
            }
        }
        private string _nota7;

        public string Nota7
        {
            get { return _nota7; }
            set {
                _nota7 = StaticMethods.NumberValidationTextBox(value);
                if (_nota7 != null) {
                    GuardarNota(_nota7, _asignaturaCode, _rut);
                    NotifyProperty("Nota7"); }
                else Nota7 = ""; 
            }
        }
        private string _nota8;

        public string Nota8
        {
            get { return _nota8; }
            set {

                _nota8 = StaticMethods.NumberValidationTextBox(value);
                if (_nota8 != null) {
                    GuardarNota(_nota8, _asignaturaCode, _rut);
                    NotifyProperty("Nota8"); }
                else _nota8 = ""; 
            }
        }
        private string _nota9;

        public string Nota9
        {
            get { return _nota9; }
            set {
                _nota9 = StaticMethods.NumberValidationTextBox(value);
                if (_nota9 != null) {
                    GuardarNota(_nota9, _asignaturaCode, _rut);
                    NotifyProperty("Nota9"); }
                else _nota9 = "";
            }
        }
        private string _nota10;

        

        public string Nota10
        {
            get { return _nota10; }
            set {
                _nota10 = StaticMethods.NumberValidationTextBox(value);
                if (_nota10 != null) {
                    GuardarNota(_nota10, _asignaturaCode, _rut);
                    NotifyProperty("Nota10"); }
                else _nota10 = ""; 
            }
        }

        private void GuardarNota(string calificacion,string asignaturaCode,string rut) {
            if(calificacion != "" && asignaturaCode != "")
            _blNotas.AgregarNuevaNota(calificacion, asignaturaCode, rut);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyProperty(string propertyName)
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
