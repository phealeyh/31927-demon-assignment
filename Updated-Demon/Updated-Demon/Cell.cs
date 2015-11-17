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
        int row, column;
        Rectangle rectangle;


        public Cell(int row, int column)
        {
            this.row = row;
            this.column = column;
            state = 0;
        }

        public Cell(int state)
        {
            this.state = state;
        }

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
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


        public void SetNextState()
        {
            state = NextState;
        }
    }
}
