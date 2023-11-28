using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Seller
    public record SellerOutputDto(
        int Id, int SellerTypeId, BoothOutputDto? Booth, SellerTypeDto SellerType
        );
    public record SellerInputDto( int Id, int SellerTypeId=1 );

    public record GeneralSellerDto
    {
        public int Id { get; set; }
        public string SellerTypeName { get; set; }
        public string ProvinsName { get; set; }
        public string BoothName { get; set; }
        public string CityName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public UserStatus? Status { get; set; }
    }


    public record GeneralSellerInputDto
    {
        public int Id { get; set; }
        public int CityId { get; set; } = -1;
        public string AddressDescription { get; set; }
        public int PostalCode { get; set; }
        public string BoothName { get; set; }
        public int SellerTypeId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Password { get; set; }
    }

	public record GeneralSellerEditDto
	{
		public int Id { get; set; }
		public string? Email { get; set; }
		public string? Name { get; set; }
		public string? Family { get; set; }
        public string? BoothName { get; set; }
       public MainAddressOutputDto Address { get; set; }
	}
	#endregion

	#region SellerType
	public record SellerTypeDto(int Id, string Title, byte WagePercent, long BaseSalesMoney);
    #endregion
}
