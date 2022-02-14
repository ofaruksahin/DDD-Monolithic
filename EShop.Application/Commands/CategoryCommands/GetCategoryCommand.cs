namespace EShop.Application.Commands.CategoryCommands
{
    public class GetCategoryCommand : IRequest<BaseResponse<GetCategoryCommandResponse>>
    {
        public int Id { get; set; }

        public GetCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class GetCategoryCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    public class GetCategoryCommandHandler : BaseCategoryCommand, IRequestHandler<GetCategoryCommand, BaseResponse<GetCategoryCommandResponse>>
    {
        public GetCategoryCommandHandler(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }

        public async Task<BaseResponse<GetCategoryCommandResponse>> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {
            var exists = await _categoryRepository.GetCategoryById(request.Id);
            if (exists == null)
                return BaseResponse<GetCategoryCommandResponse>.Fail(new GetCategoryCommandResponse(), "Böyle bir kategori bulunamadı");
            return BaseResponse<GetCategoryCommandResponse>.Success(new GetCategoryCommandResponse
            {
                Id = exists.Id,
                Name = exists.Name,
                Status = exists.Status.Name
            });
        }
    }
}

