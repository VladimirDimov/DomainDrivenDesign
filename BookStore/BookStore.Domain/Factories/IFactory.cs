using BookStore.Domain.Common;

namespace BookStore.Domain.Factories
{
    public interface IFactory<out T>
        where T : IAggregateRoot
    {
        T Build();
    }
}
