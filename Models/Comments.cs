using Starpholio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Starpholio.Models
{
    public class Comments
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "This field must be used.")]
        public string Comment { get; set; }

        public DateTime DataDoComentario { get; set; }

        [ForeignKey("User")]
        public int UtilizadorId { get; set; }
        public Users1 User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Posts Post { get; set; }
    }
}