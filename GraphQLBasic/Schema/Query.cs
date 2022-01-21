using GraphQLBasic.Service;
using System.Collections.Generic;
using HotChocolate;
using Bogus;
using System;
using System.Threading.Tasks;
using GraphQLBasic.models;

namespace GraphQLBasic.Schema
{
    public class Query
    {
        DataService _dataService = null;
        public Query(DataService dataService)
        {
            _dataService = dataService;
        }

        [GraphQLDeprecated("no longer in service")]
        public List<StudentType> Stdnts => _dataService.GetStudents();

        public List<StudentType> GetStudents()
        {
            return _dataService.GetStudents();
        }


        public async Task<List<CourseType>> GetCoursesAsync()
        {
            await Task.Delay(1000);
            return _dataService.GetCourses();
        }

        public CourseType GetCourseById(Guid id)
        {
            return _dataService.GetCourse(id);
        }
    }

}
