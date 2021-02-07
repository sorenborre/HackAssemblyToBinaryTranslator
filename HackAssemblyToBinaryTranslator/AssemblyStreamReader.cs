using System;
using System.IO;
using System.Collections.Generic;

namespace HackAssemblyToBinaryTranslator
{
    public class AssemblyStreamReader
    {
        static public List<string> ReadStream()
        {
            List<string> result = new List<string>();
            try
            {
                using StreamReader sr = new StreamReader("../../../assembly.txt");
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var indexCheck = line.IndexOf("/");
                    if (indexCheck > -1)
                        line = line.Substring(0, indexCheck);

                    if (line != "")
                        result.Add(line.Replace(" ", ""));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
