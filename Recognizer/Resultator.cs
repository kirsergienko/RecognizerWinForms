using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    public static class Resultator
    {
        public static string GetResult(Task<string> task)
        {
            return task.Result;
        }
    }
}
