using System.Collections.Generic;

namespace SurveyR.Core
{
    public class Survey : EntityBase
    {
        public Survey()
        {
            Participants = new List<User>();
            Responses = new List<SurveyResponse>();
        }

        public virtual void RegisterParticipant(User user)
        {
            Participants.Add(user);
        }

        public virtual IList<User> Participants { get; set; }

        public virtual IList<SurveyResponse> Responses { get; set; }

        public virtual void RecordResponse(User participant, Answer answer)
        {
            Responses.Add(new SurveyResponse(participant, answer));
        }
    }
}