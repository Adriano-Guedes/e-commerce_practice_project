using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Entities;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
