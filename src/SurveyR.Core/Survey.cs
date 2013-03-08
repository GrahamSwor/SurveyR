using System.Collections.Generic;

namespace SurveyR.Core
{
    public class Survey
    {
        public Survey()
        {
            Participants = new List<User>();
            Responses = new List<SurveyResponse>();
        }

        public void RegisterParticipant(User user)
        {
            Participants.Add(user);
        }

        public IList<User> Participants { get; set; }

        public IList<SurveyResponse> Responses { get; set; }

        public void RecordResponse(User participant, Answer answer)
        {
            Responses.Add(new SurveyResponse(participant, answer));
        }
    }
}