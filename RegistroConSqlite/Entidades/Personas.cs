using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroConSqlite.Entidades
{
    public class Personas
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        public Personas()
        {
            PersonaId = 0;
            Nombre = string.Empty;
            Fecha = DateTime.Now;
        }
    }
}
