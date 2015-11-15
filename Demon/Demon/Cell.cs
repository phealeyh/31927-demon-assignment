using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Demon
{
    enum State
    {
        RED,
        GREEN,
        BLUE,
        LIGHTGREEN,
        DARKGREEN,
        ORANGE,
        PURPLE,
        YELLOW
    };

    class Cell
    {
        private Rectangle rect;
        private State currentState;

        public Cell(Point location, Size size)
        {
            rect = new Rectangle(location, size);
            currentState = new State();
        }


        public State nextState()
        {
            if (currentState == State.RED) return State.GREEN;
            else if (currentState == State.GREEN) return State.BLUE;
            else if (currentState == State.BLUE) return State.LIGHTGREEN;
            else if (currentState == State.LIGHTGREEN) return State.DARKGREEN;
            else if (currentState == State.DARKGREEN) return State.ORANGE;
            else if (currentState == State.ORANGE) return State.PURPLE;
            else if (currentState == State.PURPLE) return State.YELLOW;
            //return next state for the color yellow
            else return State.RED;
        }


        public State getCurrentState
        {
            get { return currentState; }
        }

        public void setState(State state)
        {
            currentState = state;
        }


        public void setStateRandomly(int generatedNumber)
        {
            switch (generatedNumber)
            {
                case 0:
                    currentState = State.RED;
                    break;
                case 1:
                    currentState = State.GREEN;
                    break;
                case 2:
                    currentState = State.BLUE;
                    break;
                case 3:
                    currentState = State.LIGHTGREEN;
                    break;
                case 4:
                    currentState = State.DARKGREEN;
                    break;
                case 5:
                    currentState = State.ORANGE;
                    break;
                case 6:
                    currentState = State.PURPLE;
                    break;
                case 7:
                    currentState = State.YELLOW;
                    break;
            }
        }

        public Rectangle rectangle
        {
            get { return rect; }
        }


    }

}
