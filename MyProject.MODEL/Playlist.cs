using System;
using System.Collections.Generic;

namespace MyProject.MODEL;

public partial class Playlist
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdFilme { get; set; }

    public virtual Filme IdFilmeNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
