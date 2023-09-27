//create a new class called resume

using System.ComponentModel.DataAnnotations;

public class Resume{
    //Class variables
    public String _name;
    public List<Job> _jobs = new List<Job>();

    //class method displays name first and then list of jobs and returns nothing

    public void Display()
    {
         Console.WriteLine($"Resume Details:{_name}");
         Console.WriteLine("{_jobs}");

         foreach (Job job in _jobs)
         {
            job.Display();
         }
    }

}