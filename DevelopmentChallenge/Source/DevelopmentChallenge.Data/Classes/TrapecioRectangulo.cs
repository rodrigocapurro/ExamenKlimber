using DevelopmentChallenge.Data.BaseClasses;
using DevelopmentChallenge.Data.Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrapecioRectangulo : Trapecio
    {
        protected readonly decimal _lado2;
        public TrapecioRectangulo(decimal lado1) : base(lado1)
        {
        }

        public TrapecioRectangulo(decimal lado1, decimal lado2, decimal base1, decimal base2, decimal altura, Type idioma = null) : base(lado1, base1, base2, altura)
        {
            // Agrego una validacion propia para el trapecio rectangulo
            if (base1 == base2 || lado1 == lado2)
                throw new Exception(MensajeriaInternacional.GetText("TrapecioRectanguloIncorrecto", idioma));

            this._lado2 = lado2;
        } 

        public override decimal CalcularPerimetro()
        {
            return this._base1 + this._base2 + this._lado + this._lado2;
        }
    }
}
