﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FixedAssetSolutions.Startup))]
namespace FixedAssetSolutions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
