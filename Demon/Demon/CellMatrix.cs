using System;
using System.Collections.Generic;
using System.Linq;
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



    class CellMatrix
    {
        private Cell[][] currentGeneration;
        private const int ROWS = 240;
        private const int COLUMNS = 320;

        public CellMatrix()
        {
            initialiseArray();
        }

        private void initialiseArray()
        {
            currentGeneration = new Cell[ROWS][];
            for (int row = 0; row < ROWS; row++)
            {
                currentGeneration[row] = new Cell[COLUMNS];
            }
        }




        public void generateNextGeneration(String rule)
        {
            //go through the cell matrix based on the given rule
            if (rule.Equals(Rule.Orthogonal.ToString()))
            {
                generateOrthogonalPattern();
            }
            else if (rule.Equals(Rule.Diagonal.ToString()))
            {
                generateDiagonalPattern();
            }
            else
            {
                generateAlternatingPattern();
            }
        }

        private void generateOrthogonalPattern()
        {
            Cell[][] temp = currentGeneration;
            //go through 2d matrix
            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    Cell cell = currentGeneration[row][column];
                    if (nextStateExistsOrthogonally(row, column))
                    {
                        cell.setState(cell.nextState());
                        temp[row][column] = cell;
                    }
                }
            }
            currentGeneration = temp;
        }

        private bool nextStateExistsOrthogonally(int row, int col)
        {
            Cell cell = currentGeneration[row][col];
            //includes top, right , bottom and left
            //get the top cell
            int top = (row + ROWS - 1) % ROWS;
            int bottom = (row + 1) % ROWS;
            int left = (col + COLUMNS - 1) % COLUMNS;
            int right = (col + 1) % COLUMNS;

            //get the top cell
            if (currentGeneration[top][col].getCurrentState == cell.nextState()) { return true; }
            //get the bottom cell
            else if (currentGeneration[bottom][col].getCurrentState == cell.nextState()) { return true; }
            //get the left cell
            else if (currentGeneration[row][left].getCurrentState == cell.nextState()) { return true; }
            //get the right cell
            else if (currentGeneration[row][right].getCurrentState == cell.nextState()) { return true; }

            return false;
        }




        private void generateDiagonalPattern()
        {
            Cell[][] temp = currentGeneration;
            //go through 2d matrix
            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    Cell cell = currentGeneration[row][column];
                    if (nextStateExistsDiagonally(row, column))
                    {
                        temp[row][column].setState(cell.nextState());
                    }
                }
            }
            currentGeneration = temp;

        }

        private bool nextStateExistsDiagonally(int row, int col)
        {
            Cell cell = currentGeneration[row][col];
            //includes top, right , bottom and left
            //get the top cell
            int top = (row + ROWS - 1) % ROWS;
            int bottom = (row + 1) % ROWS;
            int left = (col + COLUMNS - 1) % COLUMNS;
            int right = (col + 1) % COLUMNS;

            //get the top cell
            if (currentGeneration[top][right].getCurrentState == cell.nextState()) return true;
            else if (currentGeneration[top][left].getCurrentState == cell.nextState()) return true;
            else if (currentGeneration[bottom][left].getCurrentState == cell.nextState()) return true;
            else if (currentGeneration[bottom][right].getCurrentState == cell.nextState()) return true;
            else return false;
        }




        private void generateAlternatingPattern()
        {

        }

        public Cell[][] getCells
        {
            get { return currentGeneration; }
        }


        public int GetCellHash()
        {
            int hash = 0, celval;

            for (int row = 0; row < ROWS; row++)
            {
                for(int column = 0; column < COLUMNS; column++)
                {
                    celval = (int)currentGeneration[row][column].getCurrentState;
                    hash += ((row + 1) * celval);
                }
            }
            return hash;
        }


    }
}
