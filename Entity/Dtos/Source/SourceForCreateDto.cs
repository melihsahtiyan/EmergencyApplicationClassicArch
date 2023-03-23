using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.Source
{
    public class SourceForCreateDto
    {
        public int Id { get; set; }
        public string SourcePath { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public string SourceCategory { get; set; }
    }
}
