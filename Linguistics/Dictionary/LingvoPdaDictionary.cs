using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using Linguistics.Utilities;

namespace Linguistics.Dictionary
{
    public class TranslationItem
    {
        public List<string> translations = new List<string>();
        public List<string> synonyms = new List<string>();
        string Example { get; set; }
        
    }

    public class LingvoArticle
    {
        public string WordName { get; set; }

        public List<TranslationItem> nouns = new List<TranslationItem>();
        public List<TranslationItem> verbs = new List<TranslationItem>();
        public List<TranslationItem> adverbs = new List<TranslationItem>();
        public List<TranslationItem> adjectives = new List<TranslationItem>();
        public List<TranslationItem> prepositions = new List<TranslationItem>();
        public List<TranslationItem> conjunctions = new List<TranslationItem>();
    }

    public class LingvoPdaDictionary: IDictionary
    {
        public WordTranslation GetTranslation(string word, TranslationDirection translationDirection)
        {
            string query = String.Format("http://pda.lingvo.ru/Result.aspx?Word={0}", word);

            string result = HttpQuery.Get(query);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(result);

            HtmlNode lingvoUniversal = html.GetElementbyId("pResult");

            string validWordName = lingvoUniversal.Descendants("h3").FirstOrDefault().InnerText;

            var nodes = lingvoUniversal.Descendants("p").
                Where(c => c.Attributes.Contains("style")).Where(c =>
                c.Attributes["style"].Value == "margin:'0.1cm 0.5cm 0.1cm 0.5cm'" ||
                c.Attributes["style"].Value == "margin:'0.1cm 0.5cm 0.1cm 1.0cm'");

            string output = "";
            foreach (HtmlNode node in nodes)
            {
                
                //if (node.Descendants("span").FirstOrDefault().Attributes["style"].Value == "color: #808080")
                //    continue;

                output += node.InnerText + "<br>";
            }

            return new WordTranslation() { Translation = output, WordName = validWordName };
        }
    }
}
