using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Recognizer
{
    public class NewRecognizer
    {
        private SpeechRecognitionResult result;
        private string deviceID;

        public async Task<string> StartRecognize(string inputLanguage)
        {
            ProfanityOption profanityOption = ProfanityOption.Raw;
            var speechConfig = SpeechConfig.FromSubscription("52304639cdad40e28580855cc618857a", "eastus");
            speechConfig.SetProfanity(profanityOption);
            await FromMic(speechConfig, inputLanguage);
            return result.Text;

        }

        private async Task FromMic(SpeechConfig speechConfig, string inputLanguage)
        {
            await Task.Run(() =>
            {
                deviceID = AudioDevices.GetDeviceID()["CABLE Output (VB-Audio Virtual Cable)"];
            }); 

            using var audioConfig = AudioConfig.FromMicrophoneInput(deviceID);

            using var recognizer = new SpeechRecognizer(speechConfig, inputLanguage, audioConfig);

            result = await recognizer.RecognizeOnceAsync();

        }
    }
}