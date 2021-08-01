﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Recognizer
{
    public static class Translator
    {

        private const string Key = "f01ea9a8d6194716af4cc6b37b7f866f";

        private static readonly HttpClient client = new HttpClient
        {
            DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", Key } }
        };

        public static async Task<string> Translate(string text, string language)
        {
            var encodedTesxt = WebUtility.UrlEncode(text);

            var url = "https://api.microsofttranslator.com/V2/Http.svc/Translate?" +
                       $"to={language}&text={encodedTesxt}";

            var result = await client.GetStringAsync(url);

            return XElement.Parse(result).Value;
        }
    }
}