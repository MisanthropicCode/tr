namespace Linguistics.Dictionary
{
    public interface IDictionary
    {
        WordTranslation GetTranslation(string word, TranslationDirection translationDirection);
    }
}
