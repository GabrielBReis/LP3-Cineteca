using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyProject.MODEL;

namespace MyProject.DAL.DBContext;

public partial class CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext : DbContext
{
    public CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext()
    {
    }

    public CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext(DbContextOptions<CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Filme> Filmes { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\g_b_r\\Documents\\repositorioVs\\LP3-Cineteca\\MyProject.DAL\\database\\Database1.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Filme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Filme__3214EC274DA8D862");

            entity.ToTable("Filme");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.Elenco)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("ELENCO");
            entity.Property(e => e.ImdbId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IMDb_ID");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TITULO");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Playlist__3214EC2725E63CA8");

            entity.ToTable("Playlist");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdFilme).HasColumnName("ID_FILME");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.IdFilmeNavigation).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.IdFilme)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Filme_ToPlaylist");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_ToPlaylist");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC272CA45E7B");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOGIN");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.Senha).HasColumnName("SENHA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
