using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    public partial class Form1
    {
        List<string> history = new List<string>();

        private async Task Start()
        {
            check = true;

            button2.Enabled = true;

            ProfanityOption profanityOption = ProfanityOption.Raw;
            var speechConfig = ", "eastus");
            speechConfig.SetProfanity(profanityOption);
            string deviceID = "";

            if (settings.FromMicrophone)
            {
                var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
                while (check)
                {
                    await FromDevice(speechConfig, audioConfig);
                }
            }
            else
            {
                await Task.Run(() =>
                {
                    deviceID = AudioDevices.GetDeviceID()["CABLE Output (VB-Audio Virtual Cable)"];
                });

                var audioConfig = AudioConfig.FromMicrophoneInput(deviceID);

                while (check)
                {
                    await FromDevice(speechConfig, audioConfig);

                }
            }
        }

        private async Task FromDevice(SpeechConfig speechConfig, AudioConfig audioConfig)
        {
            using (audioConfig)
            {
                using var recognizer = new SpeechRecognizer(speechConfig, settings.InputLanguage, audioConfig);

                recognizer.Recognizing += (o, e) =>
                {
                    Action action = new Action(async () =>
                    {
                        richTextBox1.Text = await Translator.Translate(Resultator.GetResult(e), settings.OutputLanguage);
                    });
                    Invoke(action);
                };

                recognizer.Recognized += (o, e) =>
                {
                    Action action = new Action(async () =>
                    {
                        string res = await Translator.Translate(Resultator.GetResult(e), settings.OutputLanguage);
                        if (!String.IsNullOrWhiteSpace(res))
                        {
                            history.Add(res);
                        }
                    });
                    Invoke(action);
                };

                await recognizer.StartContinuousRecognitionAsync();

                while (check)
                {
                    await Task.Delay(1000);
                }

                await recognizer.StopContinuousRecognitionAsync();
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
