using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
