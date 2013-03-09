namespace SurveyR.Core
{
    public class SurveyResponse : EntityBase
    {
        public SurveyResponse()
        {
        }

        public SurveyResponse(User participant, Answer answer)
        {
            Participant = participant;
            Answer = answer;
        }

        public virtual User Participant { get; set; }

        public virtual Answer Answer { get; set; }
    }
}