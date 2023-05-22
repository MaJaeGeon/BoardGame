namespace BoardGame.Models {
    public interface ISpaceModel {
        public int SpaceId { get; set; }
    }

    public class EventSpaceModel : ISpaceModel {
        public int SpaceId { get; set; }

    }

    public class QuizSpaceModel : ISpaceModel {
        public int SpaceId { get; set; }
        public string? QuizPath { get; set; }
        public int QuizReward { get; set; }
        public bool IsSloved { get; set; }
    }
}
