using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Recognizer
{
    public partial class Form1 : Form
    {
        //start/stop recognizing
        private bool check = true;

        private Settings settings = new Settings();

        public Form1()
        {
            InitializeComponent();

            try
            {
                var userSettings = settings.Load();

                settings.InputLanguage = userSettings.InputLanguage;

                settings.OutputLanguage = userSettings.OutputLanguage;

                comboBox1.SelectedItem = userSettings.InputLanguageName;

                comboBox3.SelectedItem = userSettings.OutputLanguageName;

                checkBox1.Checked = userSettings.FromMicrophone;

            }
            catch (Exception ex)
            {

                settings.InputLanguageName = "English";

                settings.InputLanguage = "en-US";
                
                settings.OutputLanguageName = "Russian";

                settings.OutputLanguage = "ru-RU";

                settings.Save();

                comboBox1.SelectedItem = settings.InputLanguageName;

                comboBox3.SelectedItem = settings.OutputLanguageName;
            }
        }

        #region Main
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();

            historyForm.SetRichTextBox1Value(history);

            historyForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            history.Clear();
        }
        #endregion

        #region Settings
        private void button3_Click(object sender, EventArgs e)
        {
            settings.FromMicrophone = checkBox1.Checked;

            settings.InputLanguageName = comboBox1.Text;

            settings.InputLanguage = SetLanguage(comboBox1.Text);

            settings.OutputLanguageName = comboBox3.Text;

            settings.OutputLanguage = SetLanguage(comboBox3.Text);

            button3.Enabled = false;

            settings.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }
        #endregion

        #region Instructions
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vb-audio.com/Cable/");
        }
        #endregion

    }
}
