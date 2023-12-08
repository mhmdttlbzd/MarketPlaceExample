using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices.AppLication._Product
{
    public class CommentAppService : ICommentAppService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly ICommentService _commentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentAppService(IUnitOfWorks unitOfWorks, ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            _unitOfWorks = unitOfWorks;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<bool> UpdateAsync(CommentInputDto input,int commentId,string editorUsername , CancellationToken cancellationToken)
        {
            if (await _userManager.IsInRoleAsync(await _userManager.FindByNameAsync(editorUsername), "Admin"))
            {
                await _commentService.UpdateAsync(input, commentId, cancellationToken);
                var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
                if (res != null && res > 0) { return true; }
            }
            return false;
        }
        public async Task<CommentOutputDto> GetByIdAsync(string username , int id, CancellationToken cancellationToken)
        {
            if (await _userManager.IsInRoleAsync(await _userManager.FindByNameAsync(username), "Admin"))
            {
                return await _commentService.GetByIdAsync(id,cancellationToken);
            }
            return null;
        }

        public async Task Create(string userName,byte satisfaction,int boothProductId,string description,CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(userName);
            await _commentService.CreateAsync(new CommentInputDto
            {
                BoothProductId = boothProductId,
                CustomerId = user.Id,
                Description = description,
                Satisfaction = satisfaction
                
            }, cancellationToken);
            await _unitOfWorks.SaveChangesAsync(cancellationToken);
        }
    }
}
