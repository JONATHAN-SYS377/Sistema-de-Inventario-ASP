﻿using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Inventario_ASP.Models
{
    public class Producto
    {
        //============================================================================================================================
        [Key]
        [Display(Name = "Código Producto")]
        public int IDCodigo { get; set; }
        //============================================================================================================================


        //============================================================================================================================
        [Required(ErrorMessage = "El nombre del producto es Obligatorio")]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }
        //============================================================================================================================

        //============================================================================================================================
        [Display(Name = "Categoria del Producto")]
        public int CategoriaID { get; set; }
        //============================================================================================================================

        //============================================================================================================================
        [Required(ErrorMessage = "El costo es obligatorio")]
        [Display(Name = "Costo Unitario del Producto")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Por favor, ingrese un número válido")]
        public float Costo { get; set; }
        //============================================================================================================================

        //============================================================================================================================
        [Required(ErrorMessage = "El Precio de venta es Obligatorio")]
        [Display(Name = "Precio de Venta")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Por favor, ingrese un número válido")]
        public float PrecioVenta { get; set; }
        //============================================================================================================================

        //============================================================================================================================
        [Required(ErrorMessage = "La Utilidad es Obligatoria")]
        public float Utilidad { get; set; }
        //============================================================================================================================

        //============================================================================================================================
        [Required(ErrorMessage = "El impuesto es Obligatorio")]
        public float Impuesto { get; set; }
        //============================================================================================================================

        //============================================================================================================================
        [Required(ErrorMessage = "El Descuento es Obligatorio")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Por favor, ingrese un número válido")]
        public float Descuento { get; set; }
        //============================================================================================================================

        //============================================================================================================================
        [Required(ErrorMessage = "La cantidad es Obligatoria")]
        [Display(Name = "Cantidad Actual")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Por favor, ingrese un número válido")]
        public int CantidadActual { get; set; }
        //=============================================================================================================================

        //============================================================================================================================
        [Display(Name = "Estado del Producto")]
        public int EstadoID { get; set; }

        //============================================================================================================================


        public virtual Categoria Categoria { get; set; }

        public virtual Estado Estado { get; set; }
    }
}
