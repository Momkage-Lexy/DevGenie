using DevGenie.Models;

namespace DevGenie.Services
{
    public interface IOpenAiService

    { 
        public Task<string> GetChatResponse(string message);
    }
}