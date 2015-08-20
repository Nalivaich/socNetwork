using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MyTextService: ITextService
    {
        public string GetText(string text)
        {
            return string.Format("U input string {0}", text);
        }
    }
}
