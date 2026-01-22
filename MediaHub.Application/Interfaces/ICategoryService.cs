using MediaHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Application.Interfaces
{
    public interface ICategoryService
    {
        string GetCategoryName(string categoryName);
        public int GetCategoryId(int categoryId);
        public int GetCategoryCount(string categoryName);
        public bool IsCategoryExist(string categoryName);
        public bool IsCategoryIdExist(int categoryId);
        public List<string> GetAllCategoryNames();  
        public List<int> GetAllCategoryIds();
        public Dictionary<int, string> GetCategoryIdNameMap();
        public Dictionary<string, int> GetCategoryNameIdMap();
        public void ValidateCategoryName(string categoryName);
        public void ValidateCategoryId(int categoryId);
        public void ValidateCategoryCount(int categoryCount);
        public void ValidateCategoryExistence(string categoryName);
        public void ValidateCategoryIdExistence(int categoryId);
        public void ValidateAllCategoryNames(List<string> categoryNames);
        public void ValidateAllCategoryIds(List<int> categoryIds);
        public void ValidateAllCategoryCount(int categoryCount);
        public void ValidateAllCategoryExistence(List<string> categoryNames);
        public void ValidateAllCategoryIdsExistence(    List<int> categoryIds);
        public void ValidateAllCategoryExistenceCount(int categoryCount);
        public void ValidateAllCategoryIdsExistenceCount(int categoryCount);
        public  Task<Category> Create(Category model);  
        public  Task<Category> Delete(long Id);
        public  Task<List<Category>> ReadAllCategories();
        public  Task<Category> Update(Category model);
        public  Task<Category> Read(long Id);
    }
}
