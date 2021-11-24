using System.Collections.Generic;
using static WebApi.ViewModels.CupomViewModel;

namespace WebApi.ViewModels
{
    public class ParceiroListViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }

    public class ParceiroDetailsViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<CupomListViewModel> Cupons { get; set; }
    }

    public class ParceiroCreateViewModel
    {
        public string Nome { get; set; }
    }

    public class ParceiroEditViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
