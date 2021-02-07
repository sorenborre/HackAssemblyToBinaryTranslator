using System.Collections.Generic;

namespace HackAssemblyToBinaryTranslator
{
    class Instructions
    {

        public IDictionary<string, int> predefinedA = new Dictionary<string, int>() {
            { "R0", 0 },
            { "R1", 1 },
            { "R2", 2 },
            { "R3", 3 },
            { "R4", 4 },
            { "R5", 5 },
            { "R6", 6 },
            { "R7", 7 },
            { "R8", 8 },
            { "R9", 9 },
            { "R10", 10 },
            { "R11", 11 },
            { "R12", 12 },
            { "R13", 13 },
            { "R14", 14 },
            { "R15", 15 },
            { "SCREEN", 16384 },
            { "KBD", 24576 },
            { "SP", 0},
            { "LCL", 1},
            { "ARG", 2 },
            { "THIS", 3 },
            { "THAT", 4 }

        };

        public string GetCompInBinary(string line)
        {
            switch (line)
            {
                case "0":
                    return "0101010";
                case "1":
                    return "0111111";
                case "-1":
                    return "0111010";
                case "D":
                    return "0001100";
                case "A":
                    return "0110000";
                case "!D":
                    return "0001101";
                case "!A":
                    return "0110001";
                case "-D":
                    return "0001111";
                case "-A":
                    return "0110011";
                case "D+1":
                    return "0011111";
                case "A+1":
                    return "0110111";
                case "D-1":
                    return "0001110";
                case "A-1":
                    return "0110010";
                case "D+A":
                    return "0000010";
                case "D-A":
                    return "0010011";
                case "A-D":
                    return "0000111";
                case "D&A":
                    return "0000000";
                case "D|A":
                    return "0010101";
                case "M":
                    return "1110000";
                case "!M":
                    return "1110001";
                case "-M":
                    return "1110011";
                case "M+1":
                    return "1110111";
                case "M-1":
                    return "1110010";
                case "D+M":
                    return "1000010";
                case "D-M":
                    return "1010011";
                case "M-D":
                    return "1000111";
                case "D&M":
                    return "1000000";
                case "D|M":
                    return "1010101";
                default:
                    return "0101010";
            }
        }
        public string GetDestInBinary(string line)
        {
            switch (line)
            {
                case "null":
                    return "000";
                case "M":
                    return "001";
                case "D":
                    return "010";
                case "MD":
                    return "011";
                case "A":
                    return "100";
                case "AM":
                    return "101";
                case "AD":
                    return "110";
                case "AMD":
                    return "111";
                default:
                    return "000";
            }
        }

        public string GetJumpInBinary(string line)
        {
            switch (line)
            {
                case "null":
                    return "000";
                case "JGT":
                    return "001";
                case "JEQ":
                    return "010";
                case "JGE":
                    return "011";
                case "JLT":
                    return "100";
                case "JNE":
                    return "101";
                case "JLE":
                    return "110";
                case "JMP":
                    return "111";
                default:
                    return "000";
            }
        }
    }
}
