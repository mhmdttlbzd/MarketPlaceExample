using MarketPlace.Domain.Core.Application.Entities._Order;
using MarketPlace.Domain.Core.Application.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Db.SqlServer.Ef.SeedData
{
	public class OrderSeedData : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasData(
				new Order { Id = 1, CustomerId = 2, Status = OrderStatus.Bought, BuyedAt = DateTime.Now },
				new Order { Id = 2, CustomerId = 2, Status = OrderStatus.Bought, BuyedAt = DateTime.Now },
				new Order { Id = 3, CustomerId = 2, Status = OrderStatus.Bought, BuyedAt = DateTime.Now },
				new Order { Id = 4, CustomerId = 2, Status = OrderStatus.Bought, BuyedAt = DateTime.Now },
				new Order { Id = 5, CustomerId = 3, Status = OrderStatus.Bought, BuyedAt = DateTime.Now }
				);
		}
	}
	public class OrderLineSeedData : IEntityTypeConfiguration<OrderLine>
	{
		public void Configure(EntityTypeBuilder<OrderLine> builder)
		{
			builder.HasData(
				new OrderLine { Id = 1, BoothProductId =14, Quantity = 10, OrderId=1},
				new OrderLine { Id = 2, BoothProductId =12, Quantity = 1, OrderId=2},
				new OrderLine { Id = 3, BoothProductId = 14, Quantity = 1, OrderId = 3 },
				new OrderLine { Id = 4, BoothProductId = 15, Quantity = 2, OrderId = 4 },
				new OrderLine { Id = 5, BoothProductId = 1, Quantity = 1, OrderId = 4 },
				new OrderLine { Id = 6, BoothProductId = 15, Quantity = 2, OrderId = 5 },
				new OrderLine { Id = 7, BoothProductId = 1, Quantity = 1, OrderId = 5 }

				);
		}
	}
}
