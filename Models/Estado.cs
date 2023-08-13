using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Inventario_ASP.Models
{
    public class Estado
    {
        //================================================================================================
        public int Id { get; set; }
        //================================================================================================

        //================================================================================================
        [Required(ErrorMessage = "El Estado es Obligtorio")]
        [Display(Name = "Estado del Producto")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Por favor, ingrese solo letras y espacios")]
        public string NombreEstado { get; set; }
        //================================================================================================
    }
}
