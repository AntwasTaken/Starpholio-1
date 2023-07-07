using Microsoft.Extensions.Hosting;
﻿using System.Collections.Generic;

namespace Starpholio.Models {
    public class Users1
    {

        public Users1()
        {
            Posts = new HashSet<Posts>();
            Votes = new HashSet<Votes>();
            Comentarios = new HashSet<Comments>();
        }

        public int ID { get; set; }

        public string Email { get; set; }

        //lista de Posts
        public virtual ICollection<Posts> Posts { get; set; }
        //lista de votos
        public virtual ICollection<Votes> Votes { get; set; }
        //lista de comentários
        public virtual ICollection<Comments> Comentarios { get; set; }
    }
}
