namespace HackAssemblyToBinaryTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            HackAssemblyToBinaryTransformer hackAssemblyToBinaryTransformer =
               new HackAssemblyToBinaryTransformer(
                   new Instructions(),
                   AssemblyStreamReader.ReadStream(),
                   new LineSearcher());

            hackAssemblyToBinaryTransformer.TransformAssemblyToBinary();
        }
    }
}
