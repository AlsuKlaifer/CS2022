// See https://aka.ms/new-console-template for more information
using CS2022.List;

var list = new CustomList();
list.WriteToConsole();

var list1 = new CustomList(5);
list1.WriteToConsole();

list.Add(1);
list.WriteToConsole();
list.Add(2);
list.WriteToConsole();
list.Add(3);
list.WriteToConsole();
list.AddToHead(0);
list.WriteToConsole();
list.Add(5, 1);
list.WriteToConsole();
list.Add(11, 3);
list.WriteToConsole();
list.Add(10, 2);
list.WriteToConsole();
list.DeletePenult();
list.WriteToConsole();
list.DeleteNumber(0);
list.WriteToConsole();
list.Add(11);
list.WriteToConsole();
Console.WriteLine(list.Sum());
list.PasteNumber(11, 9);
list.WriteToConsole();