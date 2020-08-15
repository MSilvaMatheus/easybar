using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using System;

namespace EasyBar.Service
{
    public class ItemService : IItemService
    {
        public ItemService()
        {

        }

        public IResult Delete(string guid)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IResult Update(ItemDto itemDto)
        {
            throw new NotImplementedException();
        }
    }
}
