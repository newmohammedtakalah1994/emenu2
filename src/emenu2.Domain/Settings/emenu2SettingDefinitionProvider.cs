using Volo.Abp.Settings;

namespace emenu2.Settings;

public class emenu2SettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(emenu2Settings.MySetting1));
    }
}
