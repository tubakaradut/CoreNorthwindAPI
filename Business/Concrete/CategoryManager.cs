using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            try
            {
                _categoryDal.Add(category);
                return new SuccessResult(category.CategoryName + Message.Added);
            }
            catch (Exception)
            {

                return new ErrorResult(Message.Error);
            }
        }

        public IResult Delete(Category category)
        {
            try
            {
                _categoryDal.Delete(category);
                return new SuccessResult(category.CategoryName + Message.Deleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Message.Error);
            }
        }

        public IDataResult<Category> Get(int categoryId)
        {
          
            try
            {
                return new SuccessDataResult<Category>(_categoryDal.Get(x => x.CategoryId == categoryId));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Category>(_categoryDal.Get(x => x.CategoryId == categoryId));
            }
        }

        public IDataResult<List<Category>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Category>>(_categoryDal.GetList().ToList());
            }
        }

        public IResult Update(Category category)
        {
            try
            {
                _categoryDal.Update(category);
                return new SuccessResult(category.CategoryName+Message.Updated);
            }
            catch (Exception)
            {

                return new ErrorResult(Message.Error);
            }
        }
    }
}
