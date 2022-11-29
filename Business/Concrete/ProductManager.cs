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
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new SuccessResult(product.ProductName + Message.Added);
            }
            catch (Exception)
            {

                return new ErrorResult(Message.Error);
            }
        }

        public IResult Delete(Product product)
        {
           
            try
            {
                _productDal.Delete(product);
                return new SuccessResult(product.ProductName + Message.Deleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Message.Error);
            }
        }

        public IDataResult<Product> GetById(int productId)
        {
            try
            {
                return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
            }
        }

        public IDataResult<List<Product>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Product>>(_productDal.GetList().ToList());
            }     
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            
            try
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList());
            }
        }

        public IResult Update(Product product)
        {
            try
            {
                _productDal.Update(product);
                return new SuccessResult(product.ProductName + Message.Updated);
            }
            catch (Exception)
            {

                return new ErrorResult(Message.Error);
            }
        }
    }
}
