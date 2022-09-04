using Application.Features.Languages.Dtos.Language.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Languages.Models;
public class LanguageListModel:BasePageableModel
{
        public IList<LanguageListDto>  Items { get; set; }
}
