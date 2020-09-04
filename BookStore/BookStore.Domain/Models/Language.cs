using BookStore.Domain.Common;

namespace BookStore.Domain.Models
{
    public class Language : Entity<int>
    {
        internal Language(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public string Name { get; }

        public string Code { get; }
    }
}
