using MediaHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Domain.Interfaces
{
    public interface ICategoryInterface
    {
        Task<Category> Create(Category model);
        Task<Category> Delete(long Id);
        Task<List<Category>> ReadAllCategories();
        Task<Category> Update(Category model);
        Task<Category> Read(long Id);
        string GetCategoryName(string categoryName);
        public long GetCategoryId(long categoryId);
        public int GetCategoryCount(string categoryName);
        public bool IsCategoryExist(string categoryName);
        public bool IsCategoryIdExist(int categoryId);
        public List<string> GetAllCategoryNames();
        public List<long> GetAllCategoryIds();
        public Dictionary<long, string> GetCategoryIdNameMap();
        public Dictionary<string, long> GetCategoryNameIdMap();
        public void ValidateCategoryName(string categoryName);
        public void ValidateCategoryId(int categoryId);
        public void ValidateCategoryCount(int categoryCount);
        public void ValidateCategoryExistence(string categoryName);
        public void ValidateCategoryIdExistence(int categoryId);
        public void ValidateAllCategoryNames(List<string> categoryNames);
        public void ValidateAllCategoryIds(List<int> categoryIds);
        public void ValidateAllCategoryCount(int categoryCount);
        public void ValidateAllCategoryExistence(List<string> categoryNames);
        public void ValidateAllCategoryIdsExistence(List<int> categoryIds);
        public void ValidateAllCategoryExistenceCount(int categoryCount);
        public void ValidateAllCategoryIdsExistenceCount(int categoryCount);
    }
}
