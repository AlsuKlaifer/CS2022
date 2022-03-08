// See https://aka.ms/new-console-template for more information
using CS2022;
using CS2022.List;
using System.Text.RegularExpressions;
var runner = new CustomListRunner();
runner.Run();

var runner2 = new LinqRunner();
runner2.Run();

//для нахождения почты в тексте
//string text = "...";
//Regex regex = new Regex(@"(\b\w+@[a-zA-Z_]+((\.[a-zA-Z]{2,6})|)\b)");
//MatchCollection matches = regex.Matches(text);
//if (matches.Count > 0)
//{
//    foreach (Match match in matches)
//        Console.WriteLine(match.Value);
//}