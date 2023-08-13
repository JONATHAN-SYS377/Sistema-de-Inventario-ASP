using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Inventario_ASP.Models
{
    public class Categoria
    {
        //================================================================================================
        public int Id { get; set; }
        //================================================================================================

        //================================================================================================
        [Required(ErrorMessage = "El nombre de la Categoria es Obligatoria")]
        [Display(Name = "Nombre de la Categoria")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Por favor, ingrese solo letras y espacios")]
        public string NombreCategoria { get; set; }
        //================================================================================================
    }
}
