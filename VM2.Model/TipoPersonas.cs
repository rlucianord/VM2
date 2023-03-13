namespace VM2.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoPersonas")]
    public partial class TipoPersonas
    {
        public TipoPersonas()
        {
            Personas = new HashSet<Personas>();
        }

        [Key]
        public int IdTIpoPersona { get; set; }

        [Required]
        [StringLength(50)]
        public string DescripcionTipo { get; set; }
        [Required, StringLength(1)]
        public string Tipo { get; set; }
        public int Creadopor { get; set; }
        public virtual ICollection<Personas> Personas { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
