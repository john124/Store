﻿using Store.Model.Abstract.Service;
using Store.Model.Entities.dbml;
using System.Linq;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private const int PageSize = 2;

        #region ctor
        public ProductController(IProductService service) : base(service) { }
        #endregion

        public ActionResult List(int categoryId, int page = 1)
        {
            var list = ((IProductService)service).GetProductsByCategoryId(categoryId);

            PagingInfo pgInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = list.Count()
            };
            
            var model = list.Skip((page - 1) * PageSize).Take(PageSize);

            ViewData["PageInfo"] = pgInfo;
            return View(model);
        }
    }
}