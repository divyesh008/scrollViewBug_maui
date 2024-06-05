using System;
using HomeKit;
using poc_maui.Controls;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ConfigHandlers
	{
        public static MauiAppBuilder UseMyPlugin(this MauiAppBuilder builder)
        {
            return builder;
        }
    }
}

