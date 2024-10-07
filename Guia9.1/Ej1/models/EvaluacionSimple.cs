using System;
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
            return $"Prueba de {Descripcion}, Resultado:{Evaluar()}\r\n";
        }
    }
}
