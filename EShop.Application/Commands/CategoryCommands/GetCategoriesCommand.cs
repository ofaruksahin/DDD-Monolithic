namespace EShop.Application.Commands.CategoryCommands
{
    public class GetCategoriesCommand : IRequest<BaseResponse<List<GetCategoriesCommandResponse>>>
    {

    }

    public class GetCategoriesCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public GetCategoriesCommandResponse(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
}

