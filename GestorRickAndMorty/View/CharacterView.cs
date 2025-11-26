using GestorRickAndMorty.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestorRickAndMorty.View
{
    internal class CharacterView
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Buscar personaje por nombre");
            Console.WriteLine("2. Listar personajes guardados");
            Console.WriteLine("3. Salir");
            Console.WriteLine("");
        }
        public static void ShowCharacter(SavedItem character)
        {
            Console.Clear();
            Console.WriteLine($"Nombre: {character.Name}");
            Console.WriteLine($"Estado: {character.Status}");
            Console.WriteLine($"Especie: {character.Species}");
            Console.WriteLine($"Género: {character.Gender}");
        }
        public static void ShowList()
        {

            
            
        }
    }
}
