using DevelopmentChallenge.Data.BaseClasses;
using DevelopmentChallenge.Data.Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        protected readonly decimal _ancho;

        public Rectangulo(decimal lado, decimal ancho, Type idioma = null) : base(lado)
        {
            if (lado == ancho)
                throw new Exception(MensajeriaInternacional.GetText("RectanguloIncorrecto", idioma));

            this._ancho = ancho;


        }

        #region Metodo(s) Clase Abstracta

        public override decimal CalcularArea()
        {
            return this._lado * this._ancho;
        }

        public override decimal CalcularPerimetro()
        {
            return 2 * (this._lado + this._ancho);
        }


        public override string TraducirForma(int cantidad, Type idioma)
        {
            return cantidad == 1 ?
                MensajeriaInternacional.GetText("Rectangulo", idioma) :
                MensajeriaInternacional.GetText("Rectangulos", idioma);
        }

        #endregion Metodo(s) Clase Abstracta
    }
}
