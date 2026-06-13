using System;

namespace TmsCore
{
    public class Program
    {


        public static void Main(string[] args)
        {
            string studentName = "Abeba";
            string studentId = "STU-001";
            int enrollmentCount = 3;
            decimal grantAmount = 1999.99m; // 'm' suffix marks a decimal literal
            DateTime enrolledAt = DateTime.UtcNow;
            DateTime now = DateTime.UtcNow;

            string? campusRegion = null;
            Console.WriteLine($"Student: {studentName} ({studentId})");
            Console.WriteLine($"Courses: {enrollmentCount}");
            Console.WriteLine($"Grant: {grantAmount:F2}");
            Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
            Console.WriteLine($"Campus: {campusRegion ?? "Not assigned"}");
            Console.WriteLine($"Today is: {now}");


            //  student class
            Student s = new Student { Name = "surafel" };
            Console.WriteLine($"My name is :{s.Name}"); // get


            // cat class
            Cat c = new Cat { Sound = "Miyaww" };
            Console.WriteLine($"My Cat is hangery so : {c.Sound}");




            // database simple  example
            var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
            Console.WriteLine(enrollment);

            var corrected = enrollment with { CourseCode = "CS-402" };
            Console.WriteLine(corrected);
            var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
            Console.WriteLine($"Same data? {enrollment == duplicate}"); // True




            // car object class logic
            Car car1 = new Car { Name = "V8", brand = "Toyota" };
            car1.start();
            Console.WriteLine(car1.Name);
            Console.WriteLine(car1.brand);

#pragma warning disable CS8974 // Converting method group to non-delegate type
            Console.WriteLine(car1.start);
#pragma warning restore CS8974 // Converting method group to non-delegate type
            Car newcar = new Car { Name = "welcome", brand = "Toyota" };
            Console.WriteLine(newcar);
            Dog mydog = new Dog();
            mydog.Sound();
            Console.WriteLine(mydog);





            //  test student
            var k = new Students { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
            Console.WriteLine($"Student: {s.Name}, GPA: {k.GPA}");




            //  excute grade from module.cs
            void PrintGradeReport(IEnumerable<IGradable> assessments)
            {
                Console.WriteLine("--- Grade Report ---");
                foreach (var item in assessments)
                {
                    Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
                }
            }
            // Test it — one array holds two completely different types
            IGradable[] cohortAssessments = [
            new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 }, new LabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore=85m }
            ];
            PrintGradeReport(cohortAssessments);
        }
    }


    internal record EnrollmentRecord(string StudentId, string CourseCode, DateTime EnrolledAt);

    public class Student
    {
        public required string Name { get; set; }
    }
}


public class Cat
{
    public required string Sound { get; set; }
}



public class Car
{
    public required string Name;
    public required string brand;
    public void start()
    {
        Console.WriteLine("car is start :");
    }
}



// car objects  interface concepts

interface IAnimal
{
    void Sound();
}
class Dog : IAnimal
{
    public void Sound()
    {
        Console.WriteLine("Bark");
    }
}










