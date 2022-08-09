using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace AppLembrete.Models
{
    // Defininco como a classe sera reconhecida no banco de dados
    [Table("Anotacoes")]
    public class ModelNotas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public String Titulo { get; set; }
        [NotNull]
        public String Nota { get; set; }
        [NotNull]
        public Boolean Favorito { get; set; }
        public ModelNotas()
        {
            this.Id = 0;
            this.Titulo = "";
            this.Nota = "";
            this.Favorito = false;
        }
            

    }
}
