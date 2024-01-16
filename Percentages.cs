public static double Calculate(string userInput)
{
    string[] splitUserInput = userInput.Split(' ');
    var deposit = double.Parse(splitUserInput[0]);
    var procentForYear = double.Parse(splitUserInput[1]);
    var timeInMonth = long.Parse(splitUserInput[2]);
    var procentForMonth = procentForYear / 12;
    var finalDeposit = deposit * Math.Pow(1 + (procentForMonth / 100), timeInMonth);
	return finalDeposit;
}
    
