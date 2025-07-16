using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace _17_01_Attributes_2_BinarySerialize_3_XML_JsonSerialization_4_DataAnnotation
{
    public class User
    {
        [Range(1000, 9999, ErrorMessage = "ID must be between 1000 and 9999.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Login is required.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Login must not contain special characters.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password must not contain special characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Credit card is required.")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Credit card must contain 16 digits.")]
        public string CreditCard { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^\+38-0\d{5}-\d{2}-\d{2}$", ErrorMessage = "Phone number must match +38-0*****-**-** format.")]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Login: {Login}, Email: {Email}, Phone: {Phone}";
        }
    }

    class Program
    {
        static Dictionary<int, User> users = new Dictionary<int, User>();
        static string filePath = "users.json";

        public delegate void SetterDelegate(User user, object value);
        public delegate object ParserDelegate(string input);

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n1 - Add User");
                Console.WriteLine("2 - Show All");
                Console.WriteLine("3 - Save");
                Console.WriteLine("4 - Load");
                Console.WriteLine("5 - Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        User user = new User();
                        user.Id = (int)ReadValidated("Enter ID: ", user, (u, v) => u.Id = (int)v, s => int.Parse(s), nameof(User.Id));
                        user.Login = (string)ReadValidated("Enter Login: ", user, (u, v) => u.Login = (string)v, s => s, nameof(User.Login));
                        user.Password = (string)ReadValidated("Enter Password: ", user, (u, v) => u.Password = (string)v, s => s, nameof(User.Password));
                        user.ConfirmPassword = (string)ReadValidated("Confirm Password: ", user, (u, v) => u.ConfirmPassword = (string)v, s => s, nameof(User.ConfirmPassword));
                        user.Email = (string)ReadValidated("Enter Email: ", user, (u, v) => u.Email = (string)v, s => s, nameof(User.Email));
                        user.CreditCard = (string)ReadValidated("Enter Credit Card: ", user, (u, v) => u.CreditCard = (string)v, s => s, nameof(User.CreditCard));
                        user.Phone = (string)ReadValidated("Enter Phone: ", user, (u, v) => u.Phone = (string)v, s => s, nameof(User.Phone));

                        if (!users.ContainsKey(user.Id))
                            users.Add(user.Id, user);
                        else
                            Console.WriteLine("User with this ID already exists.");
                        break;

                    case "2":
                        foreach (var u in users.Values)
                            Console.WriteLine(u);
                        break;

                    case "3":
                        File.WriteAllText(filePath, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));
                        Console.WriteLine("Saved to users.json");
                        break;

                    case "4":
                        if (File.Exists(filePath))
                        {
                            string json = File.ReadAllText(filePath);
                            users = JsonSerializer.Deserialize<Dictionary<int, User>>(json);
                            Console.WriteLine("Loaded from users.json");
                        }
                        else
                        {
                            Console.WriteLine("File not found.");
                        }
                        break;

                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static object ReadValidated(string prompt, User user, SetterDelegate setter, ParserDelegate parser, string propertyName)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                try
                {
                    object value = parser(input);
                    setter(user, value);

                    var context = new ValidationContext(user) { MemberName = propertyName };
                    Validator.ValidateProperty(value, context);

                    return value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
