using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    public record AdminPanelInformationDto(
        int CommentRequestCount,
        int SalerPicturesRequestsCount,
        int CustomerPicturesRequestsCount,
        int ProductsRequestCount,
        int SaledProductCount,
        long SumWages,
        int ProductsCount,
        int SalersCount,
        int CustomersCount,
        int saledProductPesent,
        int sumWagesPersent,
        int Views,
        int Errors,
        int AllCommentsCount,
        int AllSellerPicCount,
        int AllCustomerPicCount,
        int AllActionCount,
        int AllBoothProductCount,
        int SellerTypeCount
        );
}
