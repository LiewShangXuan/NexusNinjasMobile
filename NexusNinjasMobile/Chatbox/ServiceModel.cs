using Mscc.GenerativeAI;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NexusNinjasMobile.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey; // This should hold the API key securely

        public string GeminiPro { get; private set; }

        public ApiService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey; // Assign the passed API key to the field
        }

        public async Task<string> Test(string prompt)
        {
            try
            {

                var googleAI = new GoogleAI(apiKey: "AIzaSyDmNB0j3KIs6vHxq0puBi2ZLdNGoPwIUJs");
                var model = googleAI.GenerativeModel(model: GeminiPro);

                var response = await model.GenerateContent(prompt);
                return response.Text;
            } 
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Call this method to connect to the Gemini AI model
        public async Task<string> GetResponseFromGeminiModelAsync(string userInput)
        {
            // Example API key and URL
            string apiKey = "AIzaSyDmNB0j3KIs6vHxq0puBi2ZLdNGoPwIUJs";
            string requestUrl = $"https://colab.research.google.com/drive/1ACftS05ZyIC7oht6pCJuWnxwg7e9ln0E?usp=sharing{Uri.EscapeDataString(userInput)}";

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            try
            {
                var response = await _httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent; // Return the successful response content
                }
                else
                {
                    // Log the error response
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {response.StatusCode} - {errorResponse}");
                    return "Error: Unable to connect to the AI model."; // Provide a user-friendly error message
                }
            }
            catch (HttpRequestException e)
            {
                // Log the exception
                Console.WriteLine($"Exception: {e.Message}");
                return "Error: Unable to connect to the AI model."; // Provide a user-friendly error message
            }
        }
    }
}
