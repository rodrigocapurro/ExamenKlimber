using DevelopmentChallenge.Data.BaseClasses;
using DevelopmentChallenge.Data.Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {

        public Cuadrado(decimal lado) : base(lado)
        {
        }

        #region Metodo(s) Clase Abstracta

        public override decimal CalcularArea()
        {
            return this._lado * this._lado;
        }

        public override decimal CalcularPerimetro()
        {
            return this._lado * 4;
        }

        public override string TraducirForma(int cantidad, Type idioma)
        {
            return cantidad == 1 ?
                MensajeriaInternacional.GetText("Cuadrado", idioma) :
                MensajeriaInternacional.GetText("Cuadrados", idioma);
        }

        #endregion Metodo(s) Clase Abstracta
    }
}
