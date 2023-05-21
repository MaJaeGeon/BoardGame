using BoardGame.Models;
using BoardGame.Utils;

namespace BoardGame.Services {
    public class GameManagerService {
        public List<TokenModel> Tokens { get; set; } = new List<TokenModel>();
        public List<SpaceModel> Spaces { get; set; } = new List<SpaceModel>();

        public bool IsModalOpen { get; set; }

        private int order = 0;
        /// <summary>
        /// Token 순서
        /// </summary>
        private int Order {
            get {
                var currentOrder = order;

                if (order + 1 < Tokens.Count) order++;
                else order = 0;

                return currentOrder;
            }
        }

        public GameManagerService() {
            Tokens = Enumerable.Range(0, 4).Select(i => new TokenModel {
                Id = i,
                SpaceId = 0,
            }).ToList();

            // Spaces
            Random random = new Random();

            //1~47
            var Quizzes = Enumerable.Range(1, 47).Select(i => $"images/space-bg/{i}.png").ToList().Shuffle();

            //0~48 : 49개
            Spaces = Enumerable.Range(0, 49).Select(i => {
                var space = new SpaceModel {
                    SpaceId = i,
                    IsEventSpace = random.Next() % 4 == 0,
                    QuizPath = !(i < 1 || i > 47) ? Quizzes[i - 1] : ""
                };

                return space;
            }).ToList();
        }

        /// <summary>
        /// 토큰의 위치를 이동시킨다.
        /// </summary>
        /// <param name="count">이동시킬 칸 수</param>
        public async Task MoveToken(int count) {
            var order = Order;
            var token = Tokens.Find(t => t.Id == order) ?? throw new Exception();

            for (int i = 0; i < count; i++) {
                token.SpaceId++;
                await Task.Delay(500);
            }

            // 토큰이 도착했을 때 퀴즈모달을 띄우고
            // 모달에는 퀴즈의 이미지 경로를 넘겨주고, 모달에서는 퀴즈 풀이 여부를 받아와야함.
            var space = Spaces.Find(s => s.SpaceId == token.SpaceId);
            Console.WriteLine(space.QuizPath);
            //OpenModal(space.QuizPath);
        }


        public void OpenModal() {
            IsModalOpen = true;
        }

        public void UpdateModalState(bool isOpen) {
            IsModalOpen = isOpen;
        }
    }
}
