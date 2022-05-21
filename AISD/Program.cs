// See https://aka.ms/new-console-template for more information
using AISD;
using AISD.Codeforses;
using AISD.Homework_21._04._2022;
using AISD.Karatsuba;
using AISD.SemesterWork2;
//Homework 14.02.2022
//int[][] a = AISD.ArrayTasks.ReadFromFile();
//ArrayTasks.JoinAllArrays(a);

//2 task
//int[] arr = { 1, 2, 3, 1, 6, 6, 9, 0 };
//var result2 = Couple.UniqNumCount(arr);

//Homework 3.03.2022
//int[] a = new int[] {2, 1, 2, 3, 2, 2, 3, 10, 2, 2};
//ArraySearch.MajoritySearch(a);

//3 task
//ArraySearch.Task3(13, 21 , 25);
//ArraySearch.Task3(13, 21 , 26);
//ArraySearch.Task3(102, 2 , 14);

var kar = new Mult();
int a = kar.Calc(123, 456789);
Console.WriteLine(a);

//var runner = new IntHAT();
//runner.Run();

//var runner = new ArraySearchMax();
//runner.Run();

//var a = new Mult();
//a.Run();

//Classroom[] classes =
//	{
//		new Classroom {Students = {"Pavel", "Ivan", "Petr"},},
//		new Classroom {Students = {"Anna", "Ilya", "Vladimir"},},
//		new Classroom {Students = {"Bulat", "Alex", "Galina"},}
//	};

//var allStudents = new List<string>();
//foreach (var classroom in classes)
//{
//	foreach (var student in classroom.Students)
//	{
//		allStudents.Add(student);
//	}
//}
//return allStudents.ToArray();

//var allStudents = Ao.GetAllStudents(classes);
//Array.Sort(allStudents);
//Console.WriteLine(string.Join(" ", allStudents));

//public class Classroom
//{
//	public List<string> Students = new List<string>();
//}
//public static class Ao
//{
//	public static string[] GetAllStudents(Classroom[] classes)
//	{
//		return classes.SelectMany(s => s.Students).ToArray();
//	}
//}