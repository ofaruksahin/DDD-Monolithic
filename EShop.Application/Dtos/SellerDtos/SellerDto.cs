namespace EShop.Application.Dtos.SellerDtos
{
    public class SellerDto
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string SellerStatus
        {
            get;
            set;
        }

        public SellerDto(int id, string name, string sellerStatus)
        {
            Id = id;
            Name = name;
            SellerStatus = sellerStatus;
        }
    }
}

