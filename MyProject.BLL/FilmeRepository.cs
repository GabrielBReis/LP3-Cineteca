using Microsoft.EntityFrameworkCore;
using MyProject.DAL.DBContext;
using MyProject.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BLL
{
    public static class FilmeRepository
    {
        public static Filme Add(Filme _filme)
        {

            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                dbContext.Add(_filme);
                dbContext.SaveChanges();
            }
            return _filme;
        }

        public static Filme GetById(int Id)
        {

            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                try
                {
                    var filme = dbContext.Filmes.Single(p => p.Id == Id);
                    return filme;
                }
                catch
                {
                    return null;

                }
            }
        }

        public static List<Filme> GetAll()
        {

            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var filme = dbContext.Filmes.ToList();
                return filme;

            }
        }

        public static void Excluir(Filme _filme)
        {
            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var filme = dbContext.Filmes.Single(p => p.Id == _filme.Id);
                dbContext.Remove(filme);
                dbContext.SaveChanges();
            }
        }

        public static void Update(Filme _filme)
        {
            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var filme = dbContext.Filmes.Single(p => p.Id == _filme.Id);
                filme.Titulo = _filme.Titulo;
                filme.Ano = _filme.Ano;
                filme.Elenco = _filme.Elenco;
                filme.Descricao = _filme.Descricao;
                dbContext.SaveChanges();
            }
        }

        public static List<Filme> QuerySQL()
        {
            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var query = dbContext.Filmes.FromSqlRaw("SELECT * FROM Filme");
                List<Filme> filmes = query.ToList<Filme>();
                return filmes;
            }

        }
    }
}
