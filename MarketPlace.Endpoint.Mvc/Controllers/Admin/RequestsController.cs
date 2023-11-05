using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Endpoint.Mvc.Models.Picture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MarketPlace.Endpoint.Mvc.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class RequestsController : Controller
    {
        private readonly IRequestsAppService _RequestAppService;

        public RequestsController(IRequestsAppService requestAppService)
        {
            _RequestAppService = requestAppService;
        }


        //Product 
        [Route("/Admin/Requests/Products")]
        public async Task<IActionResult> Products(CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.GetProductRequests(cancellationToken);
            return View(res);
        }
        [HttpPatch]
        public async Task<IActionResult> ConfirmProduct(int id, CancellationToken cancellationToken)
        { 
            var res = await _RequestAppService.ConfirmProduct(id, cancellationToken); 
            if (res)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpPatch]
        public async Task<IActionResult> FaleProduct(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleProduct(id, cancellationToken);
            if (res)
            {
                return Ok();
            }
            return NoContent();
        }




        // Comment
        [Route("/Admin/Requests/Comments")]
        public async Task<IActionResult> Comments(CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.GetCommentRequests(cancellationToken);
            return View(res);
        }
        [HttpPatch]
        public async Task<IActionResult> ConfirmComment(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.ConfirmComment(id, cancellationToken);
            if (res)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpPatch]
        public async Task<IActionResult> FaleComment(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleComment(id, cancellationToken);
            if (res)
            {
                return Ok();
            }
            return NoContent();
        }


        // saler pictures
		[Route("/Admin/Requests/SalerPics")]
		public async Task<IActionResult> SalersPictures(CancellationToken cancellationToken)
		{
			var auctionPics = await _RequestAppService.GetAuctionPicRequests(cancellationToken);
			var boothPics = await _RequestAppService.GetSalerPicRequests(cancellationToken);
            var res = new SalerPictureRequestModel { Auction = auctionPics, InBooth = boothPics };
            return View(res);
		}
		[HttpPatch]
		public async Task<IActionResult> ConfirmAuctionPic(int id, CancellationToken cancellationToken)
		{
			var res = await _RequestAppService.ConfirmAuctionPic(id, cancellationToken);
			if (res)
			{
				return Ok();
			}
			return NoContent();
		}
		[HttpPatch]
		public async Task<IActionResult> FaleAuctionPic(int id, CancellationToken cancellationToken)
		{
			var res = await _RequestAppService.FaleAuctionPic(id, cancellationToken);
			if (res)
			{
				return Ok();
			}
			return NoContent();
		}
        [HttpPatch]
        public async Task<IActionResult> ConfirmSalerPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.ConfirmSalerPic(id, cancellationToken);
            if (res)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpPatch]
        public async Task<IActionResult> FaleSalerPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleSalerPic(id, cancellationToken);
            if (res)
            {
                return Ok();
            }
            return NoContent();
        }



        // Customer Pic
        [Route("/Admin/Requests/CustomerPics")]
        public async Task<IActionResult> CustomerPictures(CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.GetCustomerPicRequests(cancellationToken);
            return View("CustomerPictures", res);
        }
        [HttpPatch]
        public async Task<IActionResult> ConfirmCustomerPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.ConfirmCustomerPic(id, cancellationToken);
            if (res)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpPatch]
        public async Task<IActionResult> FaleCustomerPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleCustomerPic(id, cancellationToken);
            if (res)
            {
                return Ok();
            }
            return NoContent();
        }
    }
}
