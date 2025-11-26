using GestorRickAndMorty.Model;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorRickAndMorty.Controller
{
    public class CharacterController
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<SavedItem> GetCharacterAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            Console.WriteLine("Buscando...");

            try
            {
                var url = $"https://rickandmortyapi.com/api/character/?name={Uri.EscapeDataString(name)}";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error en la respuesta HTTP: {response.StatusCode}");
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                ApiResponse? apiResponse = JsonSerializer.Deserialize<ApiResponse>(content, options);

                if (apiResponse?.Results == null || apiResponse.Results.Count == 0)
                {
                    Console.WriteLine("No se encontraron personajes.");
                    return null;
                }

                Character character = apiResponse.Results.FirstOrDefault();
                if (character == null)
                    return null;

                return new SavedItem
                {
                    Name = character.Name,
                    Gender = character.Gender,
                    Species = character.Species,
                    Status = character.Status
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener personaje: {ex.Message}");
                return null;
            }
        }
    }
}
