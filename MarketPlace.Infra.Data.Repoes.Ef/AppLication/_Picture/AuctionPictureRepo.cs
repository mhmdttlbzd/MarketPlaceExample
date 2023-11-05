using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Picture
{
	public class AuctionPictureRepo : BaseEntityCrudRepository<AuctionPicture,
AuctionPictureInputDto, AuctionPictureOutputDto>, IAuctionPictureRepo
	{
		public AuctionPictureRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
		{

		}
		public int GetRequestsCount()
			=> _dbContext.Set<AuctionPicture>().Where(c => c.Status == GeneralStatus.AwaitConfirmation).Count();

		public async Task<List<AuctionPicRequestDto>> GetRequests(CancellationToken cancellationToken)
		{

			var pictures = await _dbContext.Set<AuctionPicture>().Where(p => p.Status == GeneralStatus.AwaitConfirmation)
				.Select(p => new AuctionPicRequestDto
				{
					Id = p.Id,
					Path = p.Picture.Path,
					ProductName = p.Auction.Product.Name
				})
				.AsNoTracking().ToListAsync(cancellationToken);
			return pictures;
		}
		public async Task ConfirmAsync(int id, CancellationToken cancellationToken)
		{
			var product = await _dbContext.Set<AuctionPicture>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
			product.Status = GeneralStatus.Confirmed;
		}
		public async Task FaleAsync(int id, CancellationToken cancellationToken)
		{
			var product = await _dbContext.Set<AuctionPicture>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
			product.Status = GeneralStatus.Failed;
		}
	}
}
