namespace LibraryManager.AppConsole
{
    public class Book
    {
        private int _id = 0;
        private string? _title;
        private string? _author;
        private string? _ISBN;
        private int _yearPublish;

        public int Id 
        {
            get => _id;
            set { 
                    if (value < 0)
                    {
                        throw new ArgumentException("Book ID cannot be negative");
                    }
                    
                    _id = value;
                }
        }

        public string Title
        {
            get => _title ?? "NA";
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("The book title cannot be empty");
                    } 
                    else if (value.Length > 150)
                    {
                        throw new ArgumentException("The book title cannot be longer than 150 characters");
                    }

                    _title = value; 
                }
        }
        public string Author
        {
            get => _author ?? "NA";
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("The author of the book cannot be empty");
                    } 
                    else if (value.Length > 100)
                    {
                        throw new ArgumentException("The author of the book cannot be longer than 100 characters");
                    }

                    _author = value; 
                }
        }

        public string ISBN
        {
            get => _ISBN ?? "NA";
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("The book serial number cannot be empty");
                    } 
                    else if (value.Length > 13)
                    {
                        throw new ArgumentException("The book serial number cannot be longer than 13 characters");
                    }

                    _ISBN = value; 
                }
        }

        public int YearPublish
        {
            get => _yearPublish;
            set { 
                    if (value < 0)
                    {
                        throw new ArgumentException("The year of publication of the book cannot be negative");
                    } 
                    else if (value > DateTime.Now.Year)
                    {
                        throw new ArgumentException("The year of publication of the book cannot be greater than the current year");
                    }

                    _yearPublish = value; 
                }
        }

        public void Show()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Serial Number: {ISBN}");
            Console.WriteLine($"Year of Publish: {YearPublish}");
        }

        public void ShowList()
        {
            Console.WriteLine($"ID: {Id} - Title: {Title} - Serial Number: {ISBN}");
        }

    }
}

