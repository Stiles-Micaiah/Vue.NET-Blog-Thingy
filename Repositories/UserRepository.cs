using System;
using System.Data;
using Dapper;
using NETBlog_Thingy.Models;

namespace NETBlog_Thingy.Repositories
{
  public class UserRepository
  {
    private readonly IDbConnection _db;
    public UserRepository(IDbConnection db)
    {
      _db = db;
    }
    public User GetById(int id)
    {
      string query = @"
      SELECT * FROM users WHERE id = @id
      ";
      User data = _db.QueryFirstOrDefault<User>(query, new { id });
      if (data == null) throw new Exception("Invalid User details");
      return data;
    }

    public User Create(User data)
    {
      string query = @"
      INSERT INTO users (name, userName, email, passHash)
      VALUES (@Name, @UserName,@Email,@PassHash);
      SELECT LAST_INSERT_ID(); 
      ";
      //NOTE SELECTED LAST_INSERTED_ID(); returns the id of the last created. therefore this query returns an int. only because i set id to an int
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;
    }

    public User Update(User data)
    {
      string query = @"
      UPDATE users
      SET 
      name = @Name,
      userName = @UserName,
      email = @Email,
      passHash = @PassHash,
      phone = @Phone
      WHERE id = @Id;
      SELECT * FROM users WHERE id = @Id;
      ";
      return _db.QueryFirstOrDefault<User>(query, data);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM users WHERE id = @Id";
      int affectedRows = _db.Execute(query, new { id });
      if (affectedRows < 1) throw new Exception("user not found");
      return "You no loner exist!";
    }
  }
}