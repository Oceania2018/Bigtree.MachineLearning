﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Bigtree.Algorithm.UnitTest
{
    public abstract class TestEssential
    {
        protected IConfigurationSection Configuration { get; }

        public TestEssential()
        {
            var rootDir = Path.GetFullPath($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}");
            var settingsDir = Path.Combine(rootDir, "Settings");

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            var settings = Directory.GetFiles(settingsDir, "*.json");
            settings.ToList().ForEach(setting =>
            {
                configurationBuilder.AddJsonFile(setting, optional: false, reloadOnChange: true);
            });
            Configuration = configurationBuilder.Build().GetSection("Bigtree.Algorithm");
        }
    }


}
