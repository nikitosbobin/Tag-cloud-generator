namespace Tag_Cloud_Generator.Classes
{
    class PriorityPair<TSource>
    {
        public PriorityPair(TSource value, int priority = 1)
        {
            Value = value;
            Priority = priority;
        }

        public TSource Value { get; }
        public int Priority { get; set; }
    }
}
