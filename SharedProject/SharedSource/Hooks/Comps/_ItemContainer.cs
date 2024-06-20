using Barotrauma;
using Barotrauma.Items.Components;
using HarmonyLib;
namespace RFR.Hooks
{
    [HarmonyPatch(typeof(ItemContainer))]
    static class _ItemContainer
    {
        [HarmonyPrefix]
        [HarmonyPatch(MethodType.Constructor, new Type[] { typeof(Item), typeof(ContentXElement) })]
        public static void PreCtor(Item item, ContentXElement element)
        {
            if (item.HasTag("reactor") && item.Prefab.Identifier.Contains("reactor") && (item.Prefab.Category & MapEntityCategory.Machine) == MapEntityCategory.Machine)
            {
                foreach (var cEle in element.Elements())
                    if (cEle.NameAsIdentifier() == "containable")
                    {
                        var a = (new RelatedItem(cEle, null)).Identifiers;
                        if (a.Contains("fuelrod"))
                        {
                            foreach (var seEle in cEle.Elements())
                                foreach (var attr in seEle.Attributes())
                                    if (attr.NameAsIdentifier() == "AvailableFuel")
                                        attr.SetValue("25.0");
                        }
                        else if (a.Contains("fulguriumfuelrod"))
                        {
                            foreach (var seEle in cEle.Elements())
                                foreach (var attr in seEle.Attributes())
                                    if (attr.NameAsIdentifier() == "AvailableFuel")
                                        attr.SetValue("50.0");
                        }
                        else if (a.Contains("thoriumfuelrod"))
                        {
                            foreach (var seEle in cEle.Elements())
                                foreach (var attr in seEle.Attributes())
                                    if (attr.NameAsIdentifier() == "AvailableFuel")
                                        attr.SetValue("30.0");
                        }
                        else if (a.Contains("fulguriumfuelrodvolatile"))
                        {
                            foreach (var seEle in cEle.Elements())
                                foreach (var attr in seEle.Attributes())
                                    if (attr.NameAsIdentifier() == "AvailableFuel")
                                        attr.SetValue("100.0");
                        }
                    }
            }
            else if (item.Prefab.Identifier == "fulguriumfuelrodvolatile")
            {
                element.SetAttributeValue("health", "100");
            }
        }
    }
}