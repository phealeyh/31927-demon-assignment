using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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



    class PatternGenerator
    {
        private Cell[][] rectangleMatrix;
        private const int ROWS = 240;
        private const int COLUMNS = 320;

        public PatternGenerator(Cell[][] rectMatrix)
        {
            rectangleMatrix = rectMatrix;
        }




        public Cell[][] generatePattern(string rule)
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
            return rectangleMatrix;
        }



        private void generateOrthogonalPattern()
        {
            //go through 2d matrix
            for(int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    State nextState = rectangleMatrix[row][column].getCurrentState;
                    //send in the cell for comparison
                    if (nextStateExists(getOrthogonalCells(row,column), nextState))
                    {
                        rectangleMatrix[row][column].setState(nextState);
                    }

                }
            }
        }

        private Cell[] getOrthogonalCells(int row, int col)
        {
            //includes top, right , bottom and left
            Cell[] positionalCells = new Cell[4];
            for (int i = 0; i < positionalCells.Length; i++)
            {
                positionalCells[i] = new Cell();
            }
            //get the top cell
            positionalCells[0] = rectangleMatrix[row + (ROWS - 1) % ROWS][col];
            //get the bottom cell
            positionalCells[1] = rectangleMatrix[row + 1 % ROWS][col];
            //get the left cell
            positionalCells[2] = rectangleMatrix[row][col + (COLUMNS - 1) % COLUMNS];
            //get the right cell
            positionalCells[3] = rectangleMatrix[row][col + 1 % COLUMNS];
            return positionalCells;
        }

        private bool nextStateExists(Cell[] targetCells, State nextState)
        {
            for(int i = 0; i < targetCells.Length; i++)
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

    }

}
