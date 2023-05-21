namespace BoardGame.Models {
    public class SpaceModel {
        public int SpaceId { get; set; }
        public bool IsEventSpace { get; set; }
        public bool IsSolved { get; set; }
        public string? QuizPath { get; set; }
    }
}
