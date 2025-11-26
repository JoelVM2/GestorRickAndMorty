using GestorRickAndMorty.Model;
using System;
using System.Collections.Generic;

namespace GestorRickAndMorty.View
{
    internal class CharacterView
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Rick And Morty =====");
            Console.WriteLine("1. Buscar personaje por nombre");
            Console.WriteLine("2. Listar personajes guardados");
            Console.WriteLine("3. Salir");
            Console.WriteLine("==========================");
        }

        public static void ShowCharacter(SavedItem character)
        {
            Console.Clear();
            Console.WriteLine($"Nombre: {character.Name}");
            Console.WriteLine($"Estado: {character.Status}");
            Console.WriteLine($"Especie: {character.Species}");
            Console.WriteLine($"Género: {character.Gender}");
        }

        public static void ShowList(List<SavedItem> list)
        {
            Console.Clear();
            Console.WriteLine("=== MIS PERSONAJES ===");

            if (list.Count == 0)
            {
                Console.WriteLine("No tienes personajes guardados todavía.");
                return;
            }

            int index = 1;
            foreach (var item in list)
            {
                Console.WriteLine($"{index}. {item.Name} ({item.Species} - {item.Status})");
                index++;
            }
        }
    }
}
