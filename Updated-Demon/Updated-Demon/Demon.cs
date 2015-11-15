using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updated_Demon
{

    #region
    //Demon container that holds the 3d matrix of the cells
    //implements the ienumerable so that it can loop over
    //each element
    #endregion
    class Demon : IEnumerator
    {

        Bitmap buffer;
        Graphics bufferGraphics, displayGraphics;
        Cell[,] currentMatrix, nextMatrix;
        int rows, columns, cellSide;
        Panel displayPanel;
        bool updatingBitmap = false;


        private void CreateCells()
        {
            currentMatrix = new Cell[rows, columns];
            nextMatrix = new Cell[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    currentMatrix[row, col] = new Cell();
                    nextMatrix[row, col] = new Cell();
                }
            }
        }

        public Demon(int rows, int columns, int cellSide, Panel panel)
        {
            this.rows = rows;
            this.columns = columns;
            this.cellSide = cellSide;
            displayPanel = panel;
            // create buffer resources
            buffer = new Bitmap(columns * cellSide, rows * cellSide);
            bufferGraphics = Graphics.FromImage(buffer);
            CreateCells();
        }

        public object Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        private void DrawDemon()
        {
            // use updatingBitmap to prevent a call to DisplayDemon method 
            // from a form paint event while we are updating the bitmap
            if (!updatingBitmap)
            {
                updatingBitmap = true;
                BuildRectanglesToDraw();

                // use clear to draw all rectangles with state 0
                // faster than drawing all the separate rectangles with fillRectangles
                bufferGraphics.Clear(colors[0]);

                DrawReactanglesToBitmap();

                updatingBitmap = false;
            }
        }



        private void BuildRectanglesToDraw()
        {
            // use the FillRectangles. 
            // makes drawing demon about twice as fast as using fillRectangle method
            for (int row = 0; row < rows; row++)
            {
                BuildRowRectanglesToDraw(row);
            }
        }
        private void BuildRowRectanglesToDraw(int row)
        {
            // a row is often made up of sections of cells with the same state
            // it is faster to draw this as one rectangle than multiple smaller rectangles
            // seems to work very well for alternating rule

            int state, col, end, y, width;
            
            y = row * cellSide;
            for (col = 0; col < columns;)
            {
                state = currentMatrix[row, col].State;

                // find section to draw
                end = col + 1;
                while (end < columns && currentMatrix[row, end].State == state) end++;

                // create rectangle for section
                if (state != 0)
                {
                    // don't worry about state 0. will handle this a different way
                    width = (end - col) * cellSide;
                    currentMatrix[state].Add(new Rectangle(col * cellSide, y, width, cellSide));
                }

                col = end;
            }
        }

        private void DrawReactanglesToBitmap()
        {
            // draw all the lists of rectangles to bitmap using fillRectangles method
            for (int state = 1; state < Cell.NUM_STATE; state++)
            {
                if (stateRect[state].Count > 0)
                {
                    //bufferGraphics.FillRectangles(brushes[state], stateRect[state].ToArray());
                    stateRect[state].Clear();
                }
            }
        }

        public void DisplayDemon()
        {
            // draw bitmap to panel
            if (!updatingBitmap)
            {
                // only do this if we aren't updating the bitmap
                displayGraphics.DrawImageUnscaled(buffer, 0, 0);
            }
        }

        private void RandomiseCells(int seed)
        {
            Random rnd = new Random(seed);
            int row, col;

            for (row = 0; row < rows; row++)
            {
                for (col = 0; col < columns; col++)
                {
                    // set new cell state to random state
                    currentMatrix[row, col].State = rnd.Next(Cell.NUM_STATE);
                }
            }
        }

        public void RunGeneration()
        {
            if (demonRules == rules.orthoganol)
            {
                ApplyOrthogonalRules();
            }
            else if (demonRules == rules.diagonal)
            {
                ApplyDiagonalRules();
            }
            else
            {
                ApplyOrthogonalRules();
                ApplyDiagonalRules();
            }
            DrawDemon();
            numGen++;
        }
    }
}
