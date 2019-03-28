using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiBitirmeProjesi.Entity
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public Nullable<int> ArticleId { get; set; }
        public bool IsCheck { get; set; }
        public Nullable<int> MemberId { get; set; }
        public DateTime Date { get; set; }
        public virtual Articles Article { get; set; }
        public virtual Member Member { get; set; }
    }
}
