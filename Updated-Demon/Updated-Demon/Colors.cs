using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updated_Demon
{
    static class Colors
    {
        static string[] colors = { "Rainbow", "Black-White" };
        private static string[] rainbowColors = { "Red", "Green", "Blue", "LightGreen", "DarkGreen",
            "Orange","Purple","Yellow" };
        private static string[] blackWhiteColors = {"White", "Black", "White", "Black",
        "White","Black","White","Black" };

        static public IEnumerator GetPatternEnumerator(string[] pattern)
        {
            return new ColorEnumerator(pattern);
        }

        static public IEnumerator GetColorsEnumerator()
        {
            return new ColorEnumerator(colors);
        }


        static public string[] ColorList
        {
            get { return colors; }
            set { colors = value; }
        }

        static public string[] RainbowColors
        {
            get { return rainbowColors; }
            set { rainbowColors = value; }
        }

        static public string[] BlackWhiteColors
        {
            get { return blackWhiteColors; }
            set { blackWhiteColors = value; }
        }

        static public string[] GetSpecifiedPalette(string palette)
        {
            if (palette.Equals("Rainbow"))
            {
                return rainbowColors;
            }
            else if (palette.Equals("Black-White"))
            {
                return blackWhiteColors;
            }
            else
            {
                return null;
            }
        }

    }
}
