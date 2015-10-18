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
        }

        private void generateDiagonalPattern()
        {

        }

        private void generateAlternatingPattern()
        {

        }
    }
}
