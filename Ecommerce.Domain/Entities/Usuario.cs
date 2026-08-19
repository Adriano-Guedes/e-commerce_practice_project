using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Entities;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Papel { get; set; } = null!;

    /// <summary>
    /// Opcional / Único se preenchido
    /// </summary>
    public string? Cpf { get; set; }

    /// <summary>
    /// Referência do arquivo no S3
    /// </summary>
    public string? NomeArquivoImagem { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
