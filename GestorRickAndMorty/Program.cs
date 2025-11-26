using GestorRickAndMorty.Controller;
using GestorRickAndMorty.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static GestorRickAndMorty.View.CharacterView;

namespace GestorRickAndMorty
{
    public class Program
    {
        static List<SavedItem> characterList = new List<SavedItem>();

        static async Task Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                Console.Write("Opción: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int opc))
                {
                    Console.WriteLine("Introduce un número válido.");
                    continue;
                }

                switch (opc)
                {
                    case 1:
                        await GetCharacter();
                        break;

                    case 2:
                        ShowList(characterList);
                        Console.WriteLine("\nPulsa ENTER para volver al menú...");
                        Console.ReadLine();  // <-- pausa solo aquí
                        break;

                    case 3:
                        Console.WriteLine("Saliendo...");
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            }
        }

        public async static Task GetCharacter()
        {
            CharacterController controller = new CharacterController();
            Console.WriteLine("Introduce el nombre del personaje:");
            string name = Console.ReadLine() ?? "";

            SavedItem character = await controller.GetCharacterAsync(name);

            if (character == null)
            {
                Console.Clear();
                Console.WriteLine("Personaje no encontrado.");
                return;
            }

            ShowCharacter(character);

            Console.WriteLine("\n¿Quieres guardarlo en tu lista? (s/n)");
            string confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation == "s")
            {
                characterList.Add(character);
                Console.WriteLine("Guardado correctamente.");
            }
        }
    }
}
