using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSS
{
    class Human : Player
    {

        public override int MakeSelection()
        {
            string input;
            Console.WriteLine("\t{0}, make a selection!", this.name);
            input = Console.ReadLine();
            this.selection = int.Parse(input);
            return selection;
        }

        
    }
}
