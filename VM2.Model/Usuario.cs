namespace VM2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  
    public partial class Usuario
    {
        public Usuario()
        {
            Personas = new HashSet<Personas>();
            Placas = new HashSet<Placas>();
            TipoPersonas = new HashSet<TipoPersonas>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Nombres { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        public virtual ICollection<Personas> Personas { get; set; }

        public virtual ICollection<Placas> Placas { get; set; }
        public virtual ICollection<TipoPersonas> TipoPersonas { get; set; }
    }
}
