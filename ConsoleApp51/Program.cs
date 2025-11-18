using ConsoleApp51;
using Newtonsoft.Json;

bool inMain = true;
while (inMain)
{
    Console.WriteLine("1) Users");
    Console.WriteLine("2) Posts");
    Console.WriteLine("3) Cixis edin");
    Console.Write("Secim edin: ");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            bool inUserMenu = true;
            while (inUserMenu)
            {
                Console.WriteLine();
                Console.WriteLine("User menu");
                Console.WriteLine("1) Create User");
                Console.WriteLine("2) Show All Users");
                Console.WriteLine("3) Update User");
                Console.WriteLine("4) Delete User");
                Console.WriteLine("5) User menudan cixis edin");
                Console.Write("Secim edin: ");
                var choiceUser = Console.ReadLine();
                switch (choiceUser)
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        ShowUsers();
                        break;
                    case "3":
                        UpdateUser();
                        break;
                    case "4":
                        DeleteUser();
                        break;
                    case "5":
                        inUserMenu = false;
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Yanlis secim");
                        Console.WriteLine();
                        break;
                }

            }
            break;
        case "2":
            bool inPostMenu = true;
            while (inPostMenu)
            {
                Console.WriteLine();
                Console.WriteLine("Post menu");
                Console.WriteLine("1) Create Post");
                Console.WriteLine("2) Show All Posts");
                Console.WriteLine("3) Update Post");
                Console.WriteLine("4) Delete Post");
                Console.WriteLine("5) Post menudan cixis edin");
                Console.Write("Secim edin: ");
                var choicePost = Console.ReadLine();
                switch (choicePost)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        inPostMenu = false;
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Yanlis secim");
                        Console.WriteLine();
                        break;
                }

            }
            break;
        case "3":
            inMain = false;
            break;
        default:
            Console.WriteLine("Yanlis secim");
            Console.WriteLine();
            break;
    }
}

static void ShowUsers()
{
    List<User> users = new List<User>();
    using (StreamReader sr = new StreamReader("C:\\Users\\student\\source\\repos\\ConsoleApp51\\ConsoleApp51\\user.json"))
    {
        users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
    }
    foreach (var item in users)
    {
        item.ShowInfo();
    }

}

static void CreateUser()
{
    List<User> users = new List<User>();
    using (StreamReader sr = new StreamReader("C:\\Users\\student\\source\\repos\\ConsoleApp51\\ConsoleApp51\\user.json"))
    {
        users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
    }

    Console.Write("Id daxil edin: ");
    var userId = Convert.ToInt32(Console.ReadLine());
    User updateUser = users.FirstOrDefault(u => u.Id == userId && u.IsDeleted == false);
    if (updateUser != null)
    {
        Console.WriteLine("Bu id movcuddur basqa id gir!");
        Console.WriteLine();
        return;
    }
    Console.Write("Name daxil edin: ");
    var userName = Console.ReadLine();
    Console.Write("Username daxil edin: ");
    var userUsername = Console.ReadLine();
    Console.Write("Email daxil edin: ");
    var userEmail = Console.ReadLine();
    Console.Write("Phone daxil edin: ");
    var userPhone = Console.ReadLine();
    Console.Write("Website daxil edin: ");
    var userWebsite = Console.ReadLine();

    User newUser = new User(userId, userName, userUsername, userEmail, userPhone, userWebsite);
    users.Add(newUser);
    var json = JsonConvert.SerializeObject(users);
    using (StreamWriter sw = new StreamWriter("C:\\Users\\student\\source\\repos\\ConsoleApp51\\ConsoleApp51\\user.json"))
    {
        sw.WriteLine(json);
    }
    Console.WriteLine("User elave olundu");
    Console.WriteLine();
}

static void UpdateUser()
{
    List<User> users = new List<User>();
    using (StreamReader sr = new StreamReader("C:\\Users\\student\\source\\repos\\ConsoleApp51\\ConsoleApp51\\user.json"))
    {
        users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
    }

    Console.Write("Update ucum Id daxil edin: ");
    var userId = Convert.ToInt32(Console.ReadLine());
    User updateUser = users.FirstOrDefault(u => u.Id == userId && u.IsDeleted == false);
    if (updateUser == null)
    {
        Console.WriteLine("Id tapilmadi");
        Console.WriteLine();
        return;
    }

    Console.Write("Teze name daxil edin: ");
    var newUserName=Console.ReadLine();
    Console.Write("Teze username daxil edin: ");
    var newUserUsername = Console.ReadLine();
    Console.Write("Teze email daxil edin: ");
    var newUserEmail = Console.ReadLine();
    Console.Write("Teze phone daxil edin: ");
    var newUserPhone = Console.ReadLine();
    Console.Write("Teze website daxil edin: ");
    var newUserWebsite = Console.ReadLine();

    updateUser.Name = newUserName;
    updateUser.Username = newUserUsername;
    updateUser.Email = newUserEmail;
    updateUser.Phone = newUserPhone;
    updateUser.Website = newUserWebsite;

    var json = JsonConvert.SerializeObject(users);
    using (StreamWriter sw = new StreamWriter("C:\\Users\\student\\source\\repos\\ConsoleApp51\\ConsoleApp51\\user.json"))
    {
        sw.WriteLine(json);
    }

    Console.WriteLine("User deyisdi");
    Console.WriteLine();
}

static void DeleteUser()
{
    List<User> users = new List<User>();
    using (StreamReader sr = new StreamReader("C:\\Users\\student\\source\\repos\\ConsoleApp51\\ConsoleApp51\\user.json"))
    {
        users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
    }

    Console.Write("Delete ucum Id daxil edin: ");
    var userId = Convert.ToInt32(Console.ReadLine());
    User deleteUser = users.FirstOrDefault(u => u.Id == userId && u.IsDeleted == false);

    if (deleteUser == null)
    {
        Console.WriteLine("Id tapilmadi");
        Console.WriteLine();
        return;
    }

    deleteUser.IsDeleted = true;

    var json = JsonConvert.SerializeObject(users);
    using (StreamWriter sw = new StreamWriter("C:\\Users\\student\\source\\repos\\ConsoleApp51\\ConsoleApp51\\user.json"))
    {
        sw.WriteLine(json);
    }

    Console.WriteLine("User silindi");
    Console.WriteLine();
}