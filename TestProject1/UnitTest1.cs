using GraphQLBasic.Service;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        DataService _dataservice = null;
        [SetUp]
        public void Setup()
        {
            _dataservice = new DataService();
        }

        [Test]
        public void Test1()
        {
            var cources = _dataservice.GetCourses();
            Assert.IsNotNull(cources);
        }
    }
}