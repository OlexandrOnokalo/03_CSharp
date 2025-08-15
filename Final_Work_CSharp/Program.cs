using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace Final_Work_CSharp
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            MenuDictionaries menu = new MenuDictionaries();
            menu.StartProgram();

        }
    }
}
