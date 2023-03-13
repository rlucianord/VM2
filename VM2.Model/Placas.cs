namespace VM2.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Placas")]
    public partial class Placas
    {
        public Placas()
        {
            Vehiculos = new HashSet<Vehiculos>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegistro{ get; set; }
        [Key]
  
        [StringLength(50),RegularExpression("^[a - zA - Z0 - 9]{0, 50}$", ErrorMessage = "Solo letras y numeros")]
  
        public string PlacaNumero { get; set; }

        public int TipoVehiculo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaVenta { get; set; }

        public double ValorPlaca { get; set; }

        public int? CreadoPor { get; set; }

        public virtual TipoVehiculos TiposVehiculo { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }


    }
}
