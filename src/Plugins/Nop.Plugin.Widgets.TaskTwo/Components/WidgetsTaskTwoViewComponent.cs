using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.TaskTwo.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.TaskTwo.Components
{
    [ViewComponent(Name = "WidgetsTaskTwo")]
    public class WidgetsTaskTwoViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        public WidgetsTaskTwoViewComponent(IStoreContext storeContext,
            ISettingService settingService,
            IWebHelper webHelper)
        {
            _storeContext = storeContext;
            _settingService = settingService;
            _webHelper = webHelper;
        }

        public IViewComponentResult Invoke()
        {
            var taskTwoSettings = _settingService.LoadSetting<TaskTwoSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                Message = taskTwoSettings.Message
            };

            return View("~/Plugins/Widgets.TaskTwo/Views/PublicInfo.cshtml", model);
        }
    }
}
