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
    class Demon 
    {

        Bitmap buffer;
        Graphics bufferGraphics, displayGraphics;
        Cell[,] currentMatrix, nextMatrix;
        int numGen, rows, columns, cellSide;
        Panel displayPanel;
        bool updatingBitmap = false;

        #region Private Methods
        private void CreateCells()
        {
            currentMatrix = new Cell[rows, columns];
            nextMatrix = new Cell[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    currentMatrix[row, col] = new Cell(row, col);
                    nextMatrix[row, col] = new Cell(row,col);
                }
            }
        }



        private IEnumerator<Cell> GetCurrentMatrixIterator()
        {
            for (int row = 0; row < rows; row++)
            {
                for(int col = 0; col < columns; col++)
                {
                    yield return currentMatrix[row, col];
                }
            }
        }

        private IEnumerator<Cell> GetNextMatrixIterator()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    yield return nextMatrix[row, col];
                }
            }
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
                //bufferGraphics.Clear(Color.White);

                DrawReactanglesToBitmap();

                updatingBitmap = false;
            }
        }


        private void BuildRectanglesToDraw()
        {
            // use the FillRectangles. 
            // makes drawing demon about twice as fast as using fillRectangle method
            foreach(Cell cell in currentMatrix)
            {
                cell.Rectangle = new Rectangle(cell.Column * cellSide, cell.Row * cellSide, 
                    cellSide, cellSide);
            }
        }


        private void DrawReactanglesToBitmap()
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            // draw all the lists of rectangles to bitmap using fillRectangles method
            foreach (Cell cell in currentMatrix)
            {
                rectangles.Add(cell.Rectangle);
            }
            bufferGraphics.FillRectangles(new SolidBrush(Color.Yellow), rectangles.ToArray());
        }


        private void RandomiseCells(int seed)
        {
            Random rnd = new Random(seed);
            foreach (Cell cell in currentMatrix)
            {
                cell.State = rnd.Next(Cell.NUM_STATE);
            }
        }
        #endregion
        #region Public Methods
        public Demon(int rows, int columns, int cellSide, Panel panel)
        {
            this.rows = rows;
            this.columns = columns;
            this.cellSide = cellSide;
            // create buffer resources
            buffer = new Bitmap(columns * cellSide, rows * cellSide);
            //buffer = new Bitmap(panel.Width, panel.Height);
            bufferGraphics = Graphics.FromImage(buffer);
            displayPanel = panel;
            displayGraphics = displayPanel.CreateGraphics();

            CreateCells();
        }

        public void Reset(int seed)
        {
            numGen = 0;
            RandomiseCells(seed);
            DrawDemon();
            DisplayDemon();
        }




        public void RunGeneration()
        {
            DrawDemon();
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

        #endregion public metohds
    }

}
