public class CaseAlternatorTask
{
    public static List<string> AlternateCharCases(string lowercaseWord)
    {
        var result = new List<string>();
		var subset = new bool[lowercaseWord.Length];
        AlternateCharCases(lowercaseWord.ToCharArray(), 0, result, subset.ToArray());
        return result;
    }

    static void AlternateCharCases(char[] word, int startIndex, List<string> result, bool[] subset)
    {
        if (startIndex == word.Length)
		{
			Evaluate(subset, word, result);
			return;
		}
		subset[startIndex] = false;
		AlternateCharCases(word.ToArray(), startIndex + 1, result, subset.ToArray());
		subset[startIndex] = true;
		AlternateCharCases(word.ToArray(), startIndex + 1, result, subset.ToArray());
	}
	
	static void Evaluate(bool[] subset, char[] word, List<string> result)
	{
		for (int i = 0; i < word.Length; i++)
			if (subset[i] && Char.IsLetter(word[i]) && Char.IsLower(word[i]))
				word[i] = Char.ToUpper(word[i]);
		var currentWord = new string(word);
		if (!result.Contains(currentWord))
			result.Add(currentWord);
	}
}
        
