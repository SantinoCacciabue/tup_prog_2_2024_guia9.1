using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.models
{
    internal class Propietario
    {
       public string DNI {  get; set; }
        public string ApellidoNombres{get; set; }
        public string Email {  get; set; }
        public Propietario(string dNI, string apellidoNombres, string email)
        {
            DNI = dNI;
            ApellidoNombres = apellidoNombres;
            Email = email;
        }
        public override string ToString()
        {
            return $"{ApellidoNombres}({DNI})";
        }
    }
}
