using ArcheryManager.Entities;
using ArcheryManager.Pages;
using ArcheryManager.ViewModels;

namespace ArcheryManager.Factories
{
    public static class ResultPageFactory
    {
        public static ResultPage Create(CountedShoot shoot)
        {
            var page = new ResultPage();
            var vm = new ResultPageViewModel(shoot);
            page.BindingContext = vm;

            return page;
        }
    }
}
