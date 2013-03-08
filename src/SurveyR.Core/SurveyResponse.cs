namespace SurveyR.Core
{
    public class SurveyResponse
    {
        public SurveyResponse(User participant, Answer answer)
        {
            Participant = participant;
            Answer = answer;
        }

        public User Participant { get; set; }

        public Answer Answer { get; set; }
    }
}