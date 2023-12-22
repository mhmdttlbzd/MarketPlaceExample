using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CommentController : Controller
    {
        private readonly ICommentAppService _commentAppService;
        private readonly IRequestsAppService _RequestAppService;

        public CommentController(ICommentAppService commentAppService, IRequestsAppService requestAppService)
        {
            _commentAppService = commentAppService;
            _RequestAppService = requestAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var comment = await _commentAppService.GetByIdAsync(User.Identity.Name, id, cancellationToken);
            return View("EditComment", comment);
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(string description, byte satisfaction, int id, CancellationToken cancellationToken)
        {
            await _commentAppService.UpdateAsync(new CommentInputDto { Description = description, Satisfaction = satisfaction }, id, User.Identity.Name, cancellationToken);
            return LocalRedirect("~/Admin/Comment/Edit?id=" + id);
        }

        [HttpGet] 
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var res = await _commentAppService.GetAll(cancellationToken);
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> Confirm(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.ConfirmComment(id, cancellationToken);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public async Task<IActionResult> Fale(int id, CancellationToken cancellationToken)
        {
            var res = await _RequestAppService.FaleComment(id, cancellationToken);
            return RedirectToAction("GetAll");

        }
    }
}
