using NUnit.Framework;
using Should;
using SurveyR.Core;

namespace SurveyR.Tests.CoreTests
{
    [TestFixture]
    public class SurveyTests
    {
        [Test]
        public void should_be_able_to_register_a_participant()
        {
            var survey = new Survey();

            survey.RegisterParticipant(new User());

            survey.Participants.Count.ShouldEqual(1);
        }

        [Test]
        public void should_be_able_to_register_a_participants_response()
        {
            var survey = new Survey();

            var participant = new User();

            var answer = new Answer();

            survey.RegisterParticipant(participant);

            survey.RecordResponse(participant, answer);

            survey.Responses.Count.ShouldEqual(1);
            survey.Responses[0].Participant.ShouldEqual(participant);
            survey.Responses[0].Answer.ShouldEqual(answer);
        }
    }
}