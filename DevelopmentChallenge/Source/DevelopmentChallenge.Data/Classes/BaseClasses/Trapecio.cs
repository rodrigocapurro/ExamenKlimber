using DevelopmentChallenge.Data.BaseClasses;
using DevelopmentChallenge.Data.Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.BaseClasses
{
    public abstract class Trapecio : FormaGeometrica
    {
        protected readonly decimal _base1;
        protected readonly decimal _base2;
        protected readonly decimal _altura;

        public Trapecio(decimal lado1) : base(lado1)
        {
        }

        public Trapecio(decimal lado1, decimal base1, decimal base2, decimal altura) : base(lado1)
        {
            this._base1 = base1;
            this._base2 = base2;
            this._altura = altura;
        }

        #region Metodo(s) Clase Abstracta

        public override string TraducirForma(int cantidad, Type idioma)
        {
            return cantidad == 1 ?
                MensajeriaInternacional.GetText("Trapecio", idioma) :
                MensajeriaInternacional.GetText("Trapecios", idioma);
        }

        public override decimal CalcularArea()
        {
            return ((this._base1 + this._base2) * this._altura) / 2;
        }

        #endregion Metodo(s) Clase Abstracta
    }
}
