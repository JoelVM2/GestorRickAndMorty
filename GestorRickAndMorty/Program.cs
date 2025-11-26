using GestorRickAndMorty.Controller;
using GestorRickAndMorty.Model;
using System;
using System.Text.Json;
using System.Threading.Tasks;

using static GestorRickAndMorty.View.CharacterView;
namespace GestorRickAndMorty
{
    public class Program
    {
        static List<SavedItem>  characterList = new List<SavedItem>();

        static async Task Main(string[] args)
        {
            while (true)
            {
                try
                {
                    ShowMenu();
                    int? opc = Convert.ToInt32(Console.ReadLine());
                    if (opc is null) continue;
                    switch (opc)
                    {
                        case 1:
                            GetCharacter();
                            break;
                        case 2:
                            ShowList();
                            break;
                        case 3:
                            Console.WriteLine("Agregamos nombres a la Lista API");
                            
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido un error, vuelve a intentarlo"); ;
                }
            }
        }
        public async static void GetCharacter()
        {
            CharacterController controller = new CharacterController();
            Console.WriteLine("Introduce el nombre del personaje que quieres mostrar.");
            string name = Console.ReadLine();
            SavedItem character = await controller.GetCharacterAsync(name);
            ShowCharacter(character);
            Console.WriteLine("¿Quieres guardarlo en tu lista? (s/n)");
            string confirmation = Console.ReadLine();

            ApiResponse? apiResponse = new ApiResponse();
            while (string.IsNullOrEmpty(confirmation))
            {
                Console.WriteLine("No se puede dejar vacio, introduce el nombre otra vez");
                confirmation = Console.ReadLine();
            }

            if (confirmation == "s")
            {
                characterList.Add(character);
                Console.WriteLine("Guardado");
            }

        }
    }
}
