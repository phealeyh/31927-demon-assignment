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
            //go through 2d matrix
            for (int row = 1; row < ROWS; row++)
            {
                for (int column = 1; column < COLUMNS; column++)
                {
                    State nextState = currentGeneration[row][column].nextState();
                    //send in the cell for comparison
                    if (nextStateExists(getOrthogonalCells(row, column), nextState))
                    {
                        currentGeneration[row][column].setState(nextState);
                    }

                }
            }
        }

        private Cell[] getOrthogonalCells(int row, int col)
        {
            //includes top, right , bottom and left
            Cell[] positionalCells = new Cell[4];
            //get the top cell
            int top = (row + ROWS - 1) % ROWS;
            int bottom = (row + 1) % ROWS;
            int left = (col + COLUMNS - 1) % COLUMNS;
            int right = (col + 1) % COLUMNS;
            
            //get the top cell
            positionalCells[0] = currentGeneration[top][col];
            //get the bottom cell
            positionalCells[1] = currentGeneration[row + 1][col];
            //get the left cell
            positionalCells[2] = currentGeneration[row][col - 1];
            //get the right cell
            positionalCells[3] = currentGeneration[row][col + 1];
            return positionalCells;
        }

        private bool nextStateExists(Cell[] targetCells, State nextState)
        {
            for (int i = 0; i < targetCells.Length; i++)
            {
                if (targetCells[i].getCurrentState == nextState) return true;
            }
            return false;
        }



        private void generateDiagonalPattern()
        {

        }

        private void generateAlternatingPattern()
        {

        }

        public Cell[][] getCells
        {
            get { return currentGeneration; }
        }



    }
}
