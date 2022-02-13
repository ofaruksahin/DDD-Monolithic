using System;

namespace EShop.Application.Commands.CategoryCommands
{
    public class BaseCategoryCommand
    {
        protected ICategoryRepository _categoryRepository;

        public BaseCategoryCommand(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
    }
}

