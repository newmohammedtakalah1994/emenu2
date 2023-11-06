using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace emenu2;

[Dependency(ReplaceServices = true)]
public class emenu2BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "emenu2";
}
