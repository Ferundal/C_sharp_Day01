namespace d_01
{
    public class Storage
    {
        public int Count { get; private set; }

        public int Capacity { get; }

        public Storage(int capacity)
        {
            if (capacity > 0)
                Capacity = capacity;
            else
                Capacity = 0;
            Count = Capacity;
        }

        public int GetGoods(int goodsAmount)
        {
            if (goodsAmount > Count)
            {
                goodsAmount = Count;
                Count = 0;
                return goodsAmount;
            }

            Count -= goodsAmount;
            return goodsAmount;
        }

        public bool IsEmpty() => Count == 0;
    }
}