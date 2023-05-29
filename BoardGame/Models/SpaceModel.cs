namespace BoardGame.Models {
    //public interface ISpaceModel {
    //    public int SpaceId { get; set; }
    //}

    //public class EventSpaceModel : ISpaceModel {
    //    public int SpaceId { get; set; }

    //}

    //public class QuizSpaceModel : ISpaceModel {
    //    public int SpaceId { get; set; }
    //    public QuizModel? Quiz { get; set; }
    //}

    public class SpaceModel {
        public int SpaceId { get; set; }
        public QuizModel? Quiz { get; set; }
    }
}
