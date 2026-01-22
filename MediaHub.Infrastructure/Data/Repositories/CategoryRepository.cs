using MediaHub.Domain.Entities;
using MediaHub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryInterface
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category model)
        {
            var result = await _context.Categories.AddAsync(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> Delete(long Id)
        {
           var caregory=await _context.Categories.FindAsync(Id);
            if(caregory != null)
            {
                _context.Categories.Remove(caregory);
                await _context.SaveChangesAsync();
                return caregory;
            }
            return null;
        }

        public List<long> GetAllCategoryIds()
        {
            var categoryIds = _context.Categories.Select(c => c.Id).ToList();
            return categoryIds;
        }

        public  List<string> GetAllCategoryNames()
        {
            var categorynameList=  _context.Categories.Select(x=>x.Name).ToList();   
            return categorynameList;
        }

        public int GetCategoryCount(string categoryName)
        {
            var countlist= _context.Categories.Count(c => c.Name == categoryName);
            return countlist;
        }

        public long GetCategoryId(long categoryId)
        {
           var category=_context.Categories.Find(categoryId);
            if(category != null)
            {
                return category.Id;
            }
            return 0;
        }

        public Dictionary<long, string> GetCategoryIdNameMap()
        {
            var list= _context.Categories.ToDictionary(c => c.Id, c => c.Name);
            return list!;
        }

        public string GetCategoryName(string categoryName)
        {
            var result=_context.Categories.Where(x=>x.Name== categoryName).FirstOrDefault();
            if(result == null)
            {
                throw new Exception("Category not found");
            }
            return result.Name!;
        }

        public Dictionary<string, long> GetCategoryNameIdMap()
        {
           var list= _context.Categories.Where(x=>x.Name !=null).ToDictionary(c => c.Name!, c => c.Id);
            return list!;
        }

        public bool IsCategoryExist(string categoryName)
        {
            var categoryexists=_context.Categories.Any(categoryexist => categoryexist.Name == categoryName);
            return categoryexists;
        }

        public bool IsCategoryIdExist(int categoryId)
        {
            var list= _context.Categories.Any(c => c.Id == categoryId); 
            return list;
        }

        public async Task<Category> Read(long Id)
        {
            var readbyid= await _context.Categories.FindAsync(Id);
            return readbyid!;
        }

        public async Task<List<Category>> ReadAllCategories()
        {
            var list= await _context.Categories.ToListAsync();
            return list;
        }

        public async Task<Category> Update(Category model)
        {
            var updatecategory= _context.Categories.Update(model);  
            if(updatecategory == null)
            {
                return null;
            }
            else
            {
                updatecategory.Entity.Name = model.Name;
            }
            await _context.SaveChangesAsync();
            return updatecategory.Entity;
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
