using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Demon
{

    enum State
    {
        ZERO,
        ONE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN
    };

    class Cell
    {
        private Rectangle rect;
        private State currentState, nextState;


        public Cell(Point location, Size size)
        {
            rect = new Rectangle(location, size);
            currentState = new State();
            nextState = new State();
        }

        public Cell()
        {
            rect = new Rectangle();
            currentState = new State();
            nextState = new State();

        }


        public State getCurrentState
        {
            get { return currentState; }
        }

        public void setState(State state)
        {
            currentState = state;
            setPotentialStates();
        }


        public void setStateRandomly(int generatedNumber)
        {
            switch (generatedNumber)
            {
                case 0:
                    currentState = State.ZERO;
                    break;
                case 1:
                    currentState = State.ONE;
                    break;
                case 2:
                    currentState = State.TWO;
                    break;
                case 3:
                    currentState = State.THREE;
                    break;
                case 4:
                    currentState = State.FOUR;
                    break;
                case 5:
                    currentState = State.FIVE;
                    break;
                case 6:
                    currentState = State.SIX;
                    break;
                case 7:
                    currentState = State.SEVEN;
                    break;
            }
            setPotentialStates();
        }

        private void setPotentialStates()
        {
            if (currentState == State.ZERO) nextState = State.ONE;
            else if (currentState == State.ONE) nextState = State.TWO;
            else if (currentState == State.TWO) nextState = State.THREE;
            else if (currentState == State.THREE) nextState = State.FOUR;
            else if (currentState == State.FOUR) nextState = State.FIVE;
            else if (currentState == State.FIVE) nextState = State.SIX;
            else if (currentState == State.SIX) nextState = State.SEVEN;
            //return next state for the color SEVEN
            else nextState = State.ZERO;

        }

        public State getNextState()
        {
            return nextState;
        }

        public void setRectangle(Rectangle r)
        {
            rect = r;
        }

        public Cell getCell
        {
            get { return this; }
        }


        public Rectangle rectangle
        {
            get { return rect; }
        }


    }
}
