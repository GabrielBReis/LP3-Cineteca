using System;
using System.Collections.Generic;

namespace MyProject.MODEL;

public partial class Filme
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int Ano { get; set; }

    public string Elenco { get; set; } = null!;

    public string? ImdbId { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
