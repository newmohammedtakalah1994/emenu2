using emenu2.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace emenu2.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class emenu2Controller : AbpControllerBase
{
    protected emenu2Controller()
    {
        LocalizationResource = typeof(emenu2Resource);
    }
}
