using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenzorTools
{
 class Program
 {
  static void Main(string[] args)
  {
   int counter = 0;
   string line;

   // Read the file and display it line by line.
   System.IO.StreamReader file =
      new System.IO.StreamReader("data.csv");
   while ((line = file.ReadLine()) != null)
   {
    Console.WriteLine(line);
    counter++;
   }

   file.Close();

   // Suspend the screen.
   Console.ReadLine();
  }
 }

 class subject
 {
  public string id { get; set; }

  public List<Session> Sessions { get; set; }



 }
 class Session { }
}
