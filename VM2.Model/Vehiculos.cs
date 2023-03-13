namespace VM2.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vehiculos")]
    public partial class Vehiculos
    {
        [Key]
        public int IdVehiculo { get; set; }
        [ForeignKey("Personas")]
        public int IdPersona { get; set; }
        [Required]
        [StringLength(50), ForeignKey("Placa")]
        public string PlacaNumero { get; set; }
       [ForeignKey("TipoVehiculos")]
        public int TipoVehiculo { get; set; }
        [StringLength(50)]
        [Required]

        public string Marca { get; set; }
        [Required]

        [StringLength(50)]
        public string Modelo { get; set; }
        [Required]

        public int Anio { get; set; }
        [Required]

        public int Creadopor { get; set; }
        public virtual Placas Placa { get; set; }
        public virtual Personas Personas { get; set; }
        public virtual TipoVehiculos TipoVehiculos { get; set; }




    }
}
