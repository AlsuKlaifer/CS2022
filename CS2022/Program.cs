// See https://aka.ms/new-console-template for more information
using CS2022;
using CS2022.List;
using System.Text.RegularExpressions;
using CS2022.LINQ;
using CS2022.Delegats;

//var runner = new CustomArrayCollectionRunner();
//runner.Run();

//var runner2 = new CustomLinkedListRunner();
//runner2.Run();

var runner3 = new LinkTaskRunner();
runner3.Run();

var runner = new DelegateRunner();
runner.Run();