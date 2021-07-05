using FACULTATIF_EXO_3.Model;
using FACULTATIF_EXO_3.Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace FACULTATIF_EXO_3.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private IEtudiantRepository _etudiantRepository;
        public EtudiantController(IEtudiantRepository etudiantRepository)
        {
            _etudiantRepository = etudiantRepository;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] Etudiant etudiantdet)
        {
            try
            {
                Log.Debug("Etudiant Addition Started");
                Log.Debug("Etudiant Addition Input", etudiantdet);
                string orderid = await _etudiantRepository.Add(etudiantdet);
                Log.Debug("Etudiant Addition Output", orderid);
                return Ok(orderid);
            }
            catch (Exception ex)
            {
                Log.Error("Order Addition Failed", ex);
                throw new Exception("Order Addition Failed", innerException: ex);
            }
        }
        [HttpGet]
        [Route("GetByEtudiantId/{id}")]
        public async Task<ActionResult> GetByEtudiantId(string id)
        {
            var etudiants = await _etudiantRepository.GetByEtudiantId(id);
            return Ok(etudiants);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var etudiantdet = await _etudiantRepository.GetById(id);
            return Ok(etudiantdet);
        }

        [HttpDelete]
        [Route("Cancel/{id}")]
        public async Task<IActionResult> Cancel(string id)
        {
            string resp = await _etudiantRepository.Delete(id);
            return Ok(resp);
        }
    }
}