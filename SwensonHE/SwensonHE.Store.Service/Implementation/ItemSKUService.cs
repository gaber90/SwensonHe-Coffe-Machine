﻿using SwensonHE.Store.DTO;
using SwensonHE.Store.Service.Interfaces;
using SwensonHE.Store.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SwensonHE.Store.Service.Implementation
{
    public class ItemSKUService : IItemSKUServices
    {

        private readonly Lazy<IItemSKUServiceValidator> _itemSKUServiceValidator;
        private readonly Lazy<IItemSKURepository> _itemSKURepository;
        public ItemSKUService(Lazy<IItemSKUServiceValidator> itemSKUServiceValidator, Lazy<IItemSKURepository> itemSKURepository)
        {
            _itemSKUServiceValidator = itemSKUServiceValidator;
            _itemSKURepository = itemSKURepository;
        }


        private IItemSKUServiceValidator ItemSKUServiceValidator => _itemSKUServiceValidator.Value;
        private IItemSKURepository ItemSKURepository => _itemSKURepository.Value;

        /// <summary>
        /// GetSKUList Methos to Validate the object request the starting to retrive the KSU items from the repository
        /// </summary>
        /// <param name="itemSKUDTORequest"></param>
        /// <returns></returns>
        public async Task<ServiceResultList<ItemSKUDTOResponse>> GetSKUList(ItemSKUDTORequest itemSKUDTORequest)
        {
            ValidatorResult validationResult;
            validationResult = await ItemSKUServiceValidator.GetSKUListValidator(itemSKUDTORequest.FlavorType, itemSKUDTORequest.ProductType, itemSKUDTORequest.ItemSize, itemSKUDTORequest.Modeltype);
            if (!validationResult.IsValid)
            {
                return new ServiceResultList<ItemSKUDTOResponse>()
                {
                    IsValid = false,
                    Status = validationResult.Status,
                    Messages = new List<string>() { validationResult.Message }
                };
            }
            var skuDate = await ItemSKURepository.GetIetmSKU(itemSKUDTORequest);
            if (!skuDate.Any())
            {
                return new ServiceResultList<ItemSKUDTOResponse>()
                {
                    IsValid = false,
                    Status = validationResult.Status,
                    Messages = new List<string>() { "Items don't Exist" }
                };
            }

            var data = skuDate.Select(a => new ItemSKUDTOResponse
            {
                SKUCode = a.Code
            }).ToList();

            return new ServiceResultList<ItemSKUDTOResponse>()
            {
                Model = data,
                Count = data.Count,
            };

        }
    }
}
