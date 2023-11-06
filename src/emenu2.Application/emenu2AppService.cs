using System;
using System.Collections.Generic;
using System.Text;
using emenu2.Localization;
using Volo.Abp.Application.Services;

namespace emenu2;

/* Inherit your application services from this class.
 */
public abstract class emenu2AppService : ApplicationService
{
    protected emenu2AppService()
    {
        LocalizationResource = typeof(emenu2Resource);
    }
}
