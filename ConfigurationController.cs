using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_BrackenJammer
{
    /// <summary>
    /// Configs for the mod
    /// </summary>
    internal class ConfigurationController
    {
        private ConfigEntry<double> JammingDistanceCfg;

        internal double JammingDistance
        {
            get
            {
                if(JammingDistanceCfg.Value == 0)
                {
                    return (double)JammingDistanceCfg.DefaultValue;
                }
                return JammingDistanceCfg.Value;
            }
            set => JammingDistanceCfg.Value = value;
        }

        public ConfigurationController(ConfigFile Config) 
        {
            JammingDistanceCfg = Config.Bind("LC_BrackenJammer Settings", "Jamming Distance", 70.0, "The minimum Distance for the jammer to run");
        }
    }
}
