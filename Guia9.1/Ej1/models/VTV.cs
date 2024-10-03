using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.models
{
    internal class VTV : IComparable
    {
        Propietario propietario;
        private List<Evaluacion> verificaciones = new List<Evaluacion>();

        public string Patente {  get; private set; }
        public DateTime Fecha { get; private set; }
        public  int CantidadVerificaciones
        {
            get
            {
                return verificaciones.Count;
            }
        }
        public Evaluacion this[int i]
        {
            get
            {
                return verificaciones[i];
            }
        }
        public TipoAprobación Aprobacion
        {
            get
            {
                int min = 0;
                for(int i = 0; i < CantidadVerificaciones; i++)
                {
                    Evaluacion e = this[i];
                    int valor = (int)e.Evaluar();
                    if (i == 0 || valor < min) min = valor;
                }
                return (TipoAprobación)min;
            }
        }
        public VTV(string patente,Propietario p)
        {
            Patente = patente;
            propietario = p;

            verificaciones = new List<Evaluacion> {new EvaluacionSimple("Bocina","Funcionamiento correcto"),
        new EvaluacionParametrica(0.30,1,0.30*0.7,"Porcentaje","Prueba de frenos delanteros","Porcentaje de diferencia de frenado entre ejes"),
        new EvaluacionParametrica(0.30,1,0.30*0.7,"Porcentaje","Prueba de frenos traseros","Porcentaje de diferencia de frenado entre ejes"),
        new EvaluacionParametrica(0.0,0.5,0-(0.5*0.3),"Grado","Alineación","Convergencia en grados"),
        new EvaluacionParametrica(10000,15000,10000*0.7,"Candela","Luces de corto alcante","Intensidad lumínica"),
        new EvaluacionParametrica(30000,40000,30000*0.7,"Candela","Luces de largo alcante","Intensidad lumínica")};

        }
        public string[] EmitirComprobante()
        {
            string[] a = new string[CantidadVerificaciones + 1];
            a[0] = propietario.ToString();
            for (int i = 1; i < CantidadVerificaciones; i++)
            {
                a[i] = verificaciones[i-1].ToString();
            }
            return a;
        }

        public int CompareTo(object obj)
        {
            VTV a = obj as VTV;
            if (a != null)
            {
                return Patente.CompareTo(a.Patente);
            }
            return -1;
        }
    }
}
