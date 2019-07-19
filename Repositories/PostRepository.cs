using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using NETBlog_Thingy.Models;

namespace NETBlog_Thingy.Repositories
{
  public class PostRepository
  {
    private readonly IDbConnection _db;
    public PostRepository(IDbConnection db)
    {
      _db = db;
    }
    public Post GetById(int id)
    {
      string query = @"
      SELECT * FROM posts WHERE id = @Id;
      ";
      Post data = _db.QueryFirstOrDefault<Post>(query, new { id });
      if (data == null) throw new Exception("Nothing to show for search [post]");
      return data;

    }

    public Post Create(Post data)
    {
      string query = @"
      INSERT INTO posts (
      title,
      image,
      body,
      authorId,
      timestamp )
      VALUES (
      @Title,
      @Image,
      @Body,
      @AuthorId,
      @TimeStamp );
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;

    }

    internal IEnumerable<Post> GetAll()
    {
      return _db.Query<Post>("SELECT * FROM posts");
    }

    public Post Update(Post data)
    {
      string query = @"
      UPDATE post
      SET
      title = @Title,
      image = @Image,
      body = @Body,
      authorId = @AuthorId,
      timestamp = @TimeStamp
      WHERE id = @Id;
      SELECT * FROM posts WHERE id = @Id;
      ";

      return _db.QueryFirstOrDefault<Post>(query, data);

    }

    public string Delete(int Id)
    {
      string query = @"
      DELETE * FROM posts WHERE id = @Id
      ";
      int affectedRows = _db.Execute(query, new { Id });
      if (affectedRows > 1) throw new Exception("Much issue");
      return "Post Deleted";


    }
  }
}




















































// INSERT INTO users (name, userName, email, passHash)
//       VALUES (@Name, @UserName,@Email,@PassHash);
//       SELECT LAST_INSERT_ID();