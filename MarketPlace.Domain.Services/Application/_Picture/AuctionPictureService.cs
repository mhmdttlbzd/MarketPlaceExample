using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Picture
{
    public class AuctionPictureService : IAuctionPictureService
    {
        private readonly IAuctionPictureRepo _auctionPictureRepo;

        public AuctionPictureService(IAuctionPictureRepo auctionPictureRepo)
        {
            _auctionPictureRepo = auctionPictureRepo;
        }
        public int GetCount() => _auctionPictureRepo.GetCount();
        public async Task<int> CreateAsync(AuctionPictureInputDto input, CancellationToken cancellationToken)
            => await _auctionPictureRepo.CreateAsync(input, cancellationToken);


        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
            =>await _auctionPictureRepo.DeleteAsync(id, cancellationToken);

        public async Task<List<AuctionPictureOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        => await _auctionPictureRepo.GetAllAsync(cancellationToken);

        public async Task<AuctionPictureOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await _auctionPictureRepo.GetByIdAsync(id, cancellationToken);


        public async Task UpdateAsync(AuctionPictureInputDto input, int id, CancellationToken cancellationToken)
        =>await _auctionPictureRepo.UpdateAsync(input, id, cancellationToken);


        public int GetRequestsCount() => _auctionPictureRepo.GetRequestsCount();
		public async Task<List<AuctionPicRequestDto>> GetRequests(CancellationToken cancellationToken)
=> await _auctionPictureRepo.GetRequests(cancellationToken);

		public async Task ConfirmAsync(int id, CancellationToken cancellationToken) => await _auctionPictureRepo.ConfirmAsync(id, cancellationToken);
		public async Task FaleAsync(int id, CancellationToken cancellationToken) => await _auctionPictureRepo.FaleAsync(id, cancellationToken);

	}

}
