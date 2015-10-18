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
            return rectangleMatrix;
        }
    }
}
