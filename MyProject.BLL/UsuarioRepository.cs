using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.DAL.DBContext;
using MyProject.MODEL;

namespace MyProject.BLL
{
    public static class UsuarioRepository
    {
        public static Usuario Add(Usuario _usuario)
        {

            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                dbContext.Add(_usuario);
                dbContext.SaveChanges();
            }
            return _usuario;
        }

        public static Usuario GetById(int Id)
        {

            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                try
                {
                    var cliente = dbContext.Usuarios.Single(p => p.Id == Id);
                    return cliente;
                }
                catch
                {
                    return null;

                }
            }
        }

        public static List<Usuario> GetAll()
        {

            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var cliente = dbContext.Usuarios.ToList();
                return cliente;

            }
        }

        public static void Excluir(Usuario _usuario)
        {
            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var usuario = dbContext.Usuarios.Single(p => p.Id == _usuario.Id);
                dbContext.Remove(usuario);
                dbContext.SaveChanges();
            }
        }

        public static void Update(Usuario _usuario)
        {
            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var usuario = dbContext.Usuarios.Single(p => p.Id == _usuario.Id);
                usuario.Nome = _usuario.Nome;
                usuario.Login = _usuario.Login;
                usuario.Senha = _usuario.Senha;
                dbContext.SaveChanges();
            }
        }

        public static List<Usuario> QuerySQL()
        {
            using (var dbContext = new CUsersGBRDocumentsRepositoriovsLp3CinetecaMyprojectDalDatabaseDatabase1MdfContext())
            {
                var query = dbContext.Usuarios.FromSqlRaw("SELECT * FROM Usuario");
                List<Usuario> clientes = query.ToList<Usuario>();
                return clientes;
            }

        }

    

    }
}


