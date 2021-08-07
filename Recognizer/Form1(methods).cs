using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    public partial class Form1
    {
        public string GetHistory()
        {
            return str.ToString();
        }

        private async Task Translate(string recognizedText)
        {
            string translatedText = await Translator.Translate(recognizedText, settings.OutputLanguage);

            if (translatedText.Length > 1)
                str += translatedText + " \n";

            Action action = new Action(() =>
            {
                if (translatedText.Length > 1)
                    richTextBox1.Text = translatedText;
            });

            Invoke(action);
        }

        private async Task Start()
        {
            check = true;

            button2.Enabled = true;

            if (fromMicrophone)
            {
                while (check)
                {
                    RecognizeFromMic newRecognizer = new RecognizeFromMic();

                    string recognizedText = await newRecognizer.StartRecognize(settings.InputLanguage);

                    Translate(recognizedText);
                }
            }
            else
            {
                while (check)
                {
                    NewRecognizer newRecognizer = new NewRecognizer();

                    string recognizedText = await newRecognizer.StartRecognize(settings.InputLanguage);

                    Translate(recognizedText);
                }
            }
        }

        private string SetLanguage(string language)
        {
                switch (language)
                {
                    case "Arabic":
                        return "ar-SA";
                    case "Bulgarian":
                        return "bg-BG";
                    case "Catalan":
                        return "ca-ES";
                    case "Chinese Simplified":
                        return "zh-Hans";
                    case "Chinese Traditional":
                        return "zh-Hant";
                    case "Croatian":
                        return "ru-RU";
                    case "Czech":
                        return "cs-CZ";
                    case "Danish":
                        return "da-DK";
                    case "Dutch":
                        return "nl-NL";
                    case "English":
                        return "en-US";
                    case "Estonian":
                        return "et-EE";
                    case "Finnish":
                        return "fi-FI";
                    case "French":
                        return "fr-FR";
                    case "German":
                        return "de-DE";
                    case "Greek":
                        return "el-GR";
                    case "Gujarati":
                        return "gu-IN";
                    case "Hebrew":
                        return "he-IL";
                    case "Hindi":
                        return "hi-IN";
                    case "Hungarian":
                        return "hu-HU";
                    case "Indonesian":
                        return "id-ID";
                    case "Irish":
                        return "ga-IE";
                    case "Italian":
                        return "it-IT";
                    case "Japanese":
                        return "ja-JP";
                    case "Korean":
                        return "ko-KR";
                    case "Latvian":
                        return "lv-LV";
                    case "Lithuanian":
                        return "it-LT";
                    case "Malay":
                        return "ms-MY";
                    case "Maltese":
                        return "mt-MT";
                    case "Norwegain":
                        return "nb-NO";
                    case "Polish":
                        return "pl-PL";
                    case "Portuguese(Brazil)":
                        return "pt-BR";
                    case "Portuguese(Portugal)":
                        return "pt-PT";
                    case "Romanian":
                        return "ro-RO";
                    case "Russian":
                        return "ru-RU";
                    case "Slovak":
                        return "sk-SK";
                    case "Slovenian":
                        return "sl-SL";
                    case "Spanish":
                        return "es-ES";
                    case "Swedish":
                        return "sv-SE";
                    case "Thai":
                        return "th-TH";
                    case "Turkish":
                        return "tr-TR";
                    case "Vietnamese":
                        return "vi-VN";
                    default:
                        return "en-US";
                }
        }
    }
}
