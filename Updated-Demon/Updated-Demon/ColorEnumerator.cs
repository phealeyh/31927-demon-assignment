using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updated_Demon
{
    class ColorEnumerator : IEnumerator
    {
        string[] _colors;
        int _position = -1;

        /* Constructor ColorEnumerator
         * ----------------------------
         * This constructor will copy the elements of the
         * given array and copy it onto it's own.
         */
        public ColorEnumerator(string[] theColors)
        {
            _colors = new string[theColors.Length];
            for (int i = 0; i < theColors.Length; i++)
                _colors[i] = theColors[i];
        }
        public object Current
        {
            get
            {
                if (_position == -1)
                    throw new InvalidOperationException();
                if (_position >= _colors.Length)
                    throw new InvalidOperationException();

                return _colors[_position];
            }
        }

        public bool MoveNext()
        {
            if (_position < _colors.Length - 1)
            {
                _position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
