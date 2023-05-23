using BoardGame.Models;
using BoardGame.Utils;
using System;

namespace BoardGame.Services {
    public class GameManagerService {
        public List<TokenModel> Tokens { get; set; } = new List<TokenModel>();
        public List<ISpaceModel> Spaces { get; set; } = new List<ISpaceModel>();
        public ISpaceModel? CurrentSpace { get; set; }
        public TokenModel CurrentToken { get; set; }

        public bool IsModalOpen { get; set; }
        public bool IsRolling { get; set; }


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

            var quizzes = Enumerable.Range(1, 47).Select(i => new {
                Path = $"images/space-bg/{i}.png",
                Reword = i switch {
                    <= 5 => 3, // 01~05 파란색
                    >= 6 and <= 17 => 1, // 06~17 초록색
                    >= 18 and <= 32 => 2, // 18~32 빨간색
                    >= 33 => 0 // 33~47 노란색
                }
            }).ToList().Shuffle();

            var quizSpaces = Enumerable.Range(1, 47).Select(i => {
                var space = new QuizSpaceModel {
                    SpaceId = i,
                    QuizPath = quizzes[i - 1].Path,
                    QuizReward = quizzes[i - 1].Reword,
                };

                return space;
            }).ToList();

            var firstSpace = new EventSpaceModel { SpaceId = 0 };
            var lastSpace = new EventSpaceModel { SpaceId = 48 };

            Spaces.Add(firstSpace);
            Spaces.AddRange(quizSpaces);
            Spaces.Add(lastSpace);
        }


        /// <summary>
        /// 토큰의 위치를 이동시킨다.
        /// </summary>
        /// <param name="count">이동시킬 칸 수</param>
        public async Task MoveToken(int count) {
            var order = Order;
            CurrentToken = Tokens.Find(t => t.Id == order) ?? throw new Exception();

            for (int i = 0; i < count; i++) {
                CurrentToken.SpaceId++;
                await Task.Delay(500);
            }

            // 토큰이 도착했을 때 퀴즈모달을 띄우고
            // 모달에는 퀴즈의 이미지 경로를 넘겨주고, 모달에서는 퀴즈 풀이 여부를 받아와야함.
            CurrentSpace = Spaces.Find(s => s.SpaceId == CurrentToken.SpaceId);

            // 해결된 문제라면 모달을 띄우지 않음.
            if (CurrentSpace is QuizSpaceModel quizSpace && quizSpace.IsSloved) return;

            OpenModal();
        }

        public void QuizSlove(int point) {
            CurrentToken.Point += point;

            Console.WriteLine($"{CurrentToken.Id} has {CurrentToken.Point} Points!");
        }

        public void UpdatePoint(int point) {
            CurrentToken.Point += point;
        }


        public void OpenModal() {
            IsModalOpen = true;
        }

        public void UpdateModalState(bool isOpen) {
            IsModalOpen = isOpen;
        }
    }
}