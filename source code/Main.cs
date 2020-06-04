using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace MCCAdvancedVideoSettings
{
    public partial class Main : Form
    {
        private FileInfo file;

        public Main()
        {
            InitializeComponent();

            Shown += (s, e) =>
            {
                if (!GetSystemSettingsData(out file))
                {
                    MessageBox.Show("MCC settings file not found. You must run the game at least once\n\nThis may also be an access issue. If this issue persists, try running as administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                ReadSystemSettingsData();
            };

            SaveButton.Click += (s, e) =>
            {
                WriteSystemSettingsData();
                MessageBox.Show("Changes have been applied\n\nIf the game is running, it must be restarted for changes to take affect.\n\nChanging video settings in-game will revert any manual changes you have made", "Saved settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            ReloadButton.Click += (s, e) =>
            {
                ReadSystemSettingsData();
            };

            GitHubButton.Click += (s, e) =>
            {
                System.Diagnostics.Process.Start("https://github.com/343RuinedHalo/MCC-Advanced-Video-Settings");
            };

        }

        private GenericPropertyPage CopyToGenericPropertyPage(SystemSettingsData.GenericGameData data)
        {
            var result = new GenericPropertyPage();
            result.CPUDynamicLightMaxCountOffset = data.RenderSettings.CPUDynamicLightMaxCount.Offset;
            result.CPUDynamicLightMaxCountScale = data.RenderSettings.CPUDynamicLightMaxCount.Scale;

            result.CPUDynamicLightScaleOffset = data.RenderSettings.CPUDynamicLightScale.Offset;
            result.CPUDynamicLightScaleScale = data.RenderSettings.CPUDynamicLightScale.Scale;

            result.DecalFadeDistanceScaleOffset = data.RenderSettings.DecalFadeDistanceScale.Offset;
            result.DecalFadeDistanceScaleScale = data.RenderSettings.DecalFadeDistanceScale.Scale;

            result.DecoratorFadeDistanceOffset = data.RenderSettings.DecoratorFadeDistance.Offset;
            result.DecoratorFadeDistanceScale = data.RenderSettings.DecoratorFadeDistance.Scale;

            result.EffectsLODDistanceScaleOffset = data.RenderSettings.EffectsLODDistanceScale.Offset;
            result.EffectsLODDistanceScaleScale = data.RenderSettings.EffectsLODDistanceScale.Scale;

            result.FPSLock = data.GeneralVideoSettings.FPSLock;

            result.GPUDynamicLightMaxCountOffset = data.RenderSettings.GPUDynamicLightMaxCount.Offset;
            result.GPUDynamicLightMaxCountScale = data.RenderSettings.GPUDynamicLightMaxCount.Scale;

            result.GPUDynamicLightScaleOffset = data.RenderSettings.GPUDynamicLightScale.Offset;
            result.GPUDynamicLightScaleScale = data.RenderSettings.GPUDynamicLightScale.Scale;

            result.InstanceFadeModifierOffset = data.RenderSettings.InstanceFadeModifier.Offset;
            result.InstanceFadeModifierScale = data.RenderSettings.InstanceFadeModifier.Scale;

            result.ObjectDetailModiferOffset = data.RenderSettings.ObjectDetailModifer.Offset;
            result.ObjectDetailModiferScale = data.RenderSettings.ObjectDetailModifer.Scale;

            result.ObjectFadeModiferOffset = data.RenderSettings.ObjectFadeModifer.Offset;
            result.ObjectFadeModiferScale = data.RenderSettings.ObjectFadeModifer.Scale;

            result.ObjectImposterCutoffModiferOffset = data.RenderSettings.ObjectImposterCutoffModifer.Offset;
            result.ObjectImposterCutoffModiferScale = data.RenderSettings.ObjectImposterCutoffModifer.Scale;

            result.ScreenspaceDynamicLightMaxCountOffset = data.RenderSettings.ScreenspaceDynamicLightMaxCount.Offset;
            result.ScreenspaceDynamicLightMaxCountScale = data.RenderSettings.ScreenspaceDynamicLightMaxCount.Scale;

            result.ScreenspaceDynamicLightScaleOffset = data.RenderSettings.ScreenspaceDynamicLightScale.Offset;
            result.ScreenspaceDynamicLightScaleScale = data.RenderSettings.ScreenspaceDynamicLightScale.Scale;

            result.ShadowQualityLODOffset = data.RenderSettings.ShadowQualityLOD.Offset;
            result.ShadowQualityLODScale = data.RenderSettings.ShadowQualityLOD.Scale;

            result.StructureInstanceLODModiferOffset = data.RenderSettings.StructureInstanceLODModifer.Offset;
            result.StructureInstanceLODModiferScale = data.RenderSettings.StructureInstanceLODModifer.Scale;

            result.VSync = data.GeneralVideoSettings.VSync;

            result.WaterLodOffset = data.RenderSettings.WaterLod.Offset;
            result.WaterLodScale = data.RenderSettings.WaterLod.Scale;

            return result;
        }

        private ReachPropertyPage CopyToReachPropertyPage(SystemSettingsData.ReachGameData data)
        {
            var result = new ReachPropertyPage();
            result.CPUDynamicLightMaxCountOffset = data.RenderSettings.CPUDynamicLightMaxCount.Offset;
            result.CPUDynamicLightMaxCountScale = data.RenderSettings.CPUDynamicLightMaxCount.Scale;

            result.CPUDynamicLightScaleOffset = data.RenderSettings.CPUDynamicLightScale.Offset;
            result.CPUDynamicLightScaleScale = data.RenderSettings.CPUDynamicLightScale.Scale;

            result.DecalFadeDistanceScaleOffset = data.RenderSettings.DecalFadeDistanceScale.Offset;
            result.DecalFadeDistanceScaleScale = data.RenderSettings.DecalFadeDistanceScale.Scale;

            result.DecoratorFadeDistanceOffset = data.RenderSettings.DecoratorFadeDistance.Offset;
            result.DecoratorFadeDistanceScale = data.RenderSettings.DecoratorFadeDistance.Scale;

            result.DisableCheapParticles = data.RenderSettings.DisableCheapParticles;

            result.DisableDynamicLightingShadows = data.RenderSettings.DisableDynamicLightingShadows;

            result.DisableFirstPersonShadow = data.RenderSettings.DisableFirstPersonShadow;

            result.DisablePatchyFog = data.RenderSettings.DisablePatchyFog;

            result.EffectsLODDistanceScaleOffset = data.RenderSettings.EffectsLODDistanceScale.Offset;
            result.EffectsLODDistanceScaleScale = data.RenderSettings.EffectsLODDistanceScale.Scale;

            result.FPSLock = data.GeneralVideoSettings.FPSLock;

            result.GPUDynamicLightMaxCountOffset = data.RenderSettings.GPUDynamicLightMaxCount.Offset;
            result.GPUDynamicLightMaxCountScale = data.RenderSettings.GPUDynamicLightMaxCount.Scale;

            result.GPUDynamicLightScaleOffset = data.RenderSettings.GPUDynamicLightScale.Offset;
            result.GPUDynamicLightScaleScale = data.RenderSettings.GPUDynamicLightScale.Scale;

            result.InstanceFadeModifierOffset = data.RenderSettings.InstanceFadeModifier.Offset;
            result.InstanceFadeModifierScale = data.RenderSettings.InstanceFadeModifier.Scale;

            result.ObjectDetailModiferOffset = data.RenderSettings.ObjectDetailModifer.Offset;
            result.ObjectDetailModiferScale = data.RenderSettings.ObjectDetailModifer.Scale;

            result.ObjectFadeModiferOffset = data.RenderSettings.ObjectFadeModifer.Offset;
            result.ObjectFadeModiferScale = data.RenderSettings.ObjectFadeModifer.Scale;

            result.ObjectImposterCutoffModiferOffset = data.RenderSettings.ObjectImposterCutoffModifer.Offset;
            result.ObjectImposterCutoffModiferScale = data.RenderSettings.ObjectImposterCutoffModifer.Scale;

            result.ScreenspaceDynamicLightMaxCountOffset = data.RenderSettings.ScreenspaceDynamicLightMaxCount.Offset;
            result.ScreenspaceDynamicLightMaxCountScale = data.RenderSettings.ScreenspaceDynamicLightMaxCount.Scale;

            result.ScreenspaceDynamicLightScaleOffset = data.RenderSettings.ScreenspaceDynamicLightScale.Offset;
            result.ScreenspaceDynamicLightScaleScale = data.RenderSettings.ScreenspaceDynamicLightScale.Scale;

            result.ShadowQualityLODOffset = data.RenderSettings.ShadowQualityLOD.Offset;
            result.ShadowQualityLODScale = data.RenderSettings.ShadowQualityLOD.Scale;

            result.StructureInstanceLODModiferOffset = data.RenderSettings.StructureInstanceLODModifer.Offset;
            result.StructureInstanceLODModiferScale = data.RenderSettings.StructureInstanceLODModifer.Scale;

            result.VSync = data.GeneralVideoSettings.VSync;

            result.WaterLodOffset = data.RenderSettings.WaterLod.Offset;
            result.WaterLodScale = data.RenderSettings.WaterLod.Scale;

            return result;
        }

        private SystemSettingsData.GenericGameData CopyFromGenericPropertyPage(GenericPropertyPage page)
        {
            var data = new SystemSettingsData.GenericGameData();
            data.GeneralVideoSettings = new SystemSettingsData.GeneralVideoSettings();
            data.RenderSettings = new SystemSettingsData.GenericRenderSettings();
            data.RenderSettings.CPUDynamicLightMaxCount = new SystemSettingsData.CPUDynamicLightMaxCount();
            data.RenderSettings.CPUDynamicLightScale = new SystemSettingsData.CPUDynamicLightScale();
            data.RenderSettings.DecalFadeDistanceScale = new SystemSettingsData.DecalFadeDistanceScale();
            data.RenderSettings.DecoratorFadeDistance = new SystemSettingsData.DecoratorFadeDistance();
            data.RenderSettings.EffectsLODDistanceScale = new SystemSettingsData.EffectsLODDistanceScale();
            data.RenderSettings.GPUDynamicLightMaxCount = new SystemSettingsData.GPUDynamicLightMaxCount();
            data.RenderSettings.GPUDynamicLightScale = new SystemSettingsData.GPUDynamicLightScale();
            data.RenderSettings.InstanceFadeModifier = new SystemSettingsData.InstanceFadeModifier();
            data.RenderSettings.ObjectDetailModifer = new SystemSettingsData.ObjectDetailModifer();
            data.RenderSettings.ObjectFadeModifer = new SystemSettingsData.ObjectFadeModifer();
            data.RenderSettings.ObjectImposterCutoffModifer = new SystemSettingsData.ObjectImposterCutoffModifer();
            data.RenderSettings.ScreenspaceDynamicLightMaxCount = new SystemSettingsData.ScreenspaceDynamicLightMaxCount();
            data.RenderSettings.ScreenspaceDynamicLightScale = new SystemSettingsData.ScreenspaceDynamicLightScale();
            data.RenderSettings.ShadowGenerateCount = new SystemSettingsData.ShadowGenerateCount();
            data.RenderSettings.ShadowQualityLOD = new SystemSettingsData.ShadowQualityLOD();
            data.RenderSettings.StructureInstanceLODModifer = new SystemSettingsData.StructureInstanceLODModifer();
            data.RenderSettings.WaterLod = new SystemSettingsData.WaterLod();

            data.RenderSettings.CPUDynamicLightMaxCount.Offset = page.CPUDynamicLightMaxCountOffset;
            data.RenderSettings.CPUDynamicLightMaxCount.Scale = page.CPUDynamicLightMaxCountScale;

            data.RenderSettings.CPUDynamicLightScale.Offset = page.CPUDynamicLightScaleOffset;
            data.RenderSettings.CPUDynamicLightScale.Scale = page.CPUDynamicLightScaleScale;

            data.RenderSettings.DecalFadeDistanceScale.Offset = page.DecalFadeDistanceScaleOffset;
            data.RenderSettings.DecalFadeDistanceScale.Scale = page.DecalFadeDistanceScaleScale;

            data.RenderSettings.DecoratorFadeDistance.Offset = page.DecoratorFadeDistanceOffset;
            data.RenderSettings.DecoratorFadeDistance.Scale = page.DecoratorFadeDistanceScale;

            data.RenderSettings.EffectsLODDistanceScale.Offset = page.EffectsLODDistanceScaleOffset;
            data.RenderSettings.EffectsLODDistanceScale.Scale = page.EffectsLODDistanceScaleScale;

            data.GeneralVideoSettings.FPSLock = page.FPSLock;

            data.RenderSettings.GPUDynamicLightMaxCount.Offset = page.GPUDynamicLightMaxCountOffset;
            data.RenderSettings.GPUDynamicLightMaxCount.Scale = page.GPUDynamicLightMaxCountScale;

            data.RenderSettings.GPUDynamicLightScale.Offset = page.GPUDynamicLightScaleOffset;
            data.RenderSettings.GPUDynamicLightScale.Scale = page.GPUDynamicLightScaleScale;

            data.RenderSettings.InstanceFadeModifier.Offset = page.InstanceFadeModifierOffset;
            data.RenderSettings.InstanceFadeModifier.Scale = page.InstanceFadeModifierScale;

            data.RenderSettings.ObjectDetailModifer.Offset = page.ObjectDetailModiferOffset;
            data.RenderSettings.ObjectDetailModifer.Scale = page.ObjectDetailModiferScale;

            data.RenderSettings.ObjectFadeModifer.Offset = page.ObjectFadeModiferOffset;
            data.RenderSettings.ObjectFadeModifer.Scale = page.ObjectFadeModiferScale;

            data.RenderSettings.ObjectImposterCutoffModifer.Offset = page.ObjectImposterCutoffModiferOffset;
            data.RenderSettings.ObjectImposterCutoffModifer.Scale = page.ObjectImposterCutoffModiferScale;

            data.RenderSettings.ScreenspaceDynamicLightMaxCount.Offset = page.ScreenspaceDynamicLightMaxCountOffset;
            data.RenderSettings.ScreenspaceDynamicLightMaxCount.Scale = page.ScreenspaceDynamicLightMaxCountScale;

            data.RenderSettings.ScreenspaceDynamicLightScale.Offset = page.ScreenspaceDynamicLightScaleOffset;
            data.RenderSettings.ScreenspaceDynamicLightScale.Scale = page.ScreenspaceDynamicLightScaleScale;

            data.RenderSettings.ShadowQualityLOD.Offset = page.ShadowQualityLODOffset;
            data.RenderSettings.ShadowQualityLOD.Scale = page.ShadowQualityLODScale;

            data.RenderSettings.StructureInstanceLODModifer.Offset = page.StructureInstanceLODModiferOffset;
            data.RenderSettings.StructureInstanceLODModifer.Scale = page.StructureInstanceLODModiferScale;

            data.GeneralVideoSettings.VSync = page.VSync;

            data.RenderSettings.WaterLod.Offset = page.WaterLodOffset;
            data.RenderSettings.WaterLod.Scale = page.WaterLodScale;

            return data;
        }

        private SystemSettingsData.ReachGameData CopyFromReachPropertyPage(ReachPropertyPage page)
        {
            var data = new SystemSettingsData.ReachGameData();
            data.GeneralVideoSettings = new SystemSettingsData.GeneralVideoSettings();
            data.RenderSettings = new SystemSettingsData.ReachRenderSettings();
            data.RenderSettings.CPUDynamicLightMaxCount = new SystemSettingsData.CPUDynamicLightMaxCount();
            data.RenderSettings.CPUDynamicLightScale = new SystemSettingsData.CPUDynamicLightScale();
            data.RenderSettings.DecalFadeDistanceScale = new SystemSettingsData.DecalFadeDistanceScale();
            data.RenderSettings.DecoratorFadeDistance = new SystemSettingsData.DecoratorFadeDistance();
            data.RenderSettings.EffectsLODDistanceScale = new SystemSettingsData.EffectsLODDistanceScale();
            data.RenderSettings.GPUDynamicLightMaxCount = new SystemSettingsData.GPUDynamicLightMaxCount();
            data.RenderSettings.GPUDynamicLightScale = new SystemSettingsData.GPUDynamicLightScale();
            data.RenderSettings.InstanceFadeModifier = new SystemSettingsData.InstanceFadeModifier();
            data.RenderSettings.ObjectDetailModifer = new SystemSettingsData.ObjectDetailModifer();
            data.RenderSettings.ObjectFadeModifer = new SystemSettingsData.ObjectFadeModifer();
            data.RenderSettings.ObjectImposterCutoffModifer = new SystemSettingsData.ObjectImposterCutoffModifer();
            data.RenderSettings.ScreenspaceDynamicLightMaxCount = new SystemSettingsData.ScreenspaceDynamicLightMaxCount();
            data.RenderSettings.ScreenspaceDynamicLightScale = new SystemSettingsData.ScreenspaceDynamicLightScale();
            data.RenderSettings.ShadowGenerateCount = new SystemSettingsData.ShadowGenerateCount();
            data.RenderSettings.ShadowQualityLOD = new SystemSettingsData.ShadowQualityLOD();
            data.RenderSettings.StructureInstanceLODModifer = new SystemSettingsData.StructureInstanceLODModifer();
            data.RenderSettings.WaterLod = new SystemSettingsData.WaterLod();

            data.RenderSettings.CPUDynamicLightMaxCount.Offset = page.CPUDynamicLightMaxCountOffset;
            data.RenderSettings.CPUDynamicLightMaxCount.Scale = page.CPUDynamicLightMaxCountScale;

            data.RenderSettings.CPUDynamicLightScale.Offset = page.CPUDynamicLightScaleOffset;
            data.RenderSettings.CPUDynamicLightScale.Scale = page.CPUDynamicLightScaleScale;

            data.RenderSettings.DecalFadeDistanceScale.Offset = page.DecalFadeDistanceScaleOffset;
            data.RenderSettings.DecalFadeDistanceScale.Scale = page.DecalFadeDistanceScaleScale;

            data.RenderSettings.DecoratorFadeDistance.Offset = page.DecoratorFadeDistanceOffset;
            data.RenderSettings.DecoratorFadeDistance.Scale = page.DecoratorFadeDistanceScale;

            data.RenderSettings.DisableCheapParticles = page.DisableCheapParticles;

            data.RenderSettings.DisableDynamicLightingShadows = page.DisableDynamicLightingShadows;

            data.RenderSettings.DisableFirstPersonShadow = page.DisableFirstPersonShadow;

            data.RenderSettings.DisablePatchyFog = page.DisablePatchyFog;

            data.RenderSettings.EffectsLODDistanceScale.Offset = page.EffectsLODDistanceScaleOffset;
            data.RenderSettings.EffectsLODDistanceScale.Scale = page.EffectsLODDistanceScaleScale;

            data.GeneralVideoSettings.FPSLock = page.FPSLock;

            data.RenderSettings.GPUDynamicLightMaxCount.Offset = page.GPUDynamicLightMaxCountOffset;
            data.RenderSettings.GPUDynamicLightMaxCount.Scale = page.GPUDynamicLightMaxCountScale;

            data.RenderSettings.GPUDynamicLightScale.Offset = page.GPUDynamicLightScaleOffset;
            data.RenderSettings.GPUDynamicLightScale.Scale = page.GPUDynamicLightScaleScale;

            data.RenderSettings.InstanceFadeModifier.Offset = page.InstanceFadeModifierOffset;
            data.RenderSettings.InstanceFadeModifier.Scale = page.InstanceFadeModifierScale;

            data.RenderSettings.ObjectDetailModifer.Offset = page.ObjectDetailModiferOffset;
            data.RenderSettings.ObjectDetailModifer.Scale = page.ObjectDetailModiferScale;

            data.RenderSettings.ObjectFadeModifer.Offset = page.ObjectFadeModiferOffset;
            data.RenderSettings.ObjectFadeModifer.Scale = page.ObjectFadeModiferScale;

            data.RenderSettings.ObjectImposterCutoffModifer.Offset = page.ObjectImposterCutoffModiferOffset;
            data.RenderSettings.ObjectImposterCutoffModifer.Scale = page.ObjectImposterCutoffModiferScale;

            data.RenderSettings.ScreenspaceDynamicLightMaxCount.Offset = page.ScreenspaceDynamicLightMaxCountOffset;
            data.RenderSettings.ScreenspaceDynamicLightMaxCount.Scale = page.ScreenspaceDynamicLightMaxCountScale;

            data.RenderSettings.ScreenspaceDynamicLightScale.Offset = page.ScreenspaceDynamicLightScaleOffset;
            data.RenderSettings.ScreenspaceDynamicLightScale.Scale = page.ScreenspaceDynamicLightScaleScale;

            data.RenderSettings.ShadowQualityLOD.Offset = page.ShadowQualityLODOffset;
            data.RenderSettings.ShadowQualityLOD.Scale = page.ShadowQualityLODScale;

            data.RenderSettings.StructureInstanceLODModifer.Offset = page.StructureInstanceLODModiferOffset;
            data.RenderSettings.StructureInstanceLODModifer.Scale = page.StructureInstanceLODModiferScale;

            data.GeneralVideoSettings.VSync = page.VSync;

            data.RenderSettings.WaterLod.Offset = page.WaterLodOffset;
            data.RenderSettings.WaterLod.Scale = page.WaterLodScale;

            return data;
        }

        private class GenericPropertyPage
        {
            [DisplayName("VSync"), Category("General Video Settings")]
            public bool VSync { get; set; }

            [DisplayName("FPS Lock"), Category("General Video Settings")]
            public bool FPSLock { get; set; }

            [DisplayName("Water LOD (Scale)"), Category("Render Settings")]
            public double WaterLodScale { get; set; }

            [DisplayName("Water LOD (Offset)"), Category("Render Settings")]
            public double WaterLodOffset { get; set; }

            [DisplayName("Object Fade Modifer (Scale)"), Category("Render Settings")]
            public double ObjectFadeModiferScale { get; set; }

            [DisplayName("Object Fade Modifer (Offset)"), Category("Render Settings")]
            public double ObjectFadeModiferOffset { get; set; }

            [DisplayName("Object Detail Modifer (Scale)"), Category("Render Settings")]
            public double ObjectDetailModiferScale { get; set; }

            [DisplayName("Object Detail Modifer (Offset)"), Category("Render Settings")]
            public double ObjectDetailModiferOffset { get; set; }

            [DisplayName("Object Imposter Cutoff Modifer (Scale)"), Category("Render Settings")]
            public double ObjectImposterCutoffModiferScale { get; set; }

            [DisplayName("Object Imposter Cutoff Modifer (Offset)"), Category("Render Settings")]
            public double ObjectImposterCutoffModiferOffset { get; set; }

            [DisplayName("Screenspace Dynamic Light Max Count (Scale)"), Category("Render Settings")]
            public double ScreenspaceDynamicLightMaxCountScale { get; set; }

            [DisplayName("Screenspace Dynamic Light Max Count (Offset)"), Category("Render Settings")]
            public int ScreenspaceDynamicLightMaxCountOffset { get; set; }

            [DisplayName("Screenspace Dynamic Light Scale (Scale)"), Category("Render Settings")]
            public double ScreenspaceDynamicLightScaleScale { get; set; }

            [DisplayName("Screenspace Dynamic Light Scale (Offset)"), Category("Render Settings")]
            public double ScreenspaceDynamicLightScaleOffset { get; set; }

            [DisplayName("CPU Dynamic Light Max Count (Scale)"), Category("Render Settings")]
            public double CPUDynamicLightMaxCountScale { get; set; }

            [DisplayName("CPU Dynamic Light Max Count (Offset)"), Category("Render Settings")]
            public int CPUDynamicLightMaxCountOffset { get; set; }

            [DisplayName("CPU Dynamic Light Scale (Scale)"), Category("Render Settings")]
            public double CPUDynamicLightScaleScale { get; set; }

            [DisplayName("CPU Dynamic Light Scale (Offset)"), Category("Render Settings")]
            public double CPUDynamicLightScaleOffset { get; set; }

            [DisplayName("GPU Dynamic Light Max Count (Scale)"), Category("Render Settings")]
            public double GPUDynamicLightMaxCountScale { get; set; }

            [DisplayName("GPU Dynamic Light Max Count (Offset)"), Category("Render Settings")]
            public int GPUDynamicLightMaxCountOffset { get; set; }

            [DisplayName("GPU Dynamic Light Scale (Scale)"), Category("Render Settings")]
            public double GPUDynamicLightScaleScale { get; set; }

            [DisplayName("GPU Dynamic Light Scale (Offset)"), Category("Render Settings")]
            public double GPUDynamicLightScaleOffset { get; set; }

            [DisplayName("Shadow Quality LOD (Scale)"), Category("Render Settings")]
            public double ShadowQualityLODScale { get; set; }

            [DisplayName("Shadow Quality LOD (Offset)"), Category("Render Settings")]
            public double ShadowQualityLODOffset { get; set; }

            [DisplayName("Effects LOD Distance Scale (Scale)"), Category("Render Settings")]
            public double EffectsLODDistanceScaleScale { get; set; }

            [DisplayName("Effects LOD Distance Scale (Offset)"), Category("Render Settings")]
            public double EffectsLODDistanceScaleOffset { get; set; }

            [DisplayName("Decal Fade Distance Scale (Scale)"), Category("Render Settings")]
            public double DecalFadeDistanceScaleScale { get; set; }

            [DisplayName("Decal Fade Distance Scale (Offset)"), Category("Render Settings")]
            public double DecalFadeDistanceScaleOffset { get; set; }

            [DisplayName("Decorator Fade Distance (Scale)"), Category("Render Settings")]
            public double DecoratorFadeDistanceScale { get; set; }

            [DisplayName("Decorator Fade Distance (Offset)"), Category("Render Settings")]
            public double DecoratorFadeDistanceOffset { get; set; }

            [DisplayName("Structure Instance LOD Modifer (Scale)"), Category("Render Settings")]
            public double StructureInstanceLODModiferScale { get; set; }

            [DisplayName("Structure Instance LOD Modifer (Offset)"), Category("Render Settings")]
            public double StructureInstanceLODModiferOffset { get; set; }

            [DisplayName("Instance Fade Modifier (Scale)"), Category("Render Settings")]
            public double InstanceFadeModifierScale { get; set; }

            [DisplayName("Instance Fade Modifier (Offset)"), Category("Render Settings")]
            public double InstanceFadeModifierOffset { get; set; }
        }

        private class ReachPropertyPage
        {
            [DisplayName("VSync"), Category("General Video Settings")]
            public bool VSync { get; set; }

            [DisplayName("FPS Lock"), Category("General Video Settings")]
            public bool FPSLock { get; set; }

            [DisplayName("Water LOD (Scale)"), Category("Render Settings")]
            public double WaterLodScale { get; set; }

            [DisplayName("Water LOD (Offset)"), Category("Render Settings")]
            public double WaterLodOffset { get; set; }

            [DisplayName("Object Fade Modifer (Scale)"), Category("Render Settings")]
            public double ObjectFadeModiferScale { get; set; }

            [DisplayName("Object Fade Modifer (Offset)"), Category("Render Settings")]
            public double ObjectFadeModiferOffset { get; set; }

            [DisplayName("Object Detail Modifer (Scale)"), Category("Render Settings")]
            public double ObjectDetailModiferScale { get; set; }

            [DisplayName("Object Detail Modifer (Offset)"), Category("Render Settings")]
            public double ObjectDetailModiferOffset { get; set; }

            [DisplayName("Object Imposter Cutoff Modifer (Scale)"), Category("Render Settings")]
            public double ObjectImposterCutoffModiferScale { get; set; }

            [DisplayName("Object Imposter Cutoff Modifer (Offset)"), Category("Render Settings")]
            public double ObjectImposterCutoffModiferOffset { get; set; }

            [DisplayName("Screenspace Dynamic Light Max Count (Scale)"), Category("Render Settings")]
            public double ScreenspaceDynamicLightMaxCountScale { get; set; }

            [DisplayName("Screenspace Dynamic Light Max Count (Offset)"), Category("Render Settings")]
            public int ScreenspaceDynamicLightMaxCountOffset { get; set; }

            [DisplayName("Screenspace Dynamic Light Scale (Scale)"), Category("Render Settings")]
            public double ScreenspaceDynamicLightScaleScale { get; set; }

            [DisplayName("Screenspace Dynamic Light Scale (Offset)"), Category("Render Settings")]
            public double ScreenspaceDynamicLightScaleOffset { get; set; }

            [DisplayName("CPU Dynamic Light Max Count (Scale)"), Category("Render Settings")]
            public double CPUDynamicLightMaxCountScale { get; set; }

            [DisplayName("CPU Dynamic Light Max Count (Offset)"), Category("Render Settings")]
            public int CPUDynamicLightMaxCountOffset { get; set; }

            [DisplayName("CPU Dynamic Light Scale (Scale)"), Category("Render Settings")]
            public double CPUDynamicLightScaleScale { get; set; }

            [DisplayName("CPU Dynamic Light Scale (Offset)"), Category("Render Settings")]
            public double CPUDynamicLightScaleOffset { get; set; }

            [DisplayName("GPU Dynamic Light Max Count (Scale)"), Category("Render Settings")]
            public double GPUDynamicLightMaxCountScale { get; set; }

            [DisplayName("GPU Dynamic Light Max Count (Offset)"), Category("Render Settings")]
            public int GPUDynamicLightMaxCountOffset { get; set; }

            [DisplayName("GPU Dynamic Light Scale (Scale)"), Category("Render Settings")]
            public double GPUDynamicLightScaleScale { get; set; }

            [DisplayName("GPU Dynamic Light Scale (Offset)"), Category("Render Settings")]
            public double GPUDynamicLightScaleOffset { get; set; }

            [DisplayName("Shadow Quality LOD (Scale)"), Category("Render Settings")]
            public double ShadowQualityLODScale { get; set; }

            [DisplayName("Shadow Quality LOD (Offset)"), Category("Render Settings")]
            public double ShadowQualityLODOffset { get; set; }

            [DisplayName("Effects LOD Distance Scale (Scale)"), Category("Render Settings")]
            public double EffectsLODDistanceScaleScale { get; set; }

            [DisplayName("Effects LOD Distance Scale (Offset)"), Category("Render Settings")]
            public double EffectsLODDistanceScaleOffset { get; set; }

            [DisplayName("Decal Fade Distance Scale (Scale)"), Category("Render Settings")]
            public double DecalFadeDistanceScaleScale { get; set; }

            [DisplayName("Decal Fade Distance Scale (Offset)"), Category("Render Settings")]
            public double DecalFadeDistanceScaleOffset { get; set; }

            [DisplayName("Decorator Fade Distance (Scale)"), Category("Render Settings")]
            public double DecoratorFadeDistanceScale { get; set; }

            [DisplayName("Decorator Fade Distance (Offset)"), Category("Render Settings")]
            public double DecoratorFadeDistanceOffset { get; set; }

            [DisplayName("Structure Instance LOD Modifer (Scale)"), Category("Render Settings")]
            public double StructureInstanceLODModiferScale { get; set; }

            [DisplayName("Structure Instance LOD Modifer (Offset)"), Category("Render Settings")]
            public double StructureInstanceLODModiferOffset { get; set; }

            [DisplayName("Instance Fade Modifier (Scale)"), Category("Render Settings")]
            public double InstanceFadeModifierScale { get; set; }

            [DisplayName("Instance Fade Modifier (Offset)"), Category("Render Settings")]
            public double InstanceFadeModifierOffset { get; set; }

            [DisplayName("Disable Dynamic Lighting Shadows"), Category("Render Settings")]
            public bool DisableDynamicLightingShadows { get; set; }

            [DisplayName("Disable First Person Shadow"), Category("Render Settings")]
            public bool DisableFirstPersonShadow { get; set; }

            [DisplayName("Disable Cheap Particles"), Category("Render Settings")]
            public bool DisableCheapParticles { get; set; }

            [DisplayName("Disable Patchy Fog"), Category("Render Settings")]
            public bool DisablePatchyFog { get; set; }
        }

        private void ReadSystemSettingsData()
        {
            if (file == null) return;
            file.Refresh();
            byte[] buffer = new byte[file.Length];
            using (var reader = file.OpenRead())
            {
                reader.Read(buffer, 0, buffer.Length);
                reader.Close();
            }
            string json = Decompress(buffer);
            SystemSettingsData.Root data = JsonConvert.DeserializeObject<SystemSettingsData.Root>(json);
            /*
             * Only seems to use the Halo Reach entry for universal renderer settings for all games (for now)
             * 
            propertyGrid1.SelectedObject = CopyToGenericPropertyPage(data.Halo1);
            propertyGrid2.SelectedObject = CopyToGenericPropertyPage(data.Halo2);
            propertyGrid3.SelectedObject = CopyToGenericPropertyPage(data.Halo3);
            propertyGrid4.SelectedObject = CopyToGenericPropertyPage(data.Halo4);
            propertyGrid5.SelectedObject = CopyToGenericPropertyPage(data.Halo2A);
            propertyGrid6.SelectedObject = CopyToGenericPropertyPage(data.Halo3ODST);
            propertyGrid7.SelectedObject = CopyToReachPropertyPage(data.HaloReach);
            */
            RendererProperties.SelectedObject = CopyToReachPropertyPage(data.HaloReach);
        }

        private void WriteSystemSettingsData()
        {
            if (file == null) return;
            SystemSettingsData.Root data = new SystemSettingsData.Root();
            /*
             * Only seems to use the Halo Reach entry for universal renderer settings for all games (for now)
             * 
            data.Halo1 = CopyFromGenericPropertyPage((GenericPropertyPage)propertyGrid1.SelectedObject);
            data.Halo2 = CopyFromGenericPropertyPage((GenericPropertyPage)propertyGrid2.SelectedObject);
            data.Halo3 = CopyFromGenericPropertyPage((GenericPropertyPage)propertyGrid3.SelectedObject);
            data.Halo4 = CopyFromGenericPropertyPage((GenericPropertyPage)propertyGrid4.SelectedObject);
            data.Halo2A = CopyFromGenericPropertyPage((GenericPropertyPage)propertyGrid5.SelectedObject);
            data.Halo3ODST = CopyFromGenericPropertyPage((GenericPropertyPage)propertyGrid6.SelectedObject);
            data.HaloReach = CopyFromReachPropertyPage((ReachPropertyPage)propertyGrid7.SelectedObject);
            */

            SystemSettingsData.GenericGameData DummyData = SystemSettingsData.GenericGameData.Default();
            data.Halo1 = DummyData;
            data.Halo2 = DummyData;
            data.Halo2A = DummyData;
            data.Halo3 = DummyData;
            data.Halo3ODST = DummyData;
            data.Halo4 = DummyData;
            data.HaloReach = CopyFromReachPropertyPage((ReachPropertyPage)RendererProperties.SelectedObject);

            string json = JsonConvert.SerializeObject(data);
            byte[] buffer = Compress(json);

            using (var writer = file.OpenWrite())
            {
                writer.SetLength(0);
                writer.Flush();
                writer.Write(buffer, 0, buffer.Length);
                writer.Flush();
                writer.Close();
            }
        }

        private string Decompress(byte[] data)
        {
            string result = null;
            using (var memory = new MemoryStream())
            {
                using (var zlib = new InflaterInputStream(new MemoryStream(data)))
                {
                    var buffer = new byte[0x1000];
                    var count = 0;
                    while ((count = zlib.Read(buffer, 0, 0x1000)) > 0)
                    {
                        memory.Write(buffer, 0, count);
                    }
                    zlib.Close();
                }
                result = Encoding.UTF8.GetString(memory.ToArray());
                memory.Close();
            }
            return result;
        }

        private byte[] Compress(string data)
        {
            byte[] result = null;
            using (var memory = new MemoryStream())
            {
                using (var zlib = new DeflaterOutputStream(memory, new Deflater(9, false))) //BEST_COMPRESSION, add header+checksum
                {
                    zlib.Write(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetByteCount(data));
                    zlib.Flush();
                }
                result = memory.ToArray();
                memory.Close();
            }
            return result;
        }

        private bool GetSystemSettingsData(out FileInfo file)
        {
            file = null;
            string localLow = GetLocalLowFolder();
            if (localLow == null) return false;
            string filePath = Path.Combine(localLow, "MCC\\SystemSettingsData.bin");
            if (File.Exists(filePath))
            {
                file = new FileInfo(filePath);
                return true;
            }
            return false;
        }

        private static string GetLocalLowFolder()
        {
            string result = null;
            IntPtr pFolder = IntPtr.Zero;
            if (SHGetKnownFolderPath(new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16"), 0, IntPtr.Zero, out pFolder) == 0)
            {
                result = Marshal.PtrToStringAuto(pFolder);
            }
            if (pFolder != IntPtr.Zero) Marshal.FreeCoTaskMem(pFolder);
            return result;
        }

        [DllImport("shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);

        private class SystemSettingsData
        {

            public class GeneralVideoSettings
            {
                public bool VSync { get; set; }
                public bool FPSLock { get; set; }
            }

            public class WaterLod
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class ObjectFadeModifer
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class ObjectDetailModifer
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class ObjectImposterCutoffModifer
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class ScreenspaceDynamicLightMaxCount
            {
                public double Scale { get; set; }
                public int Offset { get; set; }
            }

            public class ScreenspaceDynamicLightScale
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class CPUDynamicLightMaxCount
            {
                public double Scale { get; set; }
                public int Offset { get; set; }
            }

            public class CPUDynamicLightScale
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class GPUDynamicLightMaxCount
            {
                public double Scale { get; set; }
                public int Offset { get; set; }
            }

            public class GPUDynamicLightScale
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class ShadowGenerateCount
            {
                public double Scale { get; set; }
                public int Offset { get; set; }
            }

            public class ShadowQualityLOD
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class EffectsLODDistanceScale
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class DecalFadeDistanceScale
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class DecoratorFadeDistance
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class StructureInstanceLODModifer
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class InstanceFadeModifier
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class GenericRenderSettings
            {
                public WaterLod WaterLod { get; set; }
                public ObjectFadeModifer ObjectFadeModifer { get; set; }
                public ObjectDetailModifer ObjectDetailModifer { get; set; }
                public ObjectImposterCutoffModifer ObjectImposterCutoffModifer { get; set; }
                public ScreenspaceDynamicLightMaxCount ScreenspaceDynamicLightMaxCount { get; set; }
                public ScreenspaceDynamicLightScale ScreenspaceDynamicLightScale { get; set; }
                public CPUDynamicLightMaxCount CPUDynamicLightMaxCount { get; set; }
                public CPUDynamicLightScale CPUDynamicLightScale { get; set; }
                public GPUDynamicLightMaxCount GPUDynamicLightMaxCount { get; set; }
                public GPUDynamicLightScale GPUDynamicLightScale { get; set; }
                public ShadowGenerateCount ShadowGenerateCount { get; set; }
                public ShadowQualityLOD ShadowQualityLOD { get; set; }
                public EffectsLODDistanceScale EffectsLODDistanceScale { get; set; }
                public DecalFadeDistanceScale DecalFadeDistanceScale { get; set; }
                public DecoratorFadeDistance DecoratorFadeDistance { get; set; }
                public StructureInstanceLODModifer StructureInstanceLODModifer { get; set; }
                public InstanceFadeModifier InstanceFadeModifier { get; set; }
            }

            public class ReachRenderSettings
            {
                public WaterLod WaterLod { get; set; }
                public ObjectFadeModifer ObjectFadeModifer { get; set; }
                public ObjectDetailModifer ObjectDetailModifer { get; set; }
                public ObjectImposterCutoffModifer ObjectImposterCutoffModifer { get; set; }
                public ScreenspaceDynamicLightMaxCount ScreenspaceDynamicLightMaxCount { get; set; }
                public ScreenspaceDynamicLightScale ScreenspaceDynamicLightScale { get; set; }
                public CPUDynamicLightMaxCount CPUDynamicLightMaxCount { get; set; }
                public CPUDynamicLightScale CPUDynamicLightScale { get; set; }
                public GPUDynamicLightMaxCount GPUDynamicLightMaxCount { get; set; }
                public GPUDynamicLightScale GPUDynamicLightScale { get; set; }
                public ShadowGenerateCount ShadowGenerateCount { get; set; }
                public ShadowQualityLOD ShadowQualityLOD { get; set; }
                public bool DisableDynamicLightingShadows { get; set; }
                public bool DisableFirstPersonShadow { get; set; }
                public EffectsLODDistanceScale EffectsLODDistanceScale { get; set; }
                public DecalFadeDistanceScale DecalFadeDistanceScale { get; set; }
                public bool DisableCheapParticles { get; set; }
                public bool DisablePatchyFog { get; set; }
                public DecoratorFadeDistance DecoratorFadeDistance { get; set; }
                public StructureInstanceLODModifer StructureInstanceLODModifer { get; set; }
                public InstanceFadeModifier InstanceFadeModifier { get; set; }
            }

            public class GenericGameData
            {
                public GeneralVideoSettings GeneralVideoSettings { get; set; }
                public GenericRenderSettings RenderSettings { get; set; }

                public static GenericGameData Default()
                {
                    return new GenericGameData()
                    {
                        GeneralVideoSettings = new GeneralVideoSettings(),
                        RenderSettings = new GenericRenderSettings()
                        {
                            WaterLod = new WaterLod(),
                            ObjectFadeModifer = new SystemSettingsData.ObjectFadeModifer(),
                            ObjectDetailModifer = new SystemSettingsData.ObjectDetailModifer(),
                            ObjectImposterCutoffModifer = new SystemSettingsData.ObjectImposterCutoffModifer(),
                            ScreenspaceDynamicLightMaxCount = new SystemSettingsData.ScreenspaceDynamicLightMaxCount(),
                            ScreenspaceDynamicLightScale = new SystemSettingsData.ScreenspaceDynamicLightScale(),
                            CPUDynamicLightMaxCount = new SystemSettingsData.CPUDynamicLightMaxCount(),
                            CPUDynamicLightScale = new SystemSettingsData.CPUDynamicLightScale(),
                            GPUDynamicLightMaxCount = new SystemSettingsData.GPUDynamicLightMaxCount(),
                            GPUDynamicLightScale = new SystemSettingsData.GPUDynamicLightScale(),
                            ShadowGenerateCount = new SystemSettingsData.ShadowGenerateCount(),
                            ShadowQualityLOD = new SystemSettingsData.ShadowQualityLOD(),
                            EffectsLODDistanceScale = new SystemSettingsData.EffectsLODDistanceScale(),
                            DecalFadeDistanceScale = new SystemSettingsData.DecalFadeDistanceScale(),
                            DecoratorFadeDistance = new SystemSettingsData.DecoratorFadeDistance(),
                            StructureInstanceLODModifer = new SystemSettingsData.StructureInstanceLODModifer(),
                            InstanceFadeModifier = new SystemSettingsData.InstanceFadeModifier()
                        }
                    };
                }
            }

            public class ReachGameData
            {
                public GeneralVideoSettings GeneralVideoSettings { get; set; }
                public ReachRenderSettings RenderSettings { get; set; }
            }

            public class Root
            {
                [JsonProperty("GameData[Halo1]")]
                public GenericGameData Halo1 { get; set; }

                [JsonProperty("GameData[Halo2]")]
                public GenericGameData Halo2 { get; set; }

                [JsonProperty("GameData[Halo3]")]
                public GenericGameData Halo3 { get; set; }

                [JsonProperty("GameData[Halo4]")]
                public GenericGameData Halo4 { get; set; }

                [JsonProperty("GameData[Halo2A]")]
                public GenericGameData Halo2A { get; set; }

                [JsonProperty("GameData[Halo3ODST]")]
                public GenericGameData Halo3ODST { get; set; }

                [JsonProperty("GameData[HaloReach]")]
                public ReachGameData HaloReach { get; set; }
            }

        }

    }
}
