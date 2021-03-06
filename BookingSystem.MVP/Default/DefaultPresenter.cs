﻿using BookingSystem.Services.Contracts;
using Bytes2you.Validation;
using WebFormsMvp;

namespace BookingSystem.MVP.Default
{
    public class DefaultPresenter : Presenter<IDefaultView>
    {
        private readonly ICategoryService categoryService;

        public DefaultPresenter(IDefaultView view, ICategoryService categoryService) 
            : base(view)
        {
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();
            this.categoryService = categoryService;

            this.View.OnCategoriesGetData += this.View_OnCategoriesGetData; ;
        }

        private void View_OnCategoriesGetData(object sender, System.EventArgs e)
        {
            this.View.Model.DefaultCategories = this.categoryService.GetAllCategories();
        }
    }
}