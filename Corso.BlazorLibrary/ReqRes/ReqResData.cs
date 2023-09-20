using Corso.Core.ReqRes;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Corso.BlazorLibrary.ReqRes
{
    public class ReqResData : IReqResData
    {
        private readonly IHttpClientFactory httpClientFactory;
        private CancellationTokenSource? cancellationTokenSource;

        public ReqResData(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public void CancelRequest()
        {
            cancellationTokenSource?.Cancel();
        }

        public async Task<ReqResResponse?> GetDataAsync()
        {
            var httpClient = 
                httpClientFactory.CreateClient("reqres");

            cancellationTokenSource = new CancellationTokenSource();

            var responseMessage = await httpClient
                .GetAsync("users", 
                   HttpCompletionOption.ResponseHeadersRead,
                   cancellationTokenSource.Token);

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
        }

        public async Task<ReqResRequest?> PostSomeData(ReqResRequest reqResRequest)
        {
            var httpClient =
                httpClientFactory.CreateClient("reqres");

           var response = await  httpClient.PostAsJsonAsync<ReqResRequest>
                ("users", reqResRequest);

            if(response != null && response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReqResRequest>();
                
            }
            return null;
        }
    }
}
