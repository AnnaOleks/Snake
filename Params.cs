using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Params
    {
        private string resourseFolder;
        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString().IndexOf("bin", StringComparison.Ordinal);
            string binfolder = Directory.GetCurrentDirectory().ToString().Substring(0, ind).ToString();
            resourseFolder = binfolder + "Resources\\";
        }
        public string GetResourseFolder()
        {
            return resourseFolder;
        }
    }
}
