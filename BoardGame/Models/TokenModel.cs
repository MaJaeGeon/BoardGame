namespace BoardGame.Models {
    public class TokenModel {
        public int Id { get; set; }

        private int spaceId;
        public int SpaceId {
            get { return spaceId; } 
            set { 
                if(spaceId == value) return;

                spaceId = value;
                OnSpaceIdChanged();
            }
        }

        private int point = 0;
        public int Point { 
            get { return point; }
            set {
                if(point == value) return;
                point = value;
                OnPointChanged();
            }
        }

        public event Action? SpaceIdChanged;
        public event Action? PointChanged;

        protected virtual void OnSpaceIdChanged() {
            SpaceIdChanged?.Invoke();
        }
        private void OnPointChanged() {
            PointChanged?.Invoke();
        }
    }
}