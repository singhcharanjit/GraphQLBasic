using GraphQLBasic.models;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System;
using System.Threading.Tasks;

namespace GraphQLBasic.Schema
{
    public class Subscription
    {
        [Subscribe]
        public CourseType CourseCreated([EventMessage] CourseType course) => course;

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<CourseType>> CourseUpdated(Guid courseId,
            [Service] ITopicEventReceiver topicEventReceiver)
        {
            string temp = $"{courseId}_{nameof(Subscription.CourseUpdated)}";

            return await topicEventReceiver.SubscribeAsync<string, CourseType>(temp);

        }
    }
}
