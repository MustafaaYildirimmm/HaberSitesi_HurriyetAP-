using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity
{
    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Articles>();
        }
        [Key]
        public int ID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Articles> Articles { get; set; }
    }
}
