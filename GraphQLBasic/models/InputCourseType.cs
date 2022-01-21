using System;

namespace GraphQLBasic.models
{
    public class InputCourseType
    {
        public string Name { get; set; }
        public SubjectEnum Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
