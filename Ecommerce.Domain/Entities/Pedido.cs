using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Entities;

public partial class Pedido
{
    public Guid Id { get; set; }

    public Guid ChaveUsuario { get; set; }

    public decimal PrecoTotal { get; set; }

    public DateTime DataCriacao { get; set; }

    public virtual Usuario ChaveUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ProdutosPedido> ProdutosPedidos { get; set; } = new List<ProdutosPedido>();
}
