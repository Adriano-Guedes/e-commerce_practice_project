using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Entities;

public partial class Produto
{
    public Guid Id { get; set; }

    public int CategoriaId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    /// <summary>
    /// Referência do arquivo no S3
    /// </summary>
    public string? NomeArquivoImagem { get; set; }

    public int QuantidadeEstoque { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<ProdutosPedido> ProdutosPedidos { get; set; } = new List<ProdutosPedido>();
}
