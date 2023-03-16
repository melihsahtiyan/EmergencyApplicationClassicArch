using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Source : Entity
    {
        public string SourcePath { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public string SourceCategory { get; set; }
        public virtual Post Post { get; set; }

        public Source()
        {

        }

        public Source(int id, string sourcePath, DateTime date, int postId, string sourceCategory) : this()
        {
            Id = id;
            SourcePath = sourcePath;
            Date = date;
            PostId = postId;
            SourceCategory = sourceCategory;
        }
    }
}
