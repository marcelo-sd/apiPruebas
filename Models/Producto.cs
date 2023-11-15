using System;
using System.Collections.Generic;

namespace ApiPruebas.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string? CodiBarra { get; set; }

    public string? Descripcion { get; set; }

    public string? Marca { get; set; }

    public int? Idcategoria { get; set; }

    public decimal? Precio { get; set; }

    public virtual Categoria? oCategoria { get; set; }
}
