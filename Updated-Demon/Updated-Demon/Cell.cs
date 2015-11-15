using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updated_Demon
{
    class Cell
    {
        public const int NUM_STATE = 8;

        int state;

        Rectangle rectangle;


        public Cell()
        {
            state = 0;
        }

        public Cell(int s)
        {
            state = s;
        }

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }


        public int NextState
        {
            //uses wrap around to get the first number if at the last number
            get { return (state + 1) % NUM_STATE; }
        }


        public void MakeNextState()
        {
            state = NextState;
        }
    }
}
