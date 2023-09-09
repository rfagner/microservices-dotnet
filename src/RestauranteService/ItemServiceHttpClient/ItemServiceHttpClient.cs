using RestauranteService.Dtos;
using System.Text;
using System.Text.Json;

namespace RestauranteService.ItemServiceHttpClient
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public ItemServiceHttpClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }
        /// <summary>
        /// Envia uma requisição http para o serviço ItemService
        /// </summary>
        /// <param name="readDto"></param>
        public async void EnviaRestauranteParaItemService(RestauranteReadDto readDto)
        {
            var conteudoHttp = new StringContent
                (
                    JsonSerializer.Serialize(readDto),
                    Encoding.UTF8,
                    "application/json"
                );

            await _client.PostAsync(_configuration["ItemService"] ,conteudoHttp);
        }
    }
}
