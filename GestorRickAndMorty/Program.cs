using GestorRickAndMorty.Controller;
using GestorRickAndMorty.Model;
using System;
using System.Text.Json;
using System.Threading.Tasks;

using static GestorRickAndMorty.View.CharacterView;
namespace GestorRickAndMorty
{
    internal class Program
    {
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
                            Console.WriteLine("Filtramos Id API");
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
        }
    }
}
