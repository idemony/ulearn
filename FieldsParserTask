using System.Collections.Generic;

namespace TableParser
{
	public class FieldsParserTask
	{
		public static List<string> ParseLine(string line)
		{
            var currentIndex = 0;
            var token = new Token(line, 0, line.Length);
            var parsedLine = new List<string> { };
            while (currentIndex < line.Length && !NextPartOfLineHaveOnlySpaces(line, currentIndex))
            {
                token = ReadField(line, currentIndex);
                parsedLine.Add(CurrentField(line, token));    
                currentIndex = token.GetIndexNextToToken();
            }
            return parsedLine;
		}

        public static string CurrentField(string line, Token token)
        {
            if (line[token.StartIndex] == '\'' || line[token.StartIndex] == '\"')
                return DeleteExtraSlashes(line.Substring(token.StartIndex + 1, token.Length - 2));
            else
                return line.Substring(token.StartIndex, token.Length);
        }

        public static string DeleteExtraSlashes(string field)
        {
            field = field.Replace("\\\"", "\"");
            field = field.Replace("\\\'", "\'");
            field = field.Replace("\\\\", "\\");
            return field;
        }

		private static bool NextPartOfLineHaveOnlySpaces(string line, int startIndex)
        {
            var i = startIndex;
            while (i < line.Length - 1 && line[i] == ' ')
                i++;
            return i == line.Length - 1 && line[i] == ' ';
        }

		private static Token ReadField(string line, int startIndex)
		{
            if (line[startIndex] == ' ')
                startIndex = SkipStartSpaces(line, startIndex);
            if (line[startIndex] == '\'' || line[startIndex] == '\"')
                return QuotedField(line, startIndex);
			return SimpleField(line, startIndex);      
		}

        private static int SkipStartSpaces(string line, int startIndex)
        {
            var i = startIndex;
            while (line[i] == ' ')
                i++;
            return i;
        }

        private static Token SimpleField(string line, int startIndex)
        {
            var i = startIndex;
            while (i < line.Length && line[i] != ' ' && line[i] != '\'' && line[i] != '\"')
                i++;
            return new Token(line, startIndex, i - startIndex);
        }

        private static Token QuotedField(string line, int startIndex)
        {
            var quote = line[startIndex];
            var i = startIndex + 1;
            while (i != line.Length && line[i] != quote)
            {
                if (line[i] == '\\')
                {
                    if (i + 2 < line.Length)
                        i += 2;
                    else
                    {
                        i = line.Length;
                        break;
                    }
                }
                else i++;
            }
            return new Token(line, startIndex, i - startIndex + 1);
        }
	}
}
