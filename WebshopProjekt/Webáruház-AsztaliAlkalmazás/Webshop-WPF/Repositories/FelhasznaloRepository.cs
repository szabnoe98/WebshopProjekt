using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Webshop_WPF.Models;
using Webshop_WPF.Services;

namespace Webshop_WPF.Repositories
{
    public class FelhasznaloRepository
    {
        private webaruhazContext db;
        public FelhasznaloRepository()
        {
            db = new webaruhazContext();
        }
        public string Authenticate(string username, string password)
        {
            // Elérhető-e az adatbázis
            if (!db.Database.CanConnect())
            {
                return "Az adatbázis nem elérhető.";
            }
            admin dbUser = db.admin
                                
                .AsNoTracking()
                .SingleOrDefault(x => x.Felhasznalonev == username);
            if (dbUser != null)
            {
                // passwordHash
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                bool verified = BCrypt.Net.BCrypt.Verify(password, dbUser.Jelszo);
                if (verified)
                {
                    CurrentUser.Id = dbUser.id;
                    CurrentUser.UserName = dbUser.Felhasznalonev;
                    return "Sikeres bejelentkezés";
                }
                else
                {
                    return "Hibás felhasználónév vagy jelszó.";
                }
            }
            else
            {
                
                return "A felhasználó nem létezik.";
            }
        }
    }
}
