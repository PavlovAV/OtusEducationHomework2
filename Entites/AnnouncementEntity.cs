using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OtusEducationHomework2.Entites
{
    internal class AnnouncementEntity
    {
        public Guid AnnouncementId { get; set; }

        public string Description { get; set; }

        public long CategoryId { get; set; }

        public long UserId { get; set; }

        public override string ToString()
        {
            return $@"{AnnouncementId} {Description} '{CategoryId}' '{UserId}'";
        }
    }
}
