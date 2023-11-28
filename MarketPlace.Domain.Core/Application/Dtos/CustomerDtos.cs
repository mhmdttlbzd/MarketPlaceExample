using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Customer
    public record CustomerOutputDto(
        int Id, ICollection<AuctionProposalOutputDto> ActionProposals, int AddressId, MainAddressOutputDto Address,
         ICollection<CommentOutputDto> Comments, ICollection<OrderOutputDto> Orders
        );
    public record CustomerInputDto( int id,int AddressId);

    public record GeneralCustomerDto
    {
        public int Id { get; set; }
        public string ProvinsName { get; set; }
        public string CityName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public UserStatus? Status { get; set; }
    }
    public record CustomerDto
    {
        public int Id { get; set; }
        public string ProvinsName { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public OrderDto ActiveOrder { get; set; }
        public List<OrderLineDto> BuyHistory { get; set; }
        public long Balance { get; set; }
    }


    public record GeneralCustomerInputDto
    {
        public int Id { get; set; }
        public int CityId { get; set; } = -1;
        public string AddressDescription { get; set ; }
        public int PostalCode { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Password { get; set; }
    }
	public record GeneralCustomerEditDto
	{
		public int Id { get; set; }
		public string? Email { get; set; }
		public string? Name { get; set; }
		public string? Family { get; set; }
        public MainAddressOutputDto Address { get; set; }
	}
	#endregion
}
