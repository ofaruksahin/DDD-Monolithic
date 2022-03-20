namespace EShop.Application.Commands.BasketCommands
{
    public class CreateBasketItemCommand : CreateBasketDto, IRequest<BaseResponse<int>>
    {

    }

    public class CreateBasketItemCommandHandler : BaseBasketCommand, IRequestHandler<CreateBasketItemCommand, BaseResponse<int>>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        public CreateBasketItemCommandHandler(
            IBasketRepository basketRepository,
            ISellerRepository sellerRepository,
            IProductRepository productRepository,
            ICustomerRepository customerRepository)
            : base(basketRepository)
        {
            _sellerRepository = sellerRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse<int>> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            if (customer == null)
                return BaseResponse<int>.Fail(0, "Böyle bir müşteri bulunamadı");
            var basket = await _basketRepository.GetBasketByCustomerId(request.CustomerId);
            if (basket == null)
            {
                basket = Basket.CreateBasket(request.CustomerId);
            }

            List<Seller> sellers = new List<Seller>();
            List<Product> products = new List<Product>();
            foreach (var basketItemDto in request.BasketItems)
            {
                Seller seller = sellers.FirstOrDefault(f => f.Id == basketItemDto.SellerId);
                if (seller == null)
                {
                    seller = await _sellerRepository.GetSeller(basketItemDto.SellerId);
                    if (seller != null)
                        sellers.Add(seller);
                }
                if (seller == null)
                {
                    return BaseResponse<int>.Fail(0, "Satıcı Bulunamadı");
                }
                if (seller != null && !products.Any(f => f.SellerId == seller.Id))
                    products.AddRange(await _productRepository.GetProductsBySeller(seller.Id));

                if (products.Any(f => f.SellerId == basketItemDto.SellerId && f.Id == basketItemDto.ProductId))
                {
                    var product = products.FirstOrDefault(f => f.SellerId == basketItemDto.SellerId && f.Id == basketItemDto.ProductId);
                    if (product == null)
                    {
                        return BaseResponse<int>.Fail(0, "Böyle bir ürün bulunamadı");
                    }
                    else
                    {
                        var basketItem = BasketItem.Create(seller.Id, seller.Name, product.Id, product.Name, basketItemDto.Count, product.Price, product.Price * 0.18, product.Price * 1.18);
                        basket.AddBasketItem(basketItem);
                    }
                }
            }

            if (basket.Id == 0)
                _basketRepository.Add(basket);
            else
            {
                _basketRepository.Update(basket);
            }

            var result = await _basketRepository.UnitOfWork.SaveEntitiesAsync();
            if (!result)
                return BaseResponse<int>.Fail(0, "Sepet tanımlanamadı!");
            return BaseResponse<int>.Success(basket.Id);
        }
    }
}

