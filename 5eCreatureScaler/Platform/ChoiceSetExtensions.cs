using System.Linq;

namespace CreatureScaler.Platform
{
    public static class ChoiceSetExtensions
    {
        public static void Choose<T>(this Choice<T>.Set set, int index)
        {
            if (set.Choices.Count > index)
            {
                set.Choices[index].Choose();
            };
        }

        public static void ChooseFirst<T>(this Choice<T>.Set set)
        {
            set.Choices?.First().Choose();
        }
    }
}
