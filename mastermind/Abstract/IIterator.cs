namespace mastermind.Abstract
{
    public interface IIterator<T>
    {
        bool HasNext();
        T GetNext();
    }
}