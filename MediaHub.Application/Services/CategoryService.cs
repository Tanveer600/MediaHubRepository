using MediaHub.Application.Interfaces;
using MediaHub.Domain.Entities;
using MediaHub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryInterface _category;
        public CategoryService(ICategoryInterface category)
        {
                _category = category;   
        }
        public async Task<Category> Create(Category model)
        {
            ResponseDataModel response = new ResponseDataModel();
            try
            {
                var result = await _category.Create(model);
              if (result != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Category created successfully.";
                    response.Data = result;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Failed to create category.";
                }
                return result;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = "An error occurred while creating the category.";
                response.ErrorMessage = ex.Message;
            }
        }

        public async Task<Category> Delete(long Id)
        {
            ResponseDataModel response = new ResponseDataModel();
            try
            {
                var result = await _category.Delete(Id);
                if (result != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Category deleted successfully.";
                    response.Data = result;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Failed to delete category.";
                }
            }
            catch (Exception ex)
            {

            response.IsSuccess = false;
                response.Message = "An error occurred while deleting the category.";
                response.ErrorMessage = ex.Message;
            }
        }

        public List<int> GetAllCategoryIds()
        {
           var list=_category.GetAllCategoryIds();
            return list;
        }

        public List<string> GetAllCategoryNames()
        {
            throw new NotImplementedException();
        }

        public int GetCategoryCount(string categoryName)
        {
            throw new NotImplementedException();
        }

        public int GetCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> GetCategoryIdNameMap()
        {
            throw new NotImplementedException();
        }

        public string GetCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetCategoryNameIdMap()
        {
            throw new NotImplementedException();
        }

        public bool IsCategoryExist(string categoryName)
        {
            throw new NotImplementedException();
        }

        public bool IsCategoryIdExist(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Read(long Id)
        {
            var result=await _category.Read(Id);
            return result;
        }

        public async Task<List<Category>> ReadAllCategories()
        {
            var result= await _category.ReadAllCategories();
            return result;
        }

        public async Task<Category> Update(Category model)
        {
           var result=await _category.Update(model);
            return result;  
        }

        public void ValidateAllCategoryCount(int categoryCount)
        {
            throw new NotImplementedException();
        }

        public void ValidateAllCategoryExistence(List<string> categoryNames)
        {
            throw new NotImplementedException();
        }

        public void ValidateAllCategoryExistenceCount(int categoryCount)
        {
            throw new NotImplementedException();
        }

        public void ValidateAllCategoryIds(List<int> categoryIds)
        {
            throw new NotImplementedException();
        }

        public void ValidateAllCategoryIdsExistence(List<int> categoryIds)
        {
            throw new NotImplementedException();
        }

        public void ValidateAllCategoryIdsExistenceCount(int categoryCount)
        {
            throw new NotImplementedException();
        }

        public void ValidateAllCategoryNames(List<string> categoryNames)
        {
            throw new NotImplementedException();
        }

        public void ValidateCategoryCount(int categoryCount)
        {
            throw new NotImplementedException();
        }

        public void ValidateCategoryExistence(string categoryName)
        {
            throw new NotImplementedException();
        }

        public void ValidateCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void ValidateCategoryIdExistence(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void ValidateCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
