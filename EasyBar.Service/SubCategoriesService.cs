using EasyBar.Domain.Interfaces;
using EasyBar.Domain.Interfaces.Repository;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;

namespace EasyBar.Service
{
    public class SubCategoriesService : ISubCategoriesService
    {
        private readonly ISubCategoriesRepository _subCategoriesRepository;
        public SubCategoriesService(ISubCategoriesRepository subCategoriesRepository)
        {
            _subCategoriesRepository = subCategoriesRepository;
        }

        public IResult Delete(string guid)
        {
            throw new System.NotImplementedException();
        }

        public IResult Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public IResult GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IResult Save(SubCategoriesDto tableDto)
        {
            throw new System.NotImplementedException();
        }

        public IResult Update(SubCategoriesDto tableDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
