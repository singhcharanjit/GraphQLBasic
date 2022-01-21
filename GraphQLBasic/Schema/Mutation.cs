using GraphQLBasic.models;
using GraphQLBasic.Service;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLBasic.Schema
{
    public class Mutation
    {
        private readonly List<CourseType> _courses;
        DataService _dataService = null;
        public Mutation(DataService dataService)
        {
            _dataService = dataService;
            _courses = _dataService.GetCourses();
        }

        public async Task<IEnumerable<CourseType>> CreateCourse(InputCourseType course, [Service] ITopicEventSender topicEventSender)
        {
            //throw new GraphQLException(new Error("Unable to do it!!!", "ADD_FAILED_009"));

            var tempCourse = new
                CourseType()
            {
                Id = Guid.NewGuid(),
                Name = course.Name,
                Subject = course.Subject,
                Instructor = new InstructorType() { Id = course.InstructorId}
            };

            _courses.Add(tempCourse);

            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), tempCourse);

            return _courses;
        }

        public async Task<IEnumerable<CourseType>> UpdateCourse(Guid courseId, InputCourseType course, [Service] ITopicEventSender topicEventSender)
        {
            var existingCourse= _courses.Find(x => x.Id == courseId);
            
            if(existingCourse == null)
                throw new GraphQLException(new Error("Unable to update!!!", "UPDATE_FAILED_009"));

            existingCourse.Name = course.Name;
            existingCourse.Subject = course.Subject;

            string temp = $"{courseId}_{nameof(Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(temp, existingCourse);

            return _courses;
        }
        
        public IEnumerable<CourseType> DeleteCourse(Guid courseId)
        {
            var existingCourse = _courses.Find(x => x.Id == courseId);

            if (existingCourse == null)
                throw new GraphQLException(new Error("Unable to delete!!!", "DELETE_FAILED_001"));

            _courses.Remove(existingCourse);
            return _courses;
        }

    }
}
