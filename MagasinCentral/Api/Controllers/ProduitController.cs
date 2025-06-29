using Microsoft.AspNetCore.Mvc;
using MagasinCentral.Services;
using MagasinCentral.Models;

namespace MagasinCentral.Api.Controllers
{
    [ApiController]
    [Route("api/v1/produits")]
    public class ProduitController : ControllerBase
    {
        private readonly IProduitService _produitService;
        private readonly ILogger<ProduitController> _logger;

        public ProduitController(ILogger<ProduitController> logger, IProduitService produitService)
        {
            _produitService = produitService ?? throw new ArgumentNullException(nameof(produitService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Récupère la liste de tous les produits.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProduits()
        {
            _logger.LogInformation("Récupération de tous les produits.");

            try
            {
                var produits = await _produitService.GetAllProduitsAsync();
                return Ok(produits);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération des produits.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la récupération des produits.");
            }
        }

        /// <summary>
        /// Récupère un produit par son identifiant.
        /// </summary>
        [HttpGet("{produitId:int}")]
        [ProducesResponseType(typeof(Produit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProduit(int produitId)
        {
            _logger.LogInformation("Récupération du produit avec ID {ProduitId}", produitId);

            try
            {
                var produit = await _produitService.GetProduitByIdAsync(produitId);
                if (produit == null)
                {
                    _logger.LogWarning("Produit avec ID {ProduitId} non trouvé.", produitId);
                    return NotFound($"Produit avec ID {produitId} non trouvé.");
                }

                return Ok(produit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération du produit avec ID {ProduitId}", produitId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la récupération du produit.");
            }
        }

        /// <summary>
        /// Modifie un produit existant.
        /// </summary>
        [HttpPut("{produitId:int}")]
        [ProducesResponseType(typeof(ProduitDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifierProduit(int produitId, [FromBody] ProduitDto produit)
        {
            _logger.LogInformation("Modification du produit avec ID {ProduitId}", produitId);

            try
            {
                var produitExistant = await _produitService.GetProduitByIdAsync(produitId);
                if (produitExistant == null)
                {
                    _logger.LogWarning("Produit avec ID {ProduitId} non trouvé.", produitId);
                    return NotFound($"Produit avec ID {produitId} non trouvé.");
                }

                await _produitService.ModifierProduitAsync(produitId, produit);
                return Ok(produit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la modification du produit avec ID {ProduitId}", produitId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la modification du produit.");
            }
        }
    }
}
