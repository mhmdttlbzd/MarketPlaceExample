using MarketPlace.Domain.AppServices.AppLication._Admin;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Endpoint.Mvc.Models.Picture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MarketPlace.Endpoint.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RequestsController : Controller
    {
        private readonly IRequestsAppService _RequestAppService;

        public RequestsController(IRequestsAppService requestAppService)
        {
            _RequestAppService = requestAppService;
        }


        //Product 
        public async Task<IActionResult> Products(CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.GetProductRequests(cancellationToken);
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmProduct(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.ConfirmProduct(id, cancellationToken);
            return RedirectToAction("Products");
        }
        [HttpGet]
        public async Task<IActionResult> FaleProduct(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleProduct(id, cancellationToken);
            return RedirectToAction("Products");
        }




        // Comment
        public async Task<IActionResult> Comments(CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.GetCommentRequests(cancellationToken);
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmComment(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.ConfirmComment(id, cancellationToken);
            return RedirectToAction("Comments");
        }
        [HttpGet]
        public async Task<IActionResult> FaleComment(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleComment(id, cancellationToken);
            return RedirectToAction("Comments");

        }


        // saler pictures
        public async Task<IActionResult> SalersPictures(CancellationToken cancellationToken)
        {
            var auctionPics = await _RequestAppService.GetAuctionPicRequests(cancellationToken);
            var boothPics = await _RequestAppService.GetSalerPicRequests(cancellationToken);
            var res = new SalerPictureRequestModel { Auction = auctionPics, InBooth = boothPics };
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmAuctionPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.ConfirmAuctionPic(id, cancellationToken);
            return RedirectToAction("SalersPictures");

        }
        [HttpGet]
        public async Task<IActionResult> FaleAuctionPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleAuctionPic(id, cancellationToken);
            return RedirectToAction("SalersPictures");

        }
        [HttpGet]
        public async Task<IActionResult> ConfirmSalerPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.ConfirmSalerPic(id, cancellationToken);
            return RedirectToAction("SalersPictures");

        }
        [HttpGet]
        public async Task<IActionResult> FaleSalerPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleSalerPic(id, cancellationToken);
            return RedirectToAction("SalersPictures");

        }



        // Customer Pic
        public async Task<IActionResult> CustomerPictures(CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.GetCustomerPicRequests(cancellationToken);
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmCustomerPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.ConfirmCustomerPic(id, cancellationToken);
            return RedirectToAction("CustomerPictures");

        }
        [HttpGet]
        public async Task<IActionResult> FaleCustomerPic(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleCustomerPic(id, cancellationToken);
            return RedirectToAction("CustomerPictures");

        }
    }
}
