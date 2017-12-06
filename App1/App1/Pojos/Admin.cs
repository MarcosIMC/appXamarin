using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pojos
{
    class Admin
    {
        private String pass;
        private String dni;
        private String nombre;
        private String email;
        private String role;

        public Admin(String dni, String nombre, String email, String pass, String role)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.email = email;
            this.pass = pass;
            this.role = role;
        }

        [JsonProperty("nombre")]
        public String Nombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }

        [JsonProperty("email")]
        public String Email
        {
            get { return email; }
            set { this.email = value; }
        }

        [JsonProperty("dni")]
        public String Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        [JsonProperty("pass")]
        public String Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        [JsonProperty("role")]
        public String Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
