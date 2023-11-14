using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Saler
    public record SalerOutputDto(
        int Id, int SalerTypeId, BoothOutputDto? Booth, SalerTypeDto SalerTipe
        );
    public record SalerInputDto( int Id, int SalerTypeId=1 );

    public record GeneralSalerDto
    {
        public int Id { get; set; }
        public string SalerTypeName { get; set; }
        public string ProvinsName { get; set; }
        public string BoothName { get; set; }
        public string CityName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public UserStatus? Status { get; set; }
    }


    public record GeneralSalerInputDto
    {
        public int Id { get; set; }
        public int CityId { get; set; } = -1;
        public string AddressDescription { get; set; }
        public int PostalCode { get; set; }
        public string BoothName { get; set; }
        public int SalerTypeId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Password { get; set; }
    }

	public record GeneralSalerEditDto
	{
		public int Id { get; set; }
		public string? Email { get; set; }
		public string? Name { get; set; }
		public string? Family { get; set; }
        public string? BoothName { get; set; }
       public MainAddressOutputDto Address { get; set; }
	}
	#endregion

	#region SalerType
	public record SalerTypeDto(int Id, string Title, byte TaskPercent, ICollection<SalerOutputDto> Salers);
    #endregion
}
