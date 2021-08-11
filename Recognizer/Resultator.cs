using Microsoft.CognitiveServices.Speech;

namespace Recognizer
{
    public static class Resultator
    {
        public static string GetResult(SpeechRecognitionEventArgs e)
        {
            string result = e.Result.Text;

            return result;
        }

    }
}