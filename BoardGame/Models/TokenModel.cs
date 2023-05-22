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

        public int Point { get; set; }

        public event Action? SpaceIdChanged;

        protected virtual void OnSpaceIdChanged() {
            SpaceIdChanged?.Invoke();
        }
    }
}