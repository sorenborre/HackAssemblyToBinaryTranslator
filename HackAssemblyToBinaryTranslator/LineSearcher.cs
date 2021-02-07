using System.Collections.Generic;

namespace HackAssemblyToBinaryTranslator
{
    class LineSearcher
    {
        public IDictionary<string, int> FindAllLabels(List<string> assemblyCommands)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();

            int lineNumber = 0;

            foreach (var line in assemblyCommands)
            {
                if (line.StartsWith("("))
                    result.Add(line.Replace("(", "").Replace(")", ""), lineNumber);
                else
                    lineNumber++;
            }
            return result;
        }

        public IDictionary<string, int> FindAllVariablesThatIsNotLabelReference(List<string> assemblyCommands, IDictionary<string, int> labels, IDictionary<string, int> predefinedA)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();

            int lineNumber = 16;

            foreach (var line in assemblyCommands)
            {
                string trimmedLine = line.Replace("@", "");
                {
                    if (line.StartsWith("@") && !result.ContainsKey(trimmedLine) && !labels.ContainsKey(trimmedLine) && !predefinedA.ContainsKey(trimmedLine) && char.IsLetter(line[1]))
                    {
                        result.Add(trimmedLine, lineNumber);
                        lineNumber++;
                    }
                }
            }
            return result;
        }
    }
}
