namespace mastermind.Iterators
{
    public interface IIterator<T>
    {
        bool HasNext();
        T GetNext();
    }
}