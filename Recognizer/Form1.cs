using System;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Recognizer
{
    public partial class Form1 : Form
    {
        private bool check = true;

        private string inputLanguage = "en-US";

        private string outputLanguage = "ru-RU";

        private bool clearStopButton = false;

        public Form1()
        {
            InitializeComponent();

        }

        private async Task Start()
        {
            check = true;

            button2.Enabled = true;

            while (check)
            {
                NewRecognizer newRecognizer = new NewRecognizer();

                string recognizedText = await newRecognizer.StartRecognize(inputLanguage);

                Translate(recognizedText);

            }
        }

        private async Task Translate(string recognizedText)
        {
            string translatedText = await Translator.Translate(recognizedText, outputLanguage);

            Action action = new Action(() =>
            {
                richTextBox1.Text += translatedText + " \n";
            });

            Invoke(action);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            check = false;

            button1.Enabled = true;

            button2.Enabled = false;

            if (clearStopButton)
            {
                richTextBox1.Clear();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;

            richTextBox1.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearStopButton = checkBox1.Checked;
            #region InputLanguage
            switch (comboBox1.Text)
            {
                case "Arabic":
                    inputLanguage = "ar-SA";
                    break;
                case "Bulgarian":
                    inputLanguage = "bg-BG";
                    break;
                case "Catalan":
                    inputLanguage = "ca-ES";
                    break;
                case "Chinese Simplified":
                    inputLanguage = "zh-Hans";
                    break;
                case "Chinese Traditional":
                    inputLanguage = "zh-Hant";
                    break;
                case "Croatian":
                    inputLanguage = "ru-RU";
                    break;
                case "Czech":
                    inputLanguage = "cs-CZ";
                    break;
                case "Danish":
                    inputLanguage = "da-DK";
                    break;
                case "Dutch":
                    inputLanguage = "nl-NL";
                    break;
                case "English":
                    inputLanguage = "en-US";
                    break;
                case "Estonian":
                    inputLanguage = "et-EE";
                    break;
                case "Finnish":
                    inputLanguage = "fi-FI";
                    break;
                case "French":
                    inputLanguage = "fr-FR";
                    break;
                case "German":
                    inputLanguage = "de-DE";
                    break;
                case "Greek":
                    inputLanguage = "el-GR";
                    break;
                case "Gujarati":
                    inputLanguage = "gu-IN";
                    break;
                case "Hebrew":
                    inputLanguage = "he-IL";
                    break;
                case "Hindi":
                    inputLanguage = "hi-IN";
                    break;
                case "Hungarian":
                    inputLanguage = "hu-HU";
                    break;
                case "Indonesian":
                    inputLanguage = "id-ID";
                    break;
                case "Irish":
                    inputLanguage = "ga-IE";
                    break;
                case "Italian":
                    inputLanguage = "it-IT";
                    break;
                case "Japanese":
                    inputLanguage = "ja-JP";
                    break;
                case "Korean":
                    inputLanguage = "ko-KR";
                    break;
                case "Latvian":
                    inputLanguage = "lv-LV";
                    break;
                case "Lithuanian":
                    inputLanguage = "it-LT";
                    break;
                case "Malay":
                    inputLanguage = "ms-MY";
                    break;
                case "Maltese":
                    inputLanguage = "mt-MT";
                    break;
                case "Norwegain":
                    inputLanguage = "nb-NO";
                    break;
                case "Polish":
                    inputLanguage = "pl-PL";
                    break;
                case "Portuguese(Brazil)":
                    inputLanguage = "pt-BR";
                    break;
                case "Portuguese(Portugal)":
                    inputLanguage = "pt-PT";
                    break;
                case "Romanian":
                    inputLanguage = "ro-RO";
                    break;
                case "Russian":
                    inputLanguage = "ru-RU";
                    break;
                case "Slovak":
                    inputLanguage = "sk-SK";
                    break;
                case "Slovenian":
                    inputLanguage = "sl-SL";
                    break;
                case "Spanish":
                    inputLanguage = "es-ES";
                    break;
                case "Swedish":
                    inputLanguage = "sv-SE";
                    break;
                case "Thai":
                    inputLanguage = "th-TH";
                    break;
                case "Turkish":
                    inputLanguage = "tr-TR";
                    break;
                case "Vietnamese":
                    inputLanguage = "vi-VN";
                    break;
                default:
                    inputLanguage = "en-US";
                    break;
            }
            #endregion
            #region OutputLanguage
            switch (comboBox3.Text)
            {
                case "Arabic":
                    outputLanguage = "ar-SA";
                    break;
                case "Bulgarian":
                    outputLanguage = "bg-BG";
                    break;
                case "Catalan":
                    outputLanguage = "ca-ES";
                    break;
                case "Chinese Simplified":
                    outputLanguage = "zh-Hans";
                    break;
                case "Chinese Traditional":
                    outputLanguage = "zh-Hant";
                    break;
                case "Croatian":
                    outputLanguage = "ru-RU";
                    break;
                case "Czech":
                    outputLanguage = "cs-CZ";
                    break;
                case "Danish":
                    outputLanguage = "da-DK";
                    break;
                case "Dutch":
                    outputLanguage = "nl-NL";
                    break;
                case "English":
                    outputLanguage = "en-US";
                    break;
                case "Estonian":
                    outputLanguage = "et-EE";
                    break;
                case "Finnish":
                    outputLanguage = "fi-FI";
                    break;
                case "French":
                    outputLanguage = "fr-FR";
                    break;
                case "German":
                    outputLanguage = "de-DE";
                    break;
                case "Greek":
                    outputLanguage = "el-GR";
                    break;
                case "Gujarati":
                    outputLanguage = "gu-IN";
                    break;
                case "Hebrew":
                    outputLanguage = "he-IL";
                    break;
                case "Hindi":
                    outputLanguage = "hi-IN";
                    break;
                case "Hungarian":
                    outputLanguage = "hu-HU";
                    break;
                case "Indonesian":
                    outputLanguage = "id-ID";
                    break;
                case "Irish":
                    outputLanguage = "ga-IE";
                    break;
                case "Italian":
                    outputLanguage = "it-IT";
                    break;
                case "Japanese":
                    outputLanguage = "ja-JP";
                    break;
                case "Korean":
                    outputLanguage = "ko-KR";
                    break;
                case "Latvian":
                    outputLanguage = "lv-LV";
                    break;
                case "Lithuanian":
                    outputLanguage = "it-LT";
                    break;
                case "Malay":
                    outputLanguage = "ms-MY";
                    break;
                case "Maltese":
                    outputLanguage = "mt-MT";
                    break;
                case "Norwegain":
                    outputLanguage = "nb-NO";
                    break;
                case "Polish":
                    outputLanguage = "pl-PL";
                    break;
                case "Portuguese(Brazil)":
                    outputLanguage = "pt-BR";
                    break;
                case "Portuguese(Portugal)":
                    outputLanguage = "pt-PT";
                    break;
                case "Romanian":
                    outputLanguage = "ro-RO";
                    break;
                case "Russian":
                    outputLanguage = "ru-RU";
                    break;
                case "Slovak":
                    outputLanguage = "sk-SK";
                    break;
                case "Slovenian":
                    outputLanguage = "sl-SL";
                    break;
                case "Spanish":
                    outputLanguage = "es-ES";
                    break;
                case "Swedish":
                    outputLanguage = "sv-SE";
                    break;
                case "Thai":
                    outputLanguage = "th-TH";
                    break;
                case "Turkish":
                    outputLanguage = "tr-TR";
                    break;
                case "Vietnamese":
                    outputLanguage = "vi-VN";
                    break;
                case "Ukrainian":
                    outputLanguage = "ua-UA";
                    break;
                default:
                    outputLanguage = "ru-RU";
                    break;
            }
            #endregion 

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vb-audio.com/Cable/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
