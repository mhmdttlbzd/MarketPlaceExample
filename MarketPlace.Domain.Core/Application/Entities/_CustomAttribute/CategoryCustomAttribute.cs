using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Entities._CustomAttribute
{
    public class CategoryCustomAttribute
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CustomAttributeTemplateId { get; set; }
        public Category Category { get; set; } = null!;
        public CustomAttributeTemplate CustomAttributeTemplate { get; set; } = null!;
    }
}
