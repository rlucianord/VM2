namespace VM2.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Numerics;

    [Table("TipoVehiculos")]
    public partial class TipoVehiculos
    {
        public TipoVehiculos()
        {
            Placas = new HashSet<Placas>();
        }

        public int IdTipo { get; set; }

        [Required]
        [StringLength(50)]
        public string DescripcionTipo { get; set; }

        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }

        public int? CreadoPor { get; set; }
        public virtual ICollection<Placas> Placas { get; set; }
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
    }
}
