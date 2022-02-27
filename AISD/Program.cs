// See https://aka.ms/new-console-template for more information
using AISD;
//Homework 14.02.2022
//int[][] a = AISD.ArrayTasks.ReadFromFile();
//ArrayTasks.JoinAllArrays(a);

//2 task
//int[] arr = { 1, 2, 3, 1, 6, 6, 9, 0 };
//var result2 = Couple.UniqNumCount(arr);

//Homework 24.02.2022
//int[] a = new int[] {2, 1, 2, 3, 2, 2, 3, 10, 2, 2};
//ArraySearch.MajoritySearch(a);

var a = new ArraySearch();
int[] c2 = new int[] { 1, 2, 3 };
AISD.Count.Recursion(c2, 0, c2.Length - 1);
Console.ReadKey();

//int[] arr = new int[] { 1, 2, 3 };

//a.AllArrays(arr);