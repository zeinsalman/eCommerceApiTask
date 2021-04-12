using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceApi.Exceptions;
using eCommerceApi.Models;
using eCommerceApi.Repositories;
using eCommerceApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public List<ProductViewModel> Get()
        {
            var products = _productRepository.GetAll();
            var mappedProducts = _mapper.Map<List<Product>, List<ProductViewModel>>(products.ToList());
            return mappedProducts;
        }
        
        [HttpGet]
        [Route("~/api/products/GetProductById")]      
        public ProductViewModel GetProductById( int id)
        {
            var product = _productRepository.GetById(id);
            var mappedProduct = _mapper.Map<ProductViewModel>(product);
            return mappedProduct;

        }
        [HttpPost]
        public async Task<ProductViewModel> Post(PostOrPutProductViewModel postProductViewModel)
        {
            var product = await _productRepository.CreateOrUpdate(postProductViewModel);
            var mappedProduct = _mapper.Map<ProductViewModel>(product);
            return mappedProduct;
        }
        [HttpPut]
        public async Task<ProductViewModel> Put(PostOrPutProductViewModel postProductViewModel)
        {
            if(!postProductViewModel.Id.HasValue)
            {
                throw new BadRequestException("Id field is required");
            }
            var product = await _productRepository.CreateOrUpdate(postProductViewModel);
            var mappedProduct = _mapper.Map<ProductViewModel>(product);
            return mappedProduct;
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int id )
        {
           
            var result = await _productRepository.Delete(id);
            return new JsonResult(new { Result = result });

        }

    }
}