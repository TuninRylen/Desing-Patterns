using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher Engin = new Teacher(mediator);
            Engin.Name = "Engin Hoca";

            Student Ugur = new Student(mediator, "Ugurcan");

            Student Aysenur = new Student(mediator, "Aysenur");

            mediator.Students = new List<Student> { Ugur, Aysenur};

            Engin.SendNewImageUrl("slide1.jpg");

            Engin.ReviceQuestion("is it true", Ugur);


            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator){ }

        public void ReviceQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0},{1}", student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0} {1}", student.Name, answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator, string name) : base(mediator)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void ReciveImage(string url)
        {
            Console.WriteLine($"{Name} received image : {url}");
        }

        public void ReciveAnswer(string answer)
        {
            Console.WriteLine("{1} student received answer {0}", answer, Name);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReciveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReviceQuestion(question,student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReciveAnswer(answer);
        }
    }
}
