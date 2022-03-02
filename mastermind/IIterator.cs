namespace mastermind
{
    public interface IIterator<T>
    {
        bool HasNext();
        T GetNext();
    }
}