using System;
using System.ComponentModel.DataAnnotations;

namespace NETBlog_Thingy.Models
{
  public class Post
  {
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Image { get; set; }
    [Required]
    public string Body { get; set; }
    [Required]
    public int AuthorId { get; set; }

    public string TimeStamp { get; set; }
    //DateTimeOffset
  }
}