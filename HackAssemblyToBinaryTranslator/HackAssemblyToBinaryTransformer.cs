using System;
using System.Collections.Generic;
using System.IO;

namespace HackAssemblyToBinaryTranslator
{

    class HackAssemblyToBinaryTransformer
    {
        private readonly Instructions _instructions;
        private readonly LineSearcher _lineSearcher;
        private readonly List<string> _assemblyCommands;

        public HackAssemblyToBinaryTransformer(Instructions instructions, List<string> assemblyCommands, LineSearcher lineSearcher)
        {
            _instructions = instructions;
            _assemblyCommands = assemblyCommands;
            _lineSearcher = lineSearcher;
        }

        public void TransformAssemblyToBinary()
        {
            IDictionary<string, int> labels = _lineSearcher.FindAllLabels(_assemblyCommands);
            IDictionary<string, int> variables = _lineSearcher.FindAllVariablesThatIsNotLabelReference(_assemblyCommands, labels, _instructions.predefinedA);
            IDictionary<string, int> labelsVariablesAndPredefined = AddLabelsAndVariablesToPredefinedA(labels, variables);

            List<string> assemblyCommandsWithNoLabels = RemoveLabelsFromAssemblyCommands(_assemblyCommands);
            List<string> result = new List<string>();

            foreach (var instruction in assemblyCommandsWithNoLabels)
            {
                if (instruction.StartsWith("@"))
                {
                    string aInstructionAsBinary = GetAinstructionAsBinary(instruction, labelsVariablesAndPredefined);
                    result.Add(aInstructionAsBinary);
                }
                else
                {
                   string cInstructionAsBinary = GetCInstructionAsBinary(instruction);
                    result.Add(cInstructionAsBinary);
                }
            }
            File.WriteAllLines(@"../../../binary.txt", result);
        }

        public string GetCInstructionAsBinary(string instruction)
        {
            string opCode = "111";
            string dest = "000";
            string jump = "000";
            string comp = "";

            string[] splittedInstruction;

            if (instruction.Contains("="))
            {
                splittedInstruction = instruction.Split("=");

                dest = _instructions.GetDestInBinary(splittedInstruction[0]);
                comp = _instructions.GetCompInBinary(splittedInstruction[1]);
            }
            else if (instruction.Contains(";"))
            {
                splittedInstruction = instruction.Split(";");
                comp = _instructions.GetCompInBinary(splittedInstruction[0]);
                jump = _instructions.GetJumpInBinary(splittedInstruction[1]);
            }
            return opCode + comp + dest + jump;
        }

        public IDictionary<string, int> AddLabelsAndVariablesToPredefinedA(IDictionary<string, int> labels, IDictionary<string, int> variables)
        {
            IDictionary<string, int> result = new Dictionary<string, int>(_instructions.predefinedA);

            foreach (var item in variables)
                result.Add(item);

            foreach (var item in labels)
                result.Add(item);

            return result;
        }

        public List<string> RemoveLabelsFromAssemblyCommands(List<string> assemblyCommands)
        {
            List<string> result = new List<string>(assemblyCommands);
            result.RemoveAll(e => e.StartsWith("("));

            return result;
        }

        public string GetAinstructionAsBinary(string instruction, IDictionary<string, int> labelsVariablesAndPredefined)
        {
            string tmp = instruction.Replace("@", "");
            int result = 0;

            if (char.IsLetter(tmp[0]))
            {
                foreach (var item in labelsVariablesAndPredefined)
                    if (item.Key == tmp)
                        result = item.Value;
                return FillRemainingBinaryWithZero(Convert.ToString(result, 2));
            }
            return FillRemainingBinaryWithZero(Convert.ToString(int.Parse(tmp), 2));
        }

        public string FillRemainingBinaryWithZero(string binary)
        {
            int startCount = binary.Length;
            string result = "";

            for (int i = startCount; i < 16; i++)
                result += '0';

            return result + binary;
        }
    }
}
