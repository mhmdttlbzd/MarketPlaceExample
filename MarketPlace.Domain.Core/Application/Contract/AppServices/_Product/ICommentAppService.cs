using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Product
{
    public interface ICommentAppService
    {
        Task<CommentOutputDto> GetByIdAsync(string username, int id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(CommentInputDto input, int commentId, string editorUsername, CancellationToken cancellationToken);
        Task Create(string userName, byte satisfaction, int boothProductId, string description, CancellationToken cancellationToken);
    }
}
