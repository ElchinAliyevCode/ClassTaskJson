using Newtonsoft.Json;

namespace ConsoleApp51;

public class Post
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public bool IsDeleted { get; set; }

    public Post(int userId, int id, string title, string body)
    {
        UserId = userId;
        Id = id;
        Title = title;
        Body = body;
        IsDeleted = false;
    }

    public void ShowPostInfo()
    {
        if (!IsDeleted)
        {
            Console.WriteLine($"UserId: {UserId}\nId: {Id}\nTitle: {Title}\nBody: {Body}");
            Console.WriteLine();
        }
    }

}
