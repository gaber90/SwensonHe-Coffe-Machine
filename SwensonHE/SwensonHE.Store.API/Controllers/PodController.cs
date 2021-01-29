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

    [Route("")]
    [ApiController]
    public class PodController : BaseController
    {
        private readonly Lazy<IItemSKUServices> _itemSKUServices;

        public PodController(Lazy<IItemSKUServices> itemSKUServices)
        {
            _itemSKUServices = itemSKUServices;
        }

        private IItemSKUServices ItemSKUServices => _itemSKUServices.Value;

        [HttpPost]
        [Route("pods/GetItemPods")]
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
