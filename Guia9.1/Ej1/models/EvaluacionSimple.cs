﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.models
{
    internal class EvaluacionSimple:Evaluacion
    {
        public bool HaVerificado {  get; set; }
        public EvaluacionSimple(string n, string d):base(n, d) { }
        public override TipoAprobación Evaluar()
        {
            if (HaVerificado)
            {
                return TipoAprobación.Aprobado;
            }
            return TipoAprobación.NoAprobado;
        }
        public override string ToString()
        {
            string nombre = Nombre.Length > 20 ? Nombre.Substring(0, 17) + "..." : Nombre.PadRight(20, '_');
            string descripcion = Descripcion.Length > 20 ? Descripcion.Substring(0, 17) + "..." : Descripcion.PadRight(20, '_');
            return $"{nombre} - {descripcion} - {Evaluar()}\r\n";
        }
    }
}
