using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class TesteHelper
    {
        public static string PastaDoExecutavel =>
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
