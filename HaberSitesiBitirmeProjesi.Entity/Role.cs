using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity
{
    public class Role
    {
        public Role()
        {
            this.Member =new HashSet<Member>();
        }
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<Member> Member { get; set; }
    }
}

