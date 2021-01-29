using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwensonHE.Store.DTO;
using SwensonHE.Store.Ground.Enums;
using SwensonHE.Store.Service.Interfaces;
using SwensonHE.Store.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwensonHE.Store.API.Controllers
{
    /// <summary>
    /// All SKU Item Pods Either Coffee or Espresso
    /// </summary>
    [Route("")]
    [ApiController]
    public class PodController : BaseController
    {
        private readonly Lazy<IItemSKUServices> _itemSKUServices;

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="itemSKUServices"></param>
        public PodController(Lazy<IItemSKUServices> itemSKUServices)
        {
            _itemSKUServices = itemSKUServices;
        }

        private IItemSKUServices ItemSKUServices => _itemSKUServices.Value;

        /// <summary>
        /// Get Item SKU Pods
        /// </summary>
        /// <remarks>
        /// Used to Get Item Pods Skue and you can filter with:
        /// 1- Water Comptapility
        /// 2- Size
        /// 3- Pack size
        /// </remarks>
        /// <param name="itemSKUDTORequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("pods/GetItemPods")]
        [ProducesResponseType(typeof(ServiceResultList<ItemSKUDTOResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetItemPods([FromBody] ItemSKUDTORequest itemSKUDTORequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            itemSKUDTORequest.SetProductType(ProductTypeEnum.Pods);
            var result = await ItemSKUServices.GetSKUList(itemSKUDTORequest);
            if (!result.IsValid)
            {
                return GetErrorResult(result);
            }

            return Ok(result);
        }
    }
}
