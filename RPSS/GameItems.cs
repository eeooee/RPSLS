using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSS
{
    class GameItems
    {

        string message;
        public int win;


        public GameItems( int win, string message)
        {
            this.message = message;
            this.win = win;
        }

    }
}
