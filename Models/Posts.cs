using Starpholio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Starpholio.Models
{
    public class Posts
    {

        public Posts()
        {

            Votes = new HashSet<Votes>();
            Comments = new HashSet<Comments>();
        }
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "o Titulo é de preenchimento obrigatório.")]
        public string title { get; set; }
        [Required(ErrorMessage = "o Conteudo é de preenchimento obrigatório.")]
        public string content { get; set; }
        [Required(ErrorMessage = "A imagem é de preenchimento obrigatório.")]
        public string Image { get; set; }
        public Boolean Hidden { get; set; }

        public Boolean Deleted { get; set; }

        [ForeignKey("User")]
        public int UtilizadorId { get; set; }
        public Users1 User { get; set; }

        [ForeignKey("CategoriesColour")]
        public int CategoriesColourId { get; set; }
        public CategoriesColour CategoriesColour { get; set; }

        [ForeignKey("CategoriesStyle")]
        public int CategoriesStyleId { get; set; }
        public CategoriesStyle CategoriesStyle { get; set; }

        //lista de votos
        public virtual ICollection<Votes> Votes { get; set; }
        //lista de comentários
        public virtual ICollection<Comments> Comments { get; set; }

    }
}