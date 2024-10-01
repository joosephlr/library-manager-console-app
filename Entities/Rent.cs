namespace LibraryManager.AppConsole
{
    public class Rent
    {
        private int _id = 0;
        private Book _book;
        private User _user;
        private readonly DateTime _rentDate = DateTime.Now;
        private DateTime _returnDate;

        public int Id
        {
            get => _id;
            set {
                    if (value < 0)
                    {
                        throw new ArgumentException("Loan ID cannot be negative");
                    }

                    _id = value;
                }
        }

        public Book Book
        {
            get => _book ?? throw new ArgumentException("The loan book cannot be null or empty");
            set => _book = value;
        }

        public User User
        {
            get => _user ?? throw new ArgumentException("Loan user cannot be null or empty");
            set => _user = value;
        }

        public DateTime RentDate
        {
            get => _rentDate;
        }

        public DateTime ReturnDate
        {
            get => _returnDate;
            set {
                    if (value < _rentDate)
                    {
                        throw new ArgumentException("The return date cannot be before the loan date");
                    }

                    _returnDate = value;
                }
        }

        public void Show(){
            Console.WriteLine($"ID: {Id} - Book: {Book.Title} - User: {User.Name} - Rent Date: {RentDate} - Return Date: {ReturnDate}");
        }


    }
}