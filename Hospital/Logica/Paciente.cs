using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Logica
{
    public class Paciente
    {
        private int id;
        private string nombre;
        private string apellido;
        private DateTime fechaDeNacimiento;
        private char sexo;

        public Paciente(int id, string nombre, string apellido, DateTime fechaDeNacimiento, char sexo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this.Sexo = sexo;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public char Sexo { get => sexo; set => sexo = value; }
    }
}
