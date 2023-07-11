using Starpholio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Starpholio.Models
{
    public class Votes
    {
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserFK { get; set; }
        public Users1 User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Posts Post { get; set; }
    }

}