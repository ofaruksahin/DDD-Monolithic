using System;

namespace EShop.Application.Commands.SellerCommands
{
    public class DeleteSellerCommandHandler : BaseSellerCommand, IRequestHandler<DeleteSellerCommand, BaseResponse<NoContent>>
    {
        public DeleteSellerCommandHandler(ISellerRepository sellerRepository) : base(sellerRepository)
        {
        }

        public async Task<BaseResponse<NoContent>> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetSeller(request.Id);
            if (seller == null)
                return BaseResponse<NoContent>.Fail(new NoContent(), "Böyle bir satıcı bulunamadı");
            seller.SetStatusChangedToPassive();
            _sellerRepository.Update(seller);
            var result = await _sellerRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<NoContent>.Fail(new NoContent(), "Satıcı silinemedi");
            return BaseResponse<NoContent>.Success(new NoContent());
        }
    }
}

