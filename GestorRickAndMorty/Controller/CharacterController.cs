using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace GestorRickAndMorty.Controller
{
    public class CharacterController
    {
        HttpClient client = new HttpClient();
        async Task<JsonDocument?> GetCharacterAsync(string name)
        {
            try
            {
                var response = await

                client.GetAsync($"https://rickandmortyapi.com/api/character/?name={name.ToLower()}");

                if (!response.IsSuccessStatusCode) return null;
                var content = await response.Content.ReadAsStringAsync();
                return JsonDocument.Parse(content);
            }
            catch { return null; }
        }

    }
}
