using FACULTATIF_EXO_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FACULTATIF_EXO_3.Repository
{
    public interface IEtudiantRepository
    {
        Task<string> Add(Etudiant etudiant);
        Task<Etudiant> GetById(string id);
        Task<Etudiant> GetByEtudiantId(string etuid);
        Task<string> Delete(string id);
    }
}
