using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiPruebas.Models;

public partial class Categoria
{
    public int Idcategoria { get; set; }

    public string? Descripcion { get; set; }

    [JsonIgnore]

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
