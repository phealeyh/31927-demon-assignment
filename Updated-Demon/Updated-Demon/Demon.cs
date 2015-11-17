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
        string colorPalette;

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

        private void ApplyOrthogonalRules()
        {
            foreach(Cell cell in currentMatrix)
            {

                int row = cell.Row, column = cell.Column;
                int nextState = cell.NextState;
                if(StateExistsOrthogonally(nextState,row,column))
                    cell.SetNextState();
            }
        }

        private bool StateExistsOrthogonally(int nextState, int row, int col)
        {
            int top = (row + rows - 1) % rows;
            int bottom = (row + 1) % rows;
            int left = (col + columns - 1) % columns;
            int right = (col + 1) % columns;

            return currentMatrix[top,col].State == nextState ||
                currentMatrix[bottom,col].State == nextState ||
                currentMatrix[row,left].State == nextState ||
                currentMatrix[row,right].State == nextState;
        }

        private void ApplyDiagonalRules()
        {
            foreach (Cell cell in currentMatrix)
            {

                int row = cell.Row, column = cell.Column;
                int nextState = cell.NextState;
                if (StateExistsDiagonally(nextState, row, column))
                    cell.SetNextState();
            }
        }

        private bool StateExistsDiagonally(int nextState, int row, int col)
        {
            int top = (row + rows - 1) % rows;
            int bottom = (row + 1) % rows;
            int left = (col + columns - 1) % columns;
            int right = (col + 1) % columns;
            return currentMatrix[top, right].State == nextState ||
                currentMatrix[bottom, right].State == nextState ||
                currentMatrix[bottom, left].State == nextState ||
                currentMatrix[top, left].State == nextState;
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
            string[] colorName = Colors.GetSpecifiedPalette(colorPalette);
            foreach (Cell cell in currentMatrix)
            {
                string color = colorName[cell.State];
                bufferGraphics.FillRectangle(new SolidBrush(Color.FromName(color)), cell.Rectangle);
            }
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
            bufferGraphics = Graphics.FromImage(buffer);
            displayPanel = panel;
            displayGraphics = displayPanel.CreateGraphics();

            CreateCells();
        }

        public void Reset(int seed)
        {
            numGen = seed;
            RandomiseCells(seed);
            DrawDemon();
            DisplayDemon();
        }




        public void RunGeneration(string rule)
        {
            if (rule.Equals("Orthogonal"))
            {
                ApplyOrthogonalRules();
            }
            else if (rule.Equals("Diagonal"))
            {
                ApplyDiagonalRules();
            }
            //check rule and run generation
            DrawDemon();
        }

        public void SetPalette(string color)
        {
            colorPalette = color;
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

        public uint GetHash()
        {
            int state, hash = 0;

            foreach(Cell cell in currentMatrix)
            {
                state = cell.State;
                hash ^= ((1 + cell.Row * cell.Column) * (state + 1));
            }
            return (uint)hash;
        }

        #endregion public metohds
    }

}
