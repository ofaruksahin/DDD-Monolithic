namespace EShop.Application.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<BaseResponse<int>>
    {
        public string Name { get; set; }
    }
}

