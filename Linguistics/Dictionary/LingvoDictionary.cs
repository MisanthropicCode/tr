using System;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using Linguistics.Utilities;

namespace Linguistics.Dictionary
{
    public class LingvoDictionary: IDictionary
    {
        public WordTranslation GetTranslation(string word, TranslationDirection translationDirection)
        {
            string query = String.Format("http://www.lingvo.ua/ru/Translate/{0}/{1}",
               translationDirection.ToString(), word);

            string result = HttpQuery.Get(query);

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(result);

            var lingvoUniversal = html.DocumentNode.Descendants("div").
                FirstOrDefault(c => c.Attributes.Contains("class") &&
                c.Attributes["class"].Value == "js-article-html g-card");

            if (lingvoUniversal == null)
            {
                string newValidWord = html.DocumentNode.Descendants("div").
                    FirstOrDefault(c => c.Attributes.Contains("class") &&
                    c.Attributes["class"].Value == "g-srcwarning g-bold js-word-forms-strip").
                    Descendants("a").FirstOrDefault().InnerText;
                return GetTranslation(newValidWord, translationDirection);
            }

            string wordName = lingvoUniversal.Descendants("h2").FirstOrDefault().InnerText;

            var nodes = lingvoUniversal.Descendants("p").
                Where(c => c.Attributes["class"].Value == "P1" ||
                           c.Attributes["class"].Value == "P2" ||
                           c.Attributes["class"].Value == "P").Take(5).ToList();

            nodes.Remove(nodes.First());

            string output = "";

            foreach (var node in nodes)
            {
                output += node.InnerText + "<br>";
            }

            return new WordTranslation() { Translation = output, WordName = wordName };
        }
    }
}
