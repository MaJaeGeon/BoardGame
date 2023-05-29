namespace BoardGame.Models {
    public abstract class QuizModel {
        public int QuizId { get; set; }
        public string QuizPath { get { return $"images/quizzes/{QuizId}.png"; } }
        public bool IsSolve { get; set; }
    }

    public class CommonQuizModel : QuizModel {
        public int Point { get; set; }
    }

    public class MissionQuizModel : QuizModel {
        public MissionType MissionType { get; set; }
    }

    public enum MissionType {
        OneMoreDice, AdditionalScore, RockScissorPapers, Shouting
    }
}