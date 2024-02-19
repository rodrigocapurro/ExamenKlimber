/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos. OK
 * Implementar la forma Trapecio/Rectangulo. OK
 * Agregar el idioma Italiano (o el deseado) al reporte. OK
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad 
 * agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.) OK
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar 
 * la nueva versión :).
 */

using DevelopmentChallenge.Data.Idiomas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Resources;
using System.Text;

namespace DevelopmentChallenge.Data.BaseClasses
{
    public abstract class FormaGeometrica
    {
        /*TODO 
         * 1) Para agregar un nuevo idioma hay q crear el recurso y agregar la clave y las palbras tradicidas
         2) Para agreagr una nueva forma geometrica, se debera crear la clase, heredar de FormaGeometrica e implementar sus metodos*/
        
        protected readonly decimal _lado;

        public FormaGeometrica(decimal lado)
        {
            _lado = lado;
        }

        public static string Imprimir(IEnumerable<FormaGeometrica> formas, Type idioma = null)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(MensajeriaInternacional.GetText("ListaVacia", idioma));
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append(MensajeriaInternacional.GetText("Reporte", idioma));

                var numeroForma = 0;
                var areaForma = 0m;
                var perimetroForma = 0m;

                var formasAgrupadas = formas.GroupBy(f => f.GetType());

                foreach (var formaAgrup in formasAgrupadas)
                {

                    numeroForma = 0;
                    areaForma = 0m;
                    perimetroForma = 0m;

                    foreach (var forma in formaAgrup)
                    {
                        numeroForma++;
                        areaForma += forma.CalcularArea();
                        perimetroForma += forma.CalcularPerimetro();
                    }

                    sb.Append(formaAgrup.ToList()[0].ObtenerLinea(numeroForma, areaForma, perimetroForma, idioma));
                }

                CrearFOOTER(ref sb, numeroForma, perimetroForma, areaForma, idioma);
            }

            return sb.ToString();
        }

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Type idioma)
        {
            if (cantidad > 0)
                return $"{cantidad} {TraducirForma(cantidad, idioma)} | {MensajeriaInternacional.GetText("Area", idioma)} {area:#.##} | {MensajeriaInternacional.GetText("Perimetro", idioma)} {perimetro:#.##} <br/>";

            return string.Empty;
        }

        public abstract string TraducirForma(int cantidad, Type idioma);

        public virtual decimal CalcularArea()
        {
            return 0;
        }

        public virtual decimal CalcularPerimetro()
        {
            return 0;
        }

        #region Metodo(s) Privado(s)

        private static void CrearFOOTER(ref StringBuilder sb, int numeroForma , decimal perimetroForma, decimal areaForma, Type idioma)
        {
            // FOOTER
            sb.Append(MensajeriaInternacional.GetText("Total", idioma));
            sb.Append(numeroForma + " " + MensajeriaInternacional.GetText("Formas", idioma) + " ");
            sb.Append(MensajeriaInternacional.GetText("Perimetro", idioma) + (perimetroForma).ToString("#.##") + " ");
            sb.Append(MensajeriaInternacional.GetText("Area", idioma) + (areaForma).ToString("#.##"));
        }

        #endregion Metodo(s) Privado(s)
    }
}
