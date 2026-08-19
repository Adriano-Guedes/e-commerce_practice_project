using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Entities;

public partial class ProdutosPedido
{
    public Guid ChavePedido { get; set; }

    public Guid ChaveProduto { get; set; }

    public int QuantidadeProduto { get; set; }

    /// <summary>
    /// Preço congelado no momento da compra
    /// </summary>
    public decimal PrecoUnitario { get; set; }

    public virtual Pedido ChavePedidoNavigation { get; set; } = null!;

    public virtual Produto ChaveProdutoNavigation { get; set; } = null!;
}
