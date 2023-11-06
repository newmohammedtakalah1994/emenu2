using emenu2.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace emenu2.Permissions;

public class emenu2PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(emenu2Permissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(emenu2Permissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<emenu2Resource>(name);
    }
}
