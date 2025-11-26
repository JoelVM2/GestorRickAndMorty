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
                // Usamos Uri.EscapeDataString para nombres con espacios o caracteres especiales
                var url = $"https://rickandmortyapi.com/api/character/?name={Uri.EscapeDataString(name)}";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error en la respuesta HTTP: {response.StatusCode}");
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                ApiResponse? apiResponse = JsonSerializer.Deserialize<ApiResponse>(content);

                if (apiResponse?.Results == null || apiResponse.Results.Count == 0)
                {
                    Console.WriteLine("No se encontraron personajes.");
                    return null;
                }

                // Usamos FirstOrDefault para evitar excepción si no hay resultados
                Character character = apiResponse.Results.FirstOrDefault();
                if (character == null)
                    return null;

                Console.WriteLine($"Personaje encontrado: {character.Name}");

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
                // Mostramos el error para depuración
                Console.WriteLine($"Error al obtener personaje: {ex.Message}");
                return null;
            }
        }
    }
}
