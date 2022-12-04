using System.Data;
using System.Numerics;
using System.Runtime.CompilerServices;
using Dapper;
using Npgsql;
using OtusEducationHomework2.Entites;


string conn = "";

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    
bool exitCode = false;
while (!exitCode)
{
    Console.WriteLine(""); 
    Console.WriteLine("Choose a table to insert a row (1 - user, 2 - category, 3 - announcement), 4 - print data, 0 - exit");
    var key = Console.ReadKey();
    switch (key.KeyChar)
    {
        case '1':
            CreateUser();
            break;
        case '2':
            CreateCategory();
            break;
        case '3':
            CreateAnnouncement();
            break;
        case '4':
            PrintData();
            break;
        case '0':
            exitCode = true;
            break;
    }


}

void PrintData()
{
    Console.WriteLine("");
    using (var connection = new NpgsqlConnection(conn))
    {
        connection.Open();
        Console.WriteLine("users");
        var users = connection.Query<UserEntity>("Select user_id, first_name, last_name from public.user;");
        users.ToList().ForEach(Console.WriteLine);
        Console.WriteLine("");
        Console.WriteLine("categoryes");
        var categoryes = connection.Query<CategoryEntity>("select category_id, name from public.category;");
        categoryes.ToList().ForEach(Console.WriteLine);
        Console.WriteLine("");
        Console.WriteLine("announcements");
        var announcements = connection.Query<AnnouncementEntity>("select announcement_id, description, category as category_id, author as user_id from public.announcement;");
        foreach (var announcement in announcements)
            Console.WriteLine($@"{announcement.AnnouncementId} {announcement.Description} '{categoryes.FirstOrDefault(c => c.CategoryId == announcement.CategoryId)?.Name}' '{users.FirstOrDefault(u => u.UserId == announcement.UserId)?.FullName}'");
    }


}
void CreateUser()
{
    Console.WriteLine("");
    using (var connection = new NpgsqlConnection(conn))
    {
        var addUser = new UserEntity();
        Console.Write("Insert first name:");
        addUser.FirstName = Console.ReadLine() ?? "";
        Console.Write("Insert last name:");
        addUser.LastName = Console.ReadLine() ?? "";
        connection.Open();
        connection.Query($@"Insert into public.user (first_name, last_name) values (@firstname, @lastname);", addUser);
        Console.WriteLine($@"Added user: {addUser.FullName}");
    }
}
void CreateCategory()
{
    Console.WriteLine("");
    using (var connection = new NpgsqlConnection(conn))
    {
        var addCategory = new CategoryEntity();
        Console.Write("Insert name:");
        addCategory.Name = Console.ReadLine() ?? "";
        connection.Open();
        connection.Query($@"Insert into public.category (name) values (@name);", addCategory);
        Console.WriteLine($@"Added category: {addCategory.Name}");
    }
}

void CreateAnnouncement()
{
    Console.WriteLine("");
    using (var connection = new NpgsqlConnection(conn))
    {
        var addAnnouncement = new AnnouncementEntity();
        Console.Write("Insert description:");
        addAnnouncement.Description = Console.ReadLine() ?? "";
        Console.Write("Insert author id:");
        int id = 0;
        if (Int32.TryParse(Console.ReadLine(), out id))
            addAnnouncement.UserId = id;
        Console.Write("Insert category id:");
        id = 0;
        if (Int32.TryParse(Console.ReadLine(), out id))
            addAnnouncement.CategoryId = id;
        connection.Open();
        var announcementIds = connection.Query<Guid>($@"Insert into public.Announcement (description, author, category) values (@Description, @UserId, @CategoryId) returning announcement_id;", addAnnouncement);
        addAnnouncement.AnnouncementId = announcementIds.FirstOrDefault();
        Console.WriteLine($@"Added Announcement: {addAnnouncement}");
    }
}



