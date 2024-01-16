public static void RunTests()
{
    Test("hello world", new[] { "hello", "world" });
	Test("a \"bcd ef\"", new[] { "a", "bcd ef" });
	Test("a \'x y\'", new[] { "a", "x y" });
	Test("\"a \'b\' \'c\' d\"", new[] { "a \'b\' \'c\' d" });
	Test("\'\"1\" \"2\" \"3\"\'", new[] { "\"1\" \"2\" \"3\"" });
	Test("\"b c e\"", new[] { "b c e" });
	Test("\"def h", new[] { "def h" });
	Test("\"a \\\"c\\\"\"", new[] { "a \"c\"" });
	Test("\"\\\\\"", new[] { "\\" });
	Test("a \\\\", new[] { "a", "\\\\" });
	Test("\"a b\\\"", new[] { "a b\"" });
	Test("     a b   ", new[] { "a", "b" });
	Test("\"   \"", new[] {"   "});
	Test("\"\"", new[] { "" });
    Test("", new string[0]);
	Test("a\"b", new[] { "a", "b" });
	Test("\"a ", new[] { "a " });
	Test("\'a\\'\'", new[] { "a\'" });
	Test("\"a\" b", new[] { "a", "b" });
}
