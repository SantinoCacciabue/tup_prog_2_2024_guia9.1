using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.models
{
    internal class EvaluacionParametrica:Evaluacion
    {
        public double ValorMinimo {  get;private set; }
        public double ValorMaximo { get; private set; }
        public double ValorTolerado { get; private set; }
        public double ValorMedido { get; set; }
        public string Unidad {  get; private set; }
        public EvaluacionParametrica(double valorMinimo, double valorMaximo, double valorTolerado, string unidad,string n,string d):base(n,d)
        {
            ValorMinimo = valorMinimo;
            ValorMaximo = valorMaximo;
            ValorTolerado = valorTolerado;
            ValorMedido = valorMedido;
            Unidad = unidad;
        }
        public override TipoAprobación Evaluar()
        {
            if (ValorMedido < ValorMinimo * 0.7)
            {
                return TipoAprobación.NoAprobado;
            }
            else
            {
                if (ValorMedido > ValorMinimo * 0.7 && ValorMedido < ValorMinimo)
                {
                    return TipoAprobación.Parcial;
                }
            }
            return TipoAprobación.Aprobado;
        }
        public override string ToString()
        {
            return $"Prueba de {Nombre}-{Descripcion}-Porcentaje:{Unidad}-{Evaluar()}";
        }
    }
}
