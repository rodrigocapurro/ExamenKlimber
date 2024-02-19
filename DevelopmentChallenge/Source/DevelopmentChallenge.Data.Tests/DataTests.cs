using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.BaseClasses;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Idiomas;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            try
            {
                Assert.Warn(MensajeriaInternacional.GetText("ListaVacia"));
                FormaGeometrica.Imprimir(new List<Cuadrado>());
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError"), ex.Message));
            }
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            try
            {
                var cuadrados = new List<Cuadrado> { new Cuadrado(6), new Cuadrado(10) };

                var resumen = FormaGeometrica.Imprimir(cuadrados);

                Assert.Warn(MensajeriaInternacional.GetText("InfoCuadrado") + resumen);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError"), ex.Message));
            }
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            try
            {
                var cuadrados = new List<Cuadrado>
            {
                new Cuadrado(20),
                new Cuadrado(1),
                new Cuadrado(50),
            };

                var resumen = FormaGeometrica.Imprimir(cuadrados);

                Assert.Warn(MensajeriaInternacional.GetText("InfoCuadrados") + resumen);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError"), ex.Message));
            }
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            try
            {
                var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(12),
                new Circulo(3),
                new Triangulo(21),
                new TrapecioRectangulo(10, 20, 2, 3, 25),
                new TrapecioIsosceles(10, 20, 2, 3),
                new Rectangulo(10, 20),
                new Circulo(1)
            };

                var resumen = FormaGeometrica.Imprimir(formas);

                Assert.Warn(MensajeriaInternacional.GetText("FormaReporte") + resumen);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError"), ex.Message));
            }
        }

        // Este metodo se hizo para probar el idioma configurado en el app.config
        [TestCase]
        public void TestResumenListaVariosTiposYConIdiomaEspañol()
        {
            try
            {
                var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(12),
                new Circulo(3),
                new Triangulo(21),
                new TrapecioRectangulo(10, 20, 2, 3, 25),
                new Rectangulo(10, 20),
                new Circulo(1)
            };

                var resumen = FormaGeometrica.Imprimir(formas);

                Assert.Warn(MensajeriaInternacional.GetText("FormaReporte", typeof(Resource_es)) + resumen);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError"), ex.Message));
            }
        }

        // Este metodo se hizo para probar con algun idioma que selecione el usuario
        [TestCase]
        public void TestResumenListaRectangulosYConIdiomaItaliano()
        {
            try
            {
                var formas = new List<FormaGeometrica>
            {
                new Rectangulo(1, 2),
                new Rectangulo(60, 50),
                new Rectangulo(2, 4),
                new Rectangulo(32, 68),
                new Rectangulo(12, 21),
                new Rectangulo(110, 99)
            };

                var resumen = FormaGeometrica.Imprimir(formas, typeof(Resource_it));

                Assert.Warn(MensajeriaInternacional.GetText("FormaReporte", typeof(Resource_it)) + resumen);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError"), ex.Message));
            }
        }

        [TestCase]
        public void TestResumenListaVariosTipoYVariosIdiomas()
        {
            try
            {
                var formas1 = new List<FormaGeometrica>
                {
                    new Rectangulo(4, 6),
                    new Cuadrado(6),
                    new TrapecioRectangulo(22, 43, 20, 1, 300),
                };

                var formas2 = new List<FormaGeometrica>()
                {
                    new Triangulo(22),
                    new Circulo(100),
                    new TrapecioRectangulo(11, 9, 1, 33, 20)
                };

                var formas3 = new List<FormaGeometrica>()
                {
                    new Cuadrado(22),
                    new Triangulo(100),
                    new Rectangulo(11, 1)
                };

                var resumen1 = FormaGeometrica.Imprimir(formas1, typeof(Resource_it));
                var resumen2 = FormaGeometrica.Imprimir(formas2, typeof(Resource_en));
                var resumen3 = FormaGeometrica.Imprimir(formas3, typeof(Resource_es));

                Assert.Warn(string.Format("Info: {0} - Español: {1} - Ingles: {2} - Italiano: {3}",
                    MensajeriaInternacional.GetText("FormaReporte", typeof(Resource_es)), resumen3, resumen2, resumen1));
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError"), ex.Message));
            }
        }

        [TestCase]
        public void TestResumenListaRectangulosConErrores()
        {
            // Este metodo configurara formas con erores, por ejemplo resctandulos con todos su lados iguales
            // Para ver que de error
            try
            {
                var rectangulos = new List<FormaGeometrica>()
                {
                    new Rectangulo(11, 23, typeof(Resource_it)),
                    new Rectangulo(1, 23, typeof(Resource_it)),
                    new Rectangulo(20, 20, typeof(Resource_it))
                };

                var resumen = FormaGeometrica.Imprimir(rectangulos, typeof(Resource_it));

                Assert.Warn(MensajeriaInternacional.GetText("FormaReporte", typeof(Resource_it)) + resumen);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError", typeof(Resource_it)), ex.Message));
            }
        }

        [TestCase]
        public void TestResumenListaTrapecioRectanguloConErroresEnLosLados()
        {
            // Este metodo configurara formas con erores Para ver que de error
            try
            {
                var rectangulos = new List<FormaGeometrica>()
                {
                    new TrapecioRectangulo(11, 11,23, 44, 20)
                };

                var resumen = FormaGeometrica.Imprimir(rectangulos);

                Assert.Warn(MensajeriaInternacional.GetText("FormaReporte") + resumen);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError"), ex.Message));
            }
        }

        [TestCase]
        public void TestResumenListaTrapecioRectanguloConErroresEnLasBases()
        {
            // Este metodo configurara formas con erores Para ver que de error
            try
            {
                var rectangulos = new List<FormaGeometrica>()
                {
                    new TrapecioRectangulo(11, 71,23, 23, 20, typeof(Resource_en))
                };

                var resumen = FormaGeometrica.Imprimir(rectangulos, typeof(Resource_en));

                Assert.Warn(MensajeriaInternacional.GetText("FormaReporte", typeof(Resource_en)) + resumen);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError", typeof(Resource_en)), ex.Message));
            }
        }

        [TestCase]
        public void TestResumenListaTrapecioIsoscelesConErroresEnLasBases()
        {
            // Este metodo configurara formas con erores Para ver que de error
            try
            {
                var rectangulos = new List<FormaGeometrica>()
                {
                    new TrapecioIsosceles(21, 21,21, 10, typeof(Resource_es))
                };

                var resumen = FormaGeometrica.Imprimir(rectangulos, typeof(Resource_es));

                Assert.Warn(MensajeriaInternacional.GetText("FormaReporte", typeof(Resource_es)) + resumen);
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("{0} : {1}", MensajeriaInternacional.GetText("PruebaError", typeof(Resource_es)), ex.Message));
            }
        }
    }
}
