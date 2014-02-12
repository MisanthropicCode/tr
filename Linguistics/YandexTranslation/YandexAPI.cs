using System.IO;
using System.Net;
using Linguistics.Dictionary;

namespace Linguistics.YandexTranslation
{
    public abstract class YandexAPI
    {
        public string Key { get; set; }
        public TranslationDirection Lang { get; set; }

        public abstract WordTranslation GetTranslation(string text, string key, TranslationDirection translationDirection);
    }
}
