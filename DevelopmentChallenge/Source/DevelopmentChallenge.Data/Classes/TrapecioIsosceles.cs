using DevelopmentChallenge.Data.BaseClasses;
using DevelopmentChallenge.Data.Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrapecioIsosceles : Trapecio
    {
        public TrapecioIsosceles(decimal lado) : base(lado)
        {
        }

        public TrapecioIsosceles(decimal lado, decimal base1, decimal base2, decimal altura, Type idioma = null) : base(lado, base1, base2, altura)
        {
            // Agrego una validacion propia para el trapecio isosceles
            if (base1 == base2)
                throw new Exception(MensajeriaInternacional.GetText("TrapecioIsoscelesIncorrecto", idioma));
        }

        public override decimal CalcularPerimetro()
        {
            return this._base1 + this._base2 + (2 * this._lado);
        }
    }
}
