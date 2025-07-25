﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploLINQ
{
    public enum Departamento
    {
        RH = 201,
        Desarrollo = 520,
        Soporte = 402,
        Admin = 309
    }
    class Empleado
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

 
        public Departamento Departamento { get; set; }
        public string Ciudad { get; internal set; }
        public string Telefono { get; internal set; }
        public int Edad { get; internal set; }
        public int IdExterno { get; internal set; }
        public List<Pago> Pagos { get; internal set; }
    }
}
