﻿using System;
using System.Collections.Generic;

namespace GraphQLBasic.models
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SubjectEnum Subject { get; set; }    
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }


    }
}
