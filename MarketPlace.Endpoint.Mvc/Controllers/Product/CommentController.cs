using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Controllers.Product
{
    public class CommentController : Controller
    {
        private readonly ICommentAppService _commentAppService;

        public CommentController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id , CancellationToken cancellationToken)
        {
            var comment =await _commentAppService.GetByIdAsync(User.Identity.Name,id , cancellationToken);
            return View("EditComment", comment);
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(string description , byte satisfaction,int id, CancellationToken cancellationToken)
        {
            await _commentAppService.UpdateAsync(new CommentInputDto { Description = description, Satisfaction = satisfaction }, id, User.Identity.Name, cancellationToken);
            return LocalRedirect("~/Comment/Edit/" + id);
        }


    }
}
