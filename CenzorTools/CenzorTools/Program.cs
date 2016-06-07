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
   System.IO.StreamReader inputFile =
      new System.IO.StreamReader("data.csv");
   //inputFile.ReadLine();
   //inputFile.ReadLine();
   //inputFile.ReadLine();
   //inputFile.ReadLine();
   //inputFile.ReadLine();
   //inputFile.ReadLine();

   string[] subjectIds = inputFile.ReadLine().Split(',');
   string[] firstSessions = inputFile.ReadLine().Split(';');
   string[] secondSessions = inputFile.ReadLine().Split(',');
   string[] thirdSessions = inputFile.ReadLine().Split(';');
   string[] forthSessions = inputFile.ReadLine().Split(';');

   for (int i = 0; i < subjectIds.Length; i++)
   {
    Subjects.Add(new Subject(subjectIds[i], firstSessions[i], secondSessions[i], thirdSessions[i], forthSessions[i]));


   }

   printSubjectFirstThirds(Subjects, subjectIds);
   //PrintSessionXThirds(Subjects, subjectIds);

   inputFile.Close();


  }

  private static void printSubjectFirstThirds(List<Subject> Subjects, string[] subjectIds)
  {
   //List<List<double>> result = new List<List<double>>(4);
   double[][] result = new double[4][];
   result[0] = new double[4];
   result[1] = new double[4];
   result[2] = new double[4];
   result[3] = new double[4];


   
   // encodes the output as text.
   using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"results" + DateTime.Now.ToString("yyyy-dd-M-HHmm") + ".csv"))
   {
    file.WriteLine("subject/session,s1,s2,s3,s4");
    foreach (var subject in Subjects)
    {
     file.Write(subject.id + ",");
     foreach (var session in subject.Sessions)
     {
      file.Write(session.thirds[0] + ",");
     }
     file.WriteLine();
    }
    
    
    file.WriteLine();
   }
   
  }

  private static void PrintSessionXThirds(List<Subject> Subjects, string[] subjectIds)
  {
   //List<List<double>> result = new List<List<double>>(4);
   double[][] result = new double[4][];
   result[0] = new double[4];
   result[1] = new double[4];
   result[2] = new double[4];
   result[3] = new double[4];

   foreach (var subject in Subjects)
   {
    for (int i = 0; i < subject.Sessions.Count; i++)
    {
     for (int j = 0; j < subject.Sessions[i].thirds.Count; j++)
     {
      result[i][j] += subject.Sessions[i].thirds[j];
     }
    }
   }

   // encodes the output as text.
   using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"results" + DateTime.Now.ToString("yyyy-dd-M-HHmm") + ".csv"))
   {
    foreach (double[] session in result)
    {
     foreach (double third in session)
     {
      file.Write(third / subjectIds.Length + ",");
     }
     file.WriteLine();
    }
   }
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
 public class Session
 {

  public List<double> thirds { get; set; }


  public Session(string data)
  {
   this.data = data;
   this.thirds = data.Replace("\"", "").Replace("[", "").Replace("]", "").Split(',').Select(double.Parse).ToList();
  }

  public string data { get; set; }
 }
}
