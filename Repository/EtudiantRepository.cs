using FACULTATIF_EXO_3.DbContexts;
using FACULTATIF_EXO_3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FACULTATIF_EXO_3.Repository
{
    public class EtudiantRepository:IEtudiantRepository
    {
        private IEtudiantService _dbcontext;

        public EtudiantRepository(IEtudiantService dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<string> Add(Etudiant etudiant)
        {
            _dbcontext.Etudiants.Add(etudiant);
            await _dbcontext.SaveChanges();
            return etudiant.Id;
        }
 
        public async Task<Etudiant> GetByEtudiantId(string etutid)
        {
            var ete = await _dbcontext.Etudiants.Where(etedet => etedet.Id == etutid).FirstOrDefaultAsync();
            return ete;
        }

        public async Task<Etudiant> GetById(string id)
        {
            var ete = await _dbcontext.Etudiants.Where(etedet => etedet.Id == id).FirstOrDefaultAsync();
            return ete;
        }

        public async Task<string> Delete(string id)
        {
            var ete = await _dbcontext.Etudiants.Where(etedet => etedet.Id == id).FirstOrDefaultAsync();
            if (ete == null) return "Etudiant does not exists";
            _dbcontext.Etudiants.Remove(ete);
            await _dbcontext.SaveChanges();
            return "Etudiant Supprimer !!";
        }
    }
}
