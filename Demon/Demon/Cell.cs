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
        private State previousState, currentState, nextState;
        public Cell(Point location, Size size)
        {
            rect = new Rectangle(location, size);
            currentState = new State();
            previousState = new State();
            nextState = new State();
        }



        public void setPotentialStates()
        {

            switch (currentState)
            {
                case State.RED:
                    previousState = State.YELLOW;
                    nextState = State.GREEN;
                    break;
                case State.GREEN:
                    previousState = State.RED;
                    nextState = State.BLUE;
                    break;
                case State.BLUE:
                    previousState = State.GREEN;
                    nextState = State.LIGHTGREEN;
                    break;
                case State.LIGHTGREEN:
                    previousState = State.BLUE;
                    nextState = State.DARKGREEN;
                    break;
                case State.DARKGREEN:
                    previousState = State.LIGHTGREEN;
                    nextState = State.ORANGE;
                    break;
                case State.ORANGE:
                    previousState = State.DARKGREEN;
                    nextState = State.PURPLE;
                    break;
                case State.PURPLE:
                    previousState = State.ORANGE;
                    nextState = State.YELLOW;
                    break;
                case State.YELLOW:
                    previousState = State.PURPLE;
                    nextState = State.RED;
                    break;
            }
        }

        public State getCurrentState
        {
            get { return currentState; }
        }

        public void setState(State state)
        {
            currentState = state;
        }

        public State getPreviousState
        {
            get { return previousState; }
        }

        public State getNextState
        {
            get { return nextState; }
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
