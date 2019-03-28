using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity
{
    public class Member
    {
        public Member()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage ="e-mail formatında giriş yapınız"),
            Required(ErrorMessage ="e-mail adresinizi giriniz"),
            DisplayName("Email")
            ]
        public string Email { get; set; }
        [Required(ErrorMessage ="parolanızı giriniz"),
            DisplayName("Password")]
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string Photo { get; set; }
        public virtual Role UserRole { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
