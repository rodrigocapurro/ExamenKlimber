using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Idiomas
{
    public static class MensajeriaInternacional
    {
        static Type tipoClaseRecursos;
        static MensajeriaInternacional()
        {
            string idioma = ConfigurationManager.AppSettings["Idioma"];

            switch (idioma)
            {
                case "es-ES":
                    tipoClaseRecursos = typeof(Resource_es);
                    break;
                case "en-US":
                    tipoClaseRecursos = typeof(Resource_en);
                    break;
                case "it-IT":
                    tipoClaseRecursos = typeof(Resource_it);
                    break;
                default:
                    tipoClaseRecursos = typeof(Resource_es);
                    break;
            }

        }

        public static string GetText(string text, Type idioma = null)
        {
            try
            {
                if (idioma != null)
                    return (string)idioma.GetProperty(text).GetValue(null);
                return (string)tipoClaseRecursos.GetProperty(text).GetValue(null);
            }
            catch (Exception ex)
            {
                return "Text key not found: " + ex.Message;
            }
        }
    }
}
