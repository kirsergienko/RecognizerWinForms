using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recognizer
{
    public partial class Form1 : Form
    {
        private bool check = true;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }

        private async Task Start()
        {
            check = true;

            button2.Enabled = true;

            while (check)
            {
                NewRecognizer newRecognizer = new NewRecognizer();

                string recognizedText = await newRecognizer.StartRecognize("en-US");

                Translate(recognizedText);

            }
        }

        private async Task Translate(string recognizedText)
        {
            string translatedText = await Translator.Translate(recognizedText, "en-US");

            Action action = new Action(() =>
            {
                textBox1.Text += translatedText + " ";
            });

            Invoke(action);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            check = false;

            button2.Enabled = false;

        }
    }
}
