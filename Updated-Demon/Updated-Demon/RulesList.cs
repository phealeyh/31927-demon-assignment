using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updated_Demon
{
    static class RulesList
    {
        static string[] rules = { "Orthogonal", "Diagonal",
            "Alternating"};

        static public IEnumerator<string> GetEnumerator()
        {
           for(int i = 0; i < rules.Length; i++)
            {
                yield return rules[i];
            }
        }

        static public string[] Rules
        {
            get { return rules; }
            set { rules = value; }
        }

    }
}
