using emenu2.Localization;
using System.Text.RegularExpressions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace emenu2.Permissions;

public class emenu2PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
      //  var emenuGroub = context.AddGroup(emenu2Permissions.GroupName);

        var productGroup = context.AddGroup("ProductStore");

        var productPermession = productGroup.AddPermission("Product_Management");

        productPermession.AddChild("ProductStore_Create_Product");
        productPermession.AddChild("ProductStore_Edit_Product");
        productPermession.AddChild("ProductStore_Delete_Product");
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<emenu2Resource>(name);
    }
}
