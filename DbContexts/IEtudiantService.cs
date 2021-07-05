using FACULTATIF_EXO_3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FACULTATIF_EXO_3.DbContexts
{
    public interface IEtudiantService
    {
        DbSet<Etudiant> Etudiants { get; set; }
        Task<int> SaveChanges();
    }
}
