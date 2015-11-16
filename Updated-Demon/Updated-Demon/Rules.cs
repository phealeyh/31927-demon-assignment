using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updated_Demon
{
    class RulesList
    {
        string[] rules = { "Orthogonal", "Diagonal",
            "Alternating"};

        public IEnumerable<string> GetColors()
        {
            for (int i = 0; i < rules.Length; i++)
            {
                yield return rules[i];
            }
        }

        public string[] Rules
        {
            get { return rules; }
            set { rules = value; }
        }

    }
}
