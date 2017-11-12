using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pojos
{
    class Usuario
    {
        private String nombre, apellidos, email, dni, dniUserAdmin, role;

        public Usuario(String dni, String nombre, String apellidos, String email, String dniAdmin, String role)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.dniUserAdmin = dniAdmin;
            this.role = role;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string DniAdmin
        {
            get { return dniUserAdmin; }
            set { dniUserAdmin = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
