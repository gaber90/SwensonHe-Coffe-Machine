using Microsoft.AspNetCore.Mvc;
using SwensonHE.Store.DTO;
using SwensonHE.Store.Ground.Enums;
using SwensonHE.Store.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwensonHE.Store.API.Controllers
{
    /// <summary>
    /// All SKU Item Machines Either Coffee or Espresso
    /// </summary>
    [Route("")]
    [ApiController]
    public class MachineController : BaseController
    {
        private readonly Lazy<IItemSKUServices> _itemSKUServices;

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="itemSKUServices"></param>
        public MachineController(Lazy<IItemSKUServices> itemSKUServices)
        {
            _itemSKUServices = itemSKUServices;
        }

        private IItemSKUServices ItemSKUServices => _itemSKUServices.Value;

        /// <summary>
        /// Get Item SKU Machine
        /// </summary>
        /// <remarks>
        /// Used to Get Item Machine Skue and you can filter with:
        /// 1- Water Comptapility
        /// 2- Size
        /// 3- Pack size
        /// </remarks>
        /// <param name="itemSKUDTORequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("machines/GetItemMachines")]
        public async  Task<IActionResult> GetItemMachines([FromBody] ItemSKUDTORequest itemSKUDTORequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            itemSKUDTORequest.SetProductType(ProductTypeEnum.Machines);
            var result = await ItemSKUServices.GetSKUList(itemSKUDTORequest);
            if (!result.IsValid)
            {
                return GetErrorResult(result);
            }

            return Ok(result);
        }
    }
}
