using DevelopmentChallenge.Data.BaseClasses;
using DevelopmentChallenge.Data.Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        public Circulo(decimal lado) : base(lado)
        {
        }


        #region Metodo(s) Clase Abstracta

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (this._lado / 2) * (this._lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * this._lado;
        }

        public override string TraducirForma(int cantidad, Type idioma)
        {
            return cantidad == 1 ?
                MensajeriaInternacional.GetText("Circulo", idioma) :
                MensajeriaInternacional.GetText("Circulos", idioma);
        }

        #endregion Metodo(s) Clase Abstracta
    }
}
