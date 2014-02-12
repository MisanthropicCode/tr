namespace Linguistics.Dictionary
{
    public struct TranslationDirection
    {
        public Lang InputLang;
        public Lang OutputLang;

        public TranslationDirection(Lang inputLang, Lang outputLang)
		{
			InputLang = inputLang;
			OutputLang = outputLang;
		}

        public static readonly TranslationDirection EnRu = new TranslationDirection(Lang.en, Lang.ru);
        public static readonly TranslationDirection RuEn = new TranslationDirection(Lang.ru, Lang.en);

        public override string ToString()
        {
            return InputLang.ToString() + "-" + OutputLang.ToString();
        }
    }
}
