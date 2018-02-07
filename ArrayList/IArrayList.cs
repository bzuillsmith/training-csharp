namespace Training02
{
    public interface IArrayList
    {
        void Add(string item);
        void InsertAt(int index, string item);
        int IndexOf(string item);
        int Count { get; }
        void Remove(string item);
        void RemoveAt(int index);
    }
}
