using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Entity.Validation;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.Interfaces.Repository;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Infrastructure.Utility;
using System;

namespace EasyBar.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IResult Delete(string guid)
        {           
            if (!Util.IsGuid(guid))
            {
                return new ValidateResult(null, false, "A identificação fornecida está inválida");
            }

            ItemEntity itemEntity = _itemRepository.Get(guid);
            _itemRepository.Delete(itemEntity);

            return new ValidateResult(null, true, "Item deletado com sucesso");
        }

        public IResult Get(string name)
        {
            throw new NotImplementedException();
        }

        public IResult GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Save(ItemDto itemDto)
        {
            ItemEntity item = new ItemEntity(itemDto);

            if (_itemRepository.Get(item) != null)
                return new ValidateResult(item, false, "Item informado já existe");

            item.Validate();

            if (item.Invalid)
                return new ValidateResult(item.Notifications, false, "Problemas ao cadastrar o item");

            _itemRepository.Add(item);
            return new ValidateResult(item, true, "Item cadastrado com sucessso");
        }

        public IResult Update(ItemDto itemDto)
        {
            ItemEntity subCategories = _itemRepository.Get(itemDto.Identification);

            subCategories.SetName(itemDto.Name);
            subCategories.SetValue(itemDto.Value);
            subCategories.SetSubCategories(itemDto.SubCategories);

            subCategories.Validate();

            if (subCategories.Invalid)
            {
                return new ValidateResult(subCategories.Notifications, false, "Problemas ao atualizar o item");
            }

            _itemRepository.Update(subCategories);
            return new ValidateResult(subCategories, true, "Item atualizado com sucessso");
        }
    }
}
