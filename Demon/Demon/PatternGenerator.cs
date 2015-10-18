using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon
{

    class PatternGenerator
    {
        private Cell[][] rectangleMatrix;
        private const int ROWS = 240;
        private const int COLUMNS = 320;

        public PatternGenerator(Cell[][] rectangleMatrix)
        {
            this.rectangleMatrix = rectangleMatrix;
        }

        public Cell[][] generatePattern(string rule)
        {
            //go through the cell matrix based on the given rule
            if (rule.Equals("Orthogonal"))
            {
                generateOrthogonalPattern();
            }
            else if (rule.Equals("Diagonal"))
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
            //check state of orthogonal
            for(int row = 0; row < ROWS; row++)
            {
                for(int column = 0; column < COLUMNS; column++)
                {
                    State nextPotentialState = rectangleMatrix[row][column].getNextState;
                    //get next state if one of the states has the next state
                    if (neighboursHaveNextState(row,column,nextPotentialState))
                    {
                        rectangleMatrix[row][column].setState(nextPotentialState);
                        rectangleMatrix[row][column].setPotentialStates();
                    }

                }
            }
        }

        private bool neighboursHaveNextState(int row, int column,State nextPotentialState)
        {
            //loop through all of the neighbours for particular state
            for(int i = 0; i < 4; i++)
            {

            }
            return true;
        }

        private void generateDiagonalPattern()
        {

        }

        private void generateAlternatingPattern()
        {

        }
    }
}
