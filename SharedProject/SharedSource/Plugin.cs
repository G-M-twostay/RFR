using Barotrauma;
using HarmonyLib;
using System.Runtime.CompilerServices;
[assembly: IgnoresAccessChecksTo("BarotraumaCore")]
[assembly: IgnoresAccessChecksTo("Barotrauma")]
[assembly: IgnoresAccessChecksTo("DedicatedServer")]
namespace RFR
{
    public partial class RFRMod : IAssemblyPlugin
    {
        internal static readonly ContentPackage CntPkg = ContentPackageManager.EnabledPackages.All.FirstOrDefault(static p => p.Name == "Reactor Fuel Rebalance");

        private static readonly Harmony harmony = new Harmony("RFR.Hooks");
        public void Initialize()
        {
            // When your plugin is loading, use this instead of the constructor
            // Put any code here that does not rely on other plugins.
            harmony.PatchAll();
        }

        public void OnLoadCompleted()
        {
            // After all plugins have loaded
            // Put code that interacts with other plugins here.
        }

        public void PreInitPatching()
        {
            // Not yet supported: Called during the Barotrauma startup phase before vanilla content is loaded.
        }

        public void Dispose()
        {
            // Cleanup your plugin!
            //throw new NotImplementedException();
        }
    }
}
