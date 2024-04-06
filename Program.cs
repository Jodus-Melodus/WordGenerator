class Program
{
    public static void Main(string[] args)
    {
        WordGenerator generator = new(string.Join(' ', File.ReadAllLines("data.txt")));

        Random random = new();
        for (int i = 0; i < int.Parse(args[0]); i++)
        {
            Console.WriteLine(generator.Generate(8));
        }
    }
}