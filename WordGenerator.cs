class WordGenerator
{
    public string Data;
    public LinkedList<char>[] AdjacencyList = new LinkedList<char>[26];
    public WordGenerator(string Data)
    {
        this.Data = Data;

        for (int i = 0; i < 26; i++)
        {
            AdjacencyList[i] = new(' ');
        }

        for (int i = 0; i < Data.Length; i++)
        {
            if ("abcdefghijklmnopqrstuvwxyz".Contains(Data[i]))
            {
                int c = CharToInt(char.ToLower(Data[i]));

                if (i < Data.Length - 1)
                    if (Data[i + 1] != ' ')
                        AdjacencyList[c].Append(Data[i + 1]);
            }
        }
    }

    public string Generate(int Length)
    {
        string characters = "abcdefghijklmnopqrstuvwxyz";
        Random random = new();
        int randomIndex = random.Next(0, characters.Length);
        string word = characters[randomIndex].ToString();

        while (word.Length < Length)
        {
            LinkedList<char> list = AdjacencyList[CharToInt(word[^1])];
            randomIndex = random.Next(1, list.Length);

            word += list.Get(randomIndex);
        }

        return word;
    }

    public static int CharToInt(char c)
    {
        return c - 97;
    }

    public static char IntToChar(int i)
    {
        return (char)(i + 97);
    }
}