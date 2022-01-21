using Bogus;
using GraphQLBasic.models;
using System;
using System.Collections.Generic;

namespace GraphQLBasic.Service
{
    public interface IDataService
    {
        public List<StudentType> GetStudents();
        public List<InstructorType> GetInstructors();
        public List<CourseType> GetCourses();
        public CourseType GetCourse(Guid id);

    }

    public class DataService : IDataService
    {
        public List<StudentType> GetStudents()
        {
            return Students().Generate(10);
        }
        public List<InstructorType> GetInstructors()
        {
            return Instructors().Generate(10);
        }
        public List<CourseType> GetCourses()
        {
            return Courses().Generate(10);
        }

        public CourseType GetCourse(Guid id)
        {
            CourseType course = Courses().Generate();
            course.Id = id;
            return course;
        }

        #region Private 
        private Faker<CourseType> Courses()
        {
            Faker<CourseType> Faker = new Faker<CourseType>()
            .RuleFor(x => x.Id, f => Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Name.JobTitle())
            .RuleFor(x => x.Subject, f => f.PickRandom<SubjectEnum>())
            .RuleFor(x => x.Instructor, f => Instructors().Generate())
            .RuleFor(x => x.Students, f => Students().Generate(10));

            Faker.Generate(5);
            return Faker;
        }

        private Faker<InstructorType> Instructors()
        {
            Faker<InstructorType> Faker = new Faker<InstructorType>()
            .RuleFor(x => x.Id, f => Guid.NewGuid())
            .RuleFor(x => x.FName, f => f.Name.FirstName())
            .RuleFor(x => x.LName, f => f.Name.LastName())
            .RuleFor(x => x.Salary, f => f.Random.Double(1, 100000))
            .RuleFor(x => x.DOB, f=> f.Person.DateOfBirth);
            return Faker;
        }

        private Faker<StudentType> Students()
        {
            Faker<StudentType> Faker = new Faker<StudentType>()
            .RuleFor(x => x.Id, f => Guid.NewGuid())
            .RuleFor(x => x.FName, f => f.Name.FirstName())
            .RuleFor(x => x.LName, f => f.Name.LastName());
            return Faker;

        }
        #endregion

    }

}
