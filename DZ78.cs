using System;
using System.Collections.Generic;

class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public List<Post> Posts { get; set; } = new List<Post>(); 
    public List<Friend> Friends { get; set; } = new List<Friend>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
}

class Post
{
    public int Id { get; set; }
    public User User { get; set; }
    public DateTime DatePublished { get; set; }
    public string Text { get; set; }
    public string Image { get; set; }

    public List<Comment> Comments { get; set; } = new List<Comment>();
}

class Friend
{
    public User User { get; set; }
    public User Friend { get; set; }
}

class Comment
{
    public int Id { get; set; }
    public User User { get; set; }
    public Post Post { get; set; }
    public DateTime DatePublished { get; set; }
    public string Text { get; set; }
}
