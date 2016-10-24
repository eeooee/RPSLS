using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSS
{
    class Player
    {
       public int wins;
        public string name;
        public int selection;

       public Player()
        {
            wins = 0; 
        }

       
        public void AddWin()
        {
            this.wins = wins + 1;
        }

       public virtual int MakeSelection()
        {
            return this.selection;
        }

        public void SetName()
        {
            Console.WriteLine("\t What would you like to be called?");
            name = Console.ReadLine();
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
