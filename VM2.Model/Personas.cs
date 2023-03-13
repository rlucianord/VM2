namespace VM2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Personas")]
    public partial class Personas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(13)]
        public string Cedula { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }

        public int TipoPersona { get; set; }

        public int? CreadorPor { get; set; }

        public virtual TipoPersonas TipoPersonas { get; set; }

        public virtual Usuario Usuario { get; set; }


        public static explicit operator Personas(VehiculosPersonasDTO v)
        {
            Personas persona = new Personas

            {
                IdPersona = v.IdPersona,
                Nombres = v.Nombres,
                Apellidos = v.Nombres,
                Cedula = v.Cedula,
                FechaNacimiento = v.FechaNacimiento,
                TipoPersona = v.TipoPersona,
            };
            return persona;
        }
    }
}

