using System;
using System.Collections.Generic;

namespace MyProject.MODEL;

public partial class Usuario
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public int? Senha { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
