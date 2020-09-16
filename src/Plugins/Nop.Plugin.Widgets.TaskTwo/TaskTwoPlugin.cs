using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.TaskTwo
{
    public class TaskTwo : BasePlugin, IWidgetPlugin
    {

        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;

        public TaskTwo(ILocalizationService localizationService,
            ISettingService settingService, IWebHelper webHelper)
        {
            _localizationService = localizationService;
            _settingService = settingService;
            _webHelper = webHelper;
        }

        public bool HideInWidgetList => false;

        public override void Install()
        {
            //Settings
            var settings = new TaskTwoSettings
            {
                Message = "50% Discount on delivery for orders before Decemder 1st"
            };
            _settingService.SaveSetting(settings);

            //Localization
            _localizationService.AddLocaleResource(new Dictionary<string, string>
            {
                ["Plugins.Widgets.TaskTwo.Message"] = "Message",
            });

            base.Install();
        }

        public override void Uninstall()
        {
            //Settings
            _settingService.DeleteSetting<TaskTwoSettings>();

            //Localization
            _localizationService.DeleteLocaleResources("Plugin.Widgets.TaskTwo");

            base.Uninstall();
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsTaskTwo";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.ProductDetailsOverviewTop };
        }

        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsTaskTwo/Configure";
        }
    }
}
