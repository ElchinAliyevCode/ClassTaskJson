namespace ConsoleApp51;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Website { get; set; }
    public bool IsDeleted { get; set; }

    public User(int id, string name, string username, string email, string phone, string website)
    {
        Id = id;
        Name = name;
        Username = username;
        Email = email;
        Phone = phone;
        Website = website;
        IsDeleted = false;
    }

    public void ShowInfo()
    {
        if (!IsDeleted)
        {
            Console.WriteLine($"Id: {Id}\nName: {Name}\nUsername: {Username}\nEmail: {Email}\nPhone: {Phone}\nWebsite: {Website}");
            Console.WriteLine();
        }
    }

}
