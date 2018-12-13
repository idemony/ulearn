namespace Pluralize
{
	public static class PluralizeTask
	{
        public static string PluralizeRubles(int count)
        {
            string ending = "";
            var lastNumber = count % 10;
            if ((count % 100) / 10 == 1)
                ending = "лей";
            else if (lastNumber == 1)
                ending = "ль";
            else if (lastNumber == 2 || lastNumber == 3 || lastNumber == 4)
                ending = "ля";
            else
                ending = "лей";

			return "руб" + ending;
		}
	}
}
