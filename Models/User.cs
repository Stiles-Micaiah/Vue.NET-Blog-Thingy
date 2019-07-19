using System.ComponentModel.DataAnnotations;

namespace NETBlog_Thingy.Models
{
  public class User
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    // FIXME  passHash
    public string PassHash { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    public int Phone { get; set; }
  }
}





// \          SORRY            /
//  \                         /
//   \    This page does     /
//    ]   not exist yet.    [    ,'|
//    ]                     [   /  |
//    ]___               ___[ ,'   |
//    ]  ]\             /[  [ |:   |
//    ]  ] \           / [  [ |:   |
//    ]  ]  ]         [  [  [ |:   |
//    ]  ]  ]__     __[  [  [ |:   |
//    ]  ]  ] ]\ _ /[ [  [  [ |:   |
//    ]  ]  ] ] (#) [ [  [  [ :===='
//    ]  ]  ]_].nHn.[_[  [  [
//    ]  ]  ]  HHHHH. [  [  [
//    ]  ] /   `HH("N  \ [  [
//    ]__]/     HHH  "  \[__[
//    ]         NNN         [
//    ]         N/"         [
//    ]         N H         [
//   /          N            \
//  /           q,            \
// /                           \