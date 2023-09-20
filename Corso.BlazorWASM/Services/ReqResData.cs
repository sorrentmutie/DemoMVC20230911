using Corso.Core.ReqRes;
using System.Text.Json;

namespace Corso.BlazorWASM.Services
{
    public class ReqResData : IReqResData
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ReqResData(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ReqResResponse?> GetDataAsync()
        {
            var httpClient = 
                httpClientFactory.CreateClient("reqres");

            var responseMessage = await httpClient
                .GetAsync("users", 
                   HttpCompletionOption.ResponseHeadersRead);

            if(responseMessage.IsSuccessStatusCode)
            {
                var content =
                  await  responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ReqResResponse>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            } else
            {
                return null;
            }


            throw new NotImplementedException();
        }
    }
}
