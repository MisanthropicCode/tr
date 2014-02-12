using System;
using System.Linq;
using System.Xml.Linq;
using Linguistics.Dictionary;
using Linguistics.Utilities;

namespace Linguistics.YandexTranslation
{
    public class YandexDict: YandexAPI
    {
        public Lang UI { get; set; }

        public YandexDict(string key, TranslationDirection lang, Lang ui)
        {
            Key = key;
            Lang = lang;
            UI = ui;
        }

        public YandexDict()
        {
        }

        public WordTranslation GetTranslation(string word, string key, TranslationDirection translationDirection, Lang ui, LookupOptions flags)
        {
            string query = String.Format("https://dictionary.yandex.net/api/v1/dicservice/lookup?key={0}&lang={1}&text={2}&flags={3}",
               key, translationDirection, word, (int)flags);

            string xmlResp = HttpQuery.Get(query);

            XDocument xmlResult = XDocument.Parse(xmlResp);
            var el = xmlResult.Descendants("text").FirstOrDefault();
            if (el != null)
            {
                string title = el.Value.ToString();

                var translations = xmlResult.Descendants("tr").Descendants("text").Take(5);

                string result = "";
                foreach (var translation in translations)
                {
                    result += translation.Value.ToString() + "<br>";
                }

                return new WordTranslation() { WordName = title, Translation = result };
            }
            else
            {
                return null;
            }
        }

        public override WordTranslation GetTranslation(string text, string key, TranslationDirection translationDirection)
        {
            return GetTranslation(text, key, translationDirection,
                Dictionary.Lang.en,
                LookupOptions.Family | LookupOptions.Morpho | LookupOptions.PartOfSpeechFilter);
        }
    }
}
