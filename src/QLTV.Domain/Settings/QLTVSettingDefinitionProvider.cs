using Volo.Abp.Settings;

namespace QLTV.Settings
{
    public class QLTVSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(QLTVSettings.MySetting1));
        }
    }
}
