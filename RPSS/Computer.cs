using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSS
{
    class Computer : Player
    {

        public int rand;
        Random rnd = new Random();

        public Computer()
        {
            name = "Computer";
        }

        public int GetRandom()
        {
            rand = rnd.Next(0, 5);
            return rand;
        }

        public override int MakeSelection()
        {
            this.selection = rnd.Next(0, 5);
            return selection;
        }


       



    }
}

