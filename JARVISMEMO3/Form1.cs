using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JARVISMEMO3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string borges = "";
        static string borgesparaaudio = "";


        private async void button1_Click(object sender, EventArgs e)
        {
            await SynthesizeAudioAsync();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (!textBox1.Text.StartsWith("£"))
            //{
            //    textBox1.Text = string.Concat("£", textBox1.Text);
            //    textBox1.Select(textBox1.Text.Length, 0);
            //}

            borges = textBox1.Text;

        }

        static async Task SynthesizeAudioAsync()
        {




            var config = SpeechConfig.FromSubscription("60997aa2668846c6a7e553b121d271a3", "brazilsouth");
            config.SpeechSynthesisLanguage = "pt-BR";
            using var synthesizer = new SpeechSynthesizer(config);
            await synthesizer.SpeakTextAsync(borges);

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            borges = textBox1.Text;
        }

     

        async static Task FromMic(SpeechConfig speechConfig)
        {
            Application.DoEvents();
            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(speechConfig, "pt-BR", audioConfig);

            // Console.WriteLine("Fale no microfone");
            while (true)
            {
                var result = await recognizer.RecognizeOnceAsync();

                borgesparaaudio = result.Text;



                Form1 form1 = new Form1();
                form1.borges2(borgesparaaudio);


                // Console.WriteLine($"RECOGNIZED: Text={result.Text}");
            }
        }



        private void borges2(string valor)
        {

            Application.DoEvents();

            textBox2.Text = borgesparaaudio;

            Application.DoEvents();



        }


        private void textBox1_TextChanged_1_borges(object sender, EventArgs e)
        {
            textBox2.Text = borgesparaaudio;
            Application.DoEvents();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            var speechConfig = SpeechConfig.FromSubscription("codigo_da_azure_aqui", "brazilsouth");
            speechConfig.EnableDictation();
            await FromMic(speechConfig);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
