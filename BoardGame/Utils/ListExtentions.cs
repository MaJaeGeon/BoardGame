namespace BoardGame.Utils {
    public static class ListExtentions {
        public static List<T> Shuffle<T>(this List<T> list) {
            Random random = new Random();

            for (int i = list.Count - 1; i > 0; i--) {
                int j = random.Next(i + 1);
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }

            return list;
        }
    }
}
