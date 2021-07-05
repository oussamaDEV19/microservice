using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FACULTATIF_EXO_3.Model;
using Microsoft.EntityFrameworkCore;


namespace FACULTATIF_EXO_3.DbContexts
{
    public class EtudiantService : DbContext, IEtudiantService
    {

        public EtudiantService(DbContextOptions<EtudiantService> options)
            : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; }

        
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
