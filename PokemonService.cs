using RestSharp;
using System.Net; 
using System.Text.Json;
using System.Threading.Tasks;

public class PokemonService
{
    private readonly RestClient _client;
    public PokemonService() { _client = new RestClient("https://pokeapi.co/api/v2/"); }

    public async Task<PokemonSpeciesDto?> BuscarEspeciePorNome(string nomeEspecie)
    {
        var request = new RestRequest($"pokemon/{nomeEspecie.ToLower()}", Method.Get);
        var response = await _client.ExecuteGetAsync(request);

        
        if (!response.IsSuccessful)
        {
         
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"ERRO NA API: Não foi possível conectar ao serviço. {response.ErrorMessage}");
            Console.ResetColor();
            return null; 
        }
       
        if (string.IsNullOrEmpty(response.Content))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("ERRO NA API: A resposta veio sem conteúdo.");
            Console.ResetColor();
            return null;
        }

        return JsonSerializer.Deserialize<PokemonSpeciesDto>(response.Content);
    }
}