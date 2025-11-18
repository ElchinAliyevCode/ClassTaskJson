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
                        Console.WriteLine();
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
                        CreatePost();
                        break;
                    case "2":
                        Console.WriteLine();
                        ShowPosts();
                        break;
                    case "3":
                        UpdatePost();
                        break;
                    case "4":
                        DeletePost();
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
    try
    {
        List<User> users = new List<User>();
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string path = Path.Combine(projectRoot, "user.json");
        using (StreamReader sr = new StreamReader(path))
        {
            users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
        }
        foreach (var item in users)
        {
            item.ShowInfo();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


}

static void CreateUser()
{
    try
    {
        List<User> users = new List<User>();
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string path = Path.Combine(projectRoot, "user.json");
        using (StreamReader sr = new StreamReader(path))
        {
            users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
        }

        Console.Write("Id daxil edin: ");
        var userId = Convert.ToInt32(Console.ReadLine());
        User user = users.FirstOrDefault(u => u.Id == userId && u.IsDeleted == false);
        if (user != null)
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
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(json);
        }
        Console.WriteLine("User elave olundu");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

static void UpdateUser()
{
    try
    {
        List<User> users = new List<User>();
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string path = Path.Combine(projectRoot, "user.json");
        using (StreamReader sr = new StreamReader(path))
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
        var newUserName = Console.ReadLine();
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
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(json);
        }

        Console.WriteLine("User deyisdi");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

static void DeleteUser()
{
    try
    {
        List<User> users = new List<User>();
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string path = Path.Combine(projectRoot, "user.json");
        using (StreamReader sr = new StreamReader(path))
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
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(json);
        }

        Console.WriteLine("User silindi");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

static void ShowPosts()
{
    try
    {
        List<Post> posts = new List<Post>();
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string path = Path.Combine(projectRoot, "post.json");
        using (StreamReader sr = new StreamReader(path))
        {
            posts = JsonConvert.DeserializeObject<List<Post>>(sr.ReadToEnd());
        }
        foreach (var item in posts)
        {
            item.ShowPostInfo();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


}

static void CreatePost()
{
    try
    {
        List<Post> posts = new List<Post>();
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string path = Path.Combine(projectRoot, "post.json");
        using (StreamReader sr = new StreamReader(path))
        {
            posts = JsonConvert.DeserializeObject<List<Post>>(sr.ReadToEnd());
        }

        Console.Write("Id daxil edin: ");
        var postId = Convert.ToInt32(Console.ReadLine());
        var post = posts.FirstOrDefault(p => p.Id == postId);
        if (post != null)
        {
            Console.WriteLine("Bu id movcuddur basqa id gir!");
            Console.WriteLine();
            return;
        }

        Console.Write("UserId daxil edin: ");
        var postUserId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Title daxil edin: ");
        var postTitle = Console.ReadLine();
        Console.Write("Body daxil edin: ");
        var postBody = Console.ReadLine();

        Post newPost = new Post(postUserId, postId, postTitle, postBody);
        posts.Add(newPost);
        var json = JsonConvert.SerializeObject(posts);
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(json);
        }
        Console.WriteLine("Post elave olundu");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void UpdatePost()
{
    try
    {
        List<Post> posts = new List<Post>();
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string path = Path.Combine(projectRoot, "post.json");
        using (StreamReader sr = new StreamReader(path))
        {
            posts = JsonConvert.DeserializeObject<List<Post>>(sr.ReadToEnd());
        }

        Console.Write("Update ucum Id daxil edin: ");
        var postId = Convert.ToInt32(Console.ReadLine());
        var updatedPost = posts.FirstOrDefault(p => p.Id == postId);
        if (updatedPost == null)
        {
            Console.WriteLine("Id tapilmadi");
            Console.WriteLine();
            return;
        }

        Console.Write("Teze UserId daxil edin: ");
        var newPostUserId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Teze Title daxil edin: ");
        var newPostTitle = Console.ReadLine();
        Console.Write("Teze Body daxil edin: ");
        var newPostBody = Console.ReadLine();

        updatedPost.UserId = newPostUserId;
        updatedPost.Title = newPostTitle;
        updatedPost.Body = newPostBody;

        var json = JsonConvert.SerializeObject(posts);
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(json);
        }
        Console.WriteLine("Post deyisdi");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}

static void DeletePost()
{
    try
    {
        List<Post> posts = new List<Post>();
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
        string path = Path.Combine(projectRoot, "post.json");
        using (StreamReader sr = new StreamReader(path))
        {
            posts = JsonConvert.DeserializeObject<List<Post>>(sr.ReadToEnd());
        }
        Console.Write("Delete ucum Id daxil edin: ");
        var postId = Convert.ToInt32(Console.ReadLine());
        var deletePost = posts.FirstOrDefault(u => u.Id == postId && u.IsDeleted == false);
        if (deletePost == null)
        {
            Console.WriteLine("Id tapilmadi");
            Console.WriteLine();
            return;
        }
        deletePost.IsDeleted = true;
        var json = JsonConvert.SerializeObject(posts);
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(json);
        }

        Console.WriteLine("Post silindi");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}
