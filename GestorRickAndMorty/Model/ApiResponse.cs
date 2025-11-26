using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRickAndMorty.Model
{
    internal class ApiResponse
    {
        public List<Character> Results { get; set; } = new();
    }
}
