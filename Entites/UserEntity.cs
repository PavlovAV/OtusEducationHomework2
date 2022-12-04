using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusEducationHomework2.Entites
{
    public class UserEntity
    {
        public long UserId {get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $@"{UserId} {FirstName} {LastName}";
        }

        public string FullName =>
            $@"{FirstName} {LastName}";        
    }
}
