
namespace aiGenetic
{
    public enum Crossover
    {
        Cycle,
        Greedy,
    }

    public enum Selection
    {
        Tournament,
        Roulette,
    }

    public class Settings
    {
        public Crossover crossover;
        public int crossoverPercent;
        public bool eliminateTwins;
        public int elitePercent;
        public int mutationPercent;
        public Selection selection;

        public Settings()
        {
            Init();
        }

        /// <summary>
        /// Присвоение значений по умолчанию.
        /// </summary>
        public void Init()
        {
            crossover = Crossover.Cycle;
            crossoverPercent = 99;
            eliminateTwins = true;
            elitePercent = 10;
            mutationPercent = 5;
            selection = Selection.Tournament;
        }
    }
}