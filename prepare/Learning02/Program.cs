using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your name:");
        string name = Console.ReadLine();
        Resume resume = new Resume(name);

        while (true)
        {
            Console.WriteLine("Enter job details (or type 'exit' to finish):");

            Console.WriteLine("Company Name:");
            string company = Console.ReadLine();
            if (company.ToLower() == "exit") break;

            Console.WriteLine("Job Title:");
            string jobTitle = Console.ReadLine();
            if (jobTitle.ToLower() == "exit") break;

            Console.WriteLine("Start Year:");
            if (!int.TryParse(Console.ReadLine(), out int startYear)) break;

            Console.WriteLine("End Year:");
            if (!int.TryParse(Console.ReadLine(), out int endYear)) break;

            Job job = new Job(company, jobTitle, startYear, endYear);
            resume.AddJob(job);
        }

        // Display the resume
        resume.Display();
    }
}