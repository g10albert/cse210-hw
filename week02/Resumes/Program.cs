using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Google";
        job1._jobTitle = "Designer";
        job1._startYear = 2025;
        job1._endYear = 2025;
        job1.Display();

        Job job2 = new Job();
        job2._company = "YouTube";
        job2._jobTitle = "Programmer";
        job2._startYear = 2022;
        job2._endYear = 2023;
        job2.Display();

        Resume resume1 = new Resume();
        resume1._name = "Albert";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1.Display();

    }
}