using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Recognizer
{
    class RecognizeFromMic
    {
        private SpeechRecognitionResult result;

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

            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();

            using var recognizer = new SpeechRecognizer(speechConfig, inputLanguage, audioConfig);

            result = await recognizer.RecognizeOnceAsync();

        }
    }
}
