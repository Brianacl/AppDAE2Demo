using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDAE2Demo.Models
{
    public class Eva_cat_espacios
    {
        [Key]
        [Required]
        public Int16 IdEspacio { get; set; }
        [ForeignKey("espacio_edificio")]
        public Int16 IdEdificio { get; set; }
        public string Clave { get; set; }
        public string DesEspacio { get; set; }
        public Int16 Prioridad { get; set; }
        public string Alias { get; set; }
        public Int16 RangoTiempoReserva { get; set; }
        public Int16 Capacidad { get; set; }
        public Int16 IdTipoEstatus { get; set; }
        public Int16 IdEstatus { get; set; }
        public string RefeUbicacion { get; set; }
        public string PermiteCruce { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
}
