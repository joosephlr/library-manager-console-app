using System.Text.RegularExpressions;

namespace LibraryManager.AppConsole
{

    public partial class User
    {
        private int _id = 0;
        private string _name;
        private string _email;

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

        public string Name
        {
            get => _name ?? "NA";
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Username cannot be empty");
                    } 
                    else if (value.Length > 150)
                    {
                        throw new ArgumentException("Username cannot be longer than 150 characters");
                    }

                    _name = value; 
                }
        }

        public string Email
        {
            get => _email ?? "NA";
            set { 
                    Regex regex = EmailRegex();
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("User email cannot be empty");
                    } 
                    else if (!regex.IsMatch(value))
                    {
                        throw new ArgumentException("User email is not valid");
                    }

                    _email = value; 
                }
        }

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegex();
        
        public void Show()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
        }

        public void ShowList()
        {
            Console.WriteLine($"ID: {Id} - Name: {Name} - Email: {Email}");
        }
        
    }

    
}