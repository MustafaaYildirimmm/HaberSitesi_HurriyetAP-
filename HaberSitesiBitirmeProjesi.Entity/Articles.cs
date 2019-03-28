using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity
{
    public class Articles
    {
        public Articles()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime NewsDate { get; set; }
        public string Description { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Photo { get; set; }
        public int ArticleId { get; set; }
        public string Text { get; set; }

        public virtual Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
