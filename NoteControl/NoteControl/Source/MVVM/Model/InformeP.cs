using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoteControl.Source.MVVM.Model
{
	public class InformeP
	{

		[Key]
		public int AlumnoNotaAsignaturaId { get; set; }
		public string AsignaturaCode { get; set; }
		public int Rut { get; set; }
		public float Calificacion { get; set; }
		public int NumeroNota { get; set; }
		public virtual Asignatura Asignatura { get; set; }
		public virtual Alumno Alumno { get; set; }

	}
}
