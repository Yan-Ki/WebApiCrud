using System.Runtime.CompilerServices;

namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITEL_LENGHT = 250;
        private Book(Guid Id, string Titel, string Description, decimal Price)
        {
            this.Id = Id;
            this.Titel = Titel;
            this.Description = Description;
            this.Price = Price;
        }
        public Guid Id { get; }
        public string Titel { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        public static (Book book, string Error) Cteate (Guid Id, string Titel, string Description, decimal Price)
        {
            Book book = new Book(Id, Titel, Description, Price);
            string error = string.Empty;
            if (string.IsNullOrEmpty(Titel)|| Titel.Length > MAX_TITEL_LENGHT)
            {
                error = "Заголовок больше длины 250 знаков";
            }
            return (book, error);
        }
}

    
}
