using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenAI_API;
using System;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class ChatGPTAPITests
    {
        private OpenAIAPI api;

        [TestInitialize]
        public void Initialize()
        {
            string apiKey = "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";
            api = new OpenAIAPI(apiKey);
        }

        [TestMethod]
        public async Task TestChatGPTAPI()
        {
            string input = "What is the capital of France?";

            var responseString = await api.Completions.GetCompletion(input);
            Console.WriteLine(responseString);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(string.IsNullOrWhiteSpace(responseString));
        }
    }
}
