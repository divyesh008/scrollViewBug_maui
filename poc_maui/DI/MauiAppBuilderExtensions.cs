using System;
namespace poc_maui.DI
{
	public static class MauiAppBuilderExtensions
	{
        public static MauiAppBuilder ConfigureMobileUIAppBuilder(this MauiAppBuilder builder)
        {
  
#if IOS
            builder.UseMyPlugin();
#endif
            return builder;
        }
    }
}

