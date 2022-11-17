using Do.Quest.Api.Models.Questionario;
using Do.Quest.Domain.Entities;
using Do.Quest.Domain.Enums;

namespace Do.Quest.Api.Mappers {
	public static class QuestionarioMapper {

      public static Questionario Map(QuestionarioViewModel questionarioViewModel) {
         if (questionarioViewModel == null) return default;

         return new Questionario(questionarioViewModel.Descricao,
                                 questionarioViewModel.DataInicio,
                                 questionarioViewModel.DataFim);
      }
   }
}
