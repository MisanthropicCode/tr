using System;
using System.Linq;
using System.Xml.Linq;
using Linguistics.Dictionary;
using Linguistics.Utilities;

namespace Linguistics.YandexTranslation
{
    public class YandexTranslator: YandexAPI
    {
        public override WordTranslation GetTranslation(string text, string key, TranslationDirection translationDirection)
        {
            string query = String.Format("https://translate.yandex.net/api/v1.5/tr/translate?key={0}&text={1}&lang={2}",
               key, text, translationDirection);
            string xmlResp = HttpQuery.Get(query);

            XDocument xmlResult = XDocument.Parse(xmlResp);
            var el = xmlResult.Descendants("text").FirstOrDefault();
            if (el != null)
            {
                var translations = xmlResult.Descendants("text").FirstOrDefault();

                return new WordTranslation() { Translation = translations.Value.ToString() };
            }
            else
            {
                return null;
            }
        }
    }
}
