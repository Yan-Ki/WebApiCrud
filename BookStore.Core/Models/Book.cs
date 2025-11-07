using System.Runtime.CompilerServices;

namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITEL_LENGHT = 250;
        private Book(Guid id, string titel, string description, decimal price)
        {
            this.Id = id;
            this.Titel = titel;
            this.Description = description;
            this.Price = price;
        }
        public Guid Id { get; }
        public string Titel { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        public static (Book book, string Error) Create (Guid id, string titel, string description, decimal price)
        {
            Book book = new Book(id, titel, description, price);
            string error = string.Empty;
            //нужно побольше добавить валидации
            if (string.IsNullOrEmpty(titel)|| titel.Length > MAX_TITEL_LENGHT)
            {
                error = "Заголовок больше длины 250 знаков";
            }
            return (book, error);
        }
}

    
}
