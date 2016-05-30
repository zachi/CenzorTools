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
   List<Subject> Subjects = new List<Subject>();


   // Read the file and display it line by line.
   System.IO.StreamReader file =
      new System.IO.StreamReader("data.csv");
   string[] subjectIds = file.ReadLine().Split(',');
   string[] firstSessions = file.ReadLine().Split(';');
   string[] secondSessions = file.ReadLine().Split(',');
   string[] thirdSessions = file.ReadLine().Split(';');
   string[] forthSessions = file.ReadLine().Split(';');

   for (int i = 0; i < subjectIds.Length; i++)
   {
    Subjects.Add( new Subject(subjectIds[i], firstSessions[i], secondSessions[i], thirdSessions[i], forthSessions[i]));

   
   }


   

   file.Close();

   // Suspend the screen.
   Console.ReadLine();
  }
 }

 public class Subject
 {
  public Subject(string id, string firstSession, string secondSession, string thirdSession, string forthSession)
  {
   this.id = id;
   this.Sessions = new List<Session>();
   this.Sessions.Add(new Session(firstSession));
   this.Sessions.Add(new Session(secondSession));
   this.Sessions.Add(new Session(thirdSession));
   this.Sessions.Add(new Session(forthSession));

  }
  public string id { get; set; }

  public List<Session> Sessions { get; set; }



 }
 public class Session {
  

  public Session(string data)
  {
   this.data = data;
  }

  public string data { get; set; }
 }
}
