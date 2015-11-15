using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Demon
{
    enum Rule
    {
        Orthogonal,
        Diagonal,
        Alternating
    };



    class PatternGenerator
    {
        private Cell[,] currentGeneration, nextGeneration;
        private int rows;
        private int columns;

        public PatternGenerator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            currentGeneration = new Cell[rows, columns];
            nextGeneration = new Cell[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    currentGeneration[row, col] = new Cell();
                    nextGeneration[row, col] = new Cell();
                }
            }
        }


        public void generateOrthogonalPattern()
        {
            //set the states and then for loop through each one
            State[,] temp = new State[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Cell cell = currentGeneration[row, col];
                    Cell nextCell = nextGeneration[row, col];
                    if (nextStateExistsOrthogonally(row, col))
                    {
                        nextCell.setState(cell.getNextState());
                    }
                    temp[row, col] = nextCell.getCurrentState;
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    currentGeneration[row, col].setState(temp[row, col]);
                }
            }
        }


        public void generateDiagonalPattern()
        {
            //set the states and then for loop through each one
            State[,] temp = new State[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Cell cell = currentGeneration[row, col];
                    Cell nextCell = nextGeneration[row, col];
                    if (nextStateExistsDiagonally(row, col))
                    {
                        nextCell.setState(cell.getNextState());
                    }
                    temp[row, col] = nextCell.getCurrentState;
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    currentGeneration[row, col].setState(temp[row, col]);
                }
            }
        }


        public bool nextStateExistsOrthogonally(int row, int col)
        {
            Cell cell = currentGeneration[row, col];
            //includes top, right , bottom and left
            //get the top cell
            int top = (row + rows - 1) % rows;
            int bottom = (row + 1) % rows;
            int left = (col + columns - 1) % columns;
            int right = (col + 1) % columns;
            //get the top cell
            if (currentGeneration[top, col].getCurrentState == cell.getNextState())
            {
                return true;
            }
            //get the bottom cell
            else if (currentGeneration[bottom, col].getCurrentState == cell.getNextState())
            { 
                return true;
            }
            //get the left cell
            else if (currentGeneration[row, left].getCurrentState == cell.getNextState())
            {
                return true;
            }
            //get the right cell
            else if (currentGeneration[row, right].getCurrentState == cell.getNextState())
            {
                return true;
            }

            else
            {
                return false;
            }
        }


        public bool nextStateExistsDiagonally(int row, int col)
        {
            Cell cell = currentGeneration[row, col];

            //includes top, right , bottom and left
            //get the top cell
            int top = (row + rows - 1) % rows;
            int bottom = (row + 1) % rows;
            int left = (col + columns - 1) % columns;
            int right = (col + 1) % columns;

            //get the top cell
            if (currentGeneration[top, right].getCurrentState == cell.getNextState())
            {
                return true;
            }
            else if (currentGeneration[top, left].getCurrentState == cell.getNextState()) 
            {
                return true; 
            }
            else if (currentGeneration[bottom, left].getCurrentState == cell.getNextState())
            {
                return true;
            }
            else if (currentGeneration[bottom, right].getCurrentState == cell.getNextState())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Cell[,] getCells
        {
            get { return currentGeneration; }
        }


        public Cell[,] getNextGeneration
        {
            get { return nextGeneration; }
        }


    }

}
