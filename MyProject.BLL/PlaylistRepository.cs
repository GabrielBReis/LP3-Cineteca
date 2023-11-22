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
    public static class PlaylistRepository
    {
        public static Playlist Add(Playlist _playlist)
        {

            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                dbContext.Add(_playlist);
                dbContext.SaveChanges();
            }
            return _playlist;
        }

        public static Playlist GetById(int Id)
        {

            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                try
                {
                    var playlist = dbContext.Playlists.Single(p => p.Id == Id);
                    return playlist;
                }
                catch
                {
                    return null;

                }
            }
        }

        public static List<Playlist> GetAll()
        {

            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var playlist = dbContext.Playlists.ToList();
                return playlist;

            }
        }

        public static void Excluir(Playlist _playlist)
        {
            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var playlist = dbContext.Playlists.Single(p => p.Id == _playlist.Id);
                dbContext.Remove(playlist);
                dbContext.SaveChanges();
            }
        }

     

        public static List<Playlist> QuerySQL()
        {
            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var query = dbContext.Playlists.FromSqlRaw("SELECT * FROM Playlist");
                List<Playlist> playlists = query.ToList<Playlist>();
                return playlists;
            }

        }
    }
}
