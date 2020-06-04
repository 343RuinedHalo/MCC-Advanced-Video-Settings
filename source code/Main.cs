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

        private GenericPropertyPage CopyToGenericPropertyPage(SystemSettingsData.GameData data)
        {
            var page = new GenericPropertyPage();

            page.FPSLock = data.GeneralVideoSettings.FPSLock;
            page.VSync = data.GeneralVideoSettings.VSync;
            page.TextureResolution = data.GeneralVideoSettings.TextureResolution;
            page.TextureFilteringQuality = data.GeneralVideoSettings.TextureFilteringQuality;
            page.LightingQuality = data.GeneralVideoSettings.LightingQuality;
            page.EffectsQuality = data.GeneralVideoSettings.EffectsQuality;
            page.ShadowQuality = data.GeneralVideoSettings.ShadowQuality;
            page.DetailsQuality = data.GeneralVideoSettings.DetailsQuality;
            page.PostProcessingQuality = data.GeneralVideoSettings.PostProcessingQuality;
            page.AntiAliasing = data.GeneralVideoSettings.AntiAliasing;

            page.WaterLodOffset = data.RenderSettings.WaterLod.Offset;
            page.WaterLodScale = data.RenderSettings.WaterLod.Scale;
            page.ObjectFadeModiferOffset = data.RenderSettings.ObjectFadeModifer.Offset;
            page.ObjectFadeModiferScale = data.RenderSettings.ObjectFadeModifer.Scale;
            page.ObjectDetailModiferOffset = data.RenderSettings.ObjectDetailModifer.Offset;
            page.ObjectDetailModiferScale = data.RenderSettings.ObjectDetailModifer.Scale;
            page.ObjectImposterCutoffModiferOffset = data.RenderSettings.ObjectImposterCutoffModifer.Offset;
            page.ObjectImposterCutoffModiferScale = data.RenderSettings.ObjectImposterCutoffModifer.Scale;
            page.ScreenspaceDynamicLightMaxCountOffset = data.RenderSettings.ScreenspaceDynamicLightMaxCount.Offset;
            page.ScreenspaceDynamicLightMaxCountScale = data.RenderSettings.ScreenspaceDynamicLightMaxCount.Scale;
            page.ScreenspaceDynamicLightScaleOffset = data.RenderSettings.ScreenspaceDynamicLightScale.Offset;
            page.ScreenspaceDynamicLightScaleScale = data.RenderSettings.ScreenspaceDynamicLightScale.Scale;
            page.CPUDynamicLightMaxCountOffset = data.RenderSettings.CPUDynamicLightMaxCount.Offset;
            page.CPUDynamicLightMaxCountScale = data.RenderSettings.CPUDynamicLightMaxCount.Scale;
            page.CPUDynamicLightScaleOffset = data.RenderSettings.CPUDynamicLightScale.Offset;
            page.CPUDynamicLightScaleScale = data.RenderSettings.CPUDynamicLightScale.Scale;
            page.GPUDynamicLightMaxCountOffset = data.RenderSettings.GPUDynamicLightMaxCount.Offset;
            page.GPUDynamicLightMaxCountScale = data.RenderSettings.GPUDynamicLightMaxCount.Scale;
            page.GPUDynamicLightScaleOffset = data.RenderSettings.GPUDynamicLightScale.Offset;
            page.GPUDynamicLightScaleScale = data.RenderSettings.GPUDynamicLightScale.Scale;
            page.ShadowGenerateCountOffset = data.RenderSettings.ShadowGenerateCount.Offset;
            page.ShadowGenerateCountScale = data.RenderSettings.ShadowGenerateCount.Scale;
            page.ShadowQualityLODOffset = data.RenderSettings.ShadowQualityLOD.Offset;
            page.ShadowQualityLODScale = data.RenderSettings.ShadowQualityLOD.Scale;
            page.DisableDynamicLightingShadows = data.RenderSettings.DisableDynamicLightingShadows;
            page.DisableFirstPersonShadow = data.RenderSettings.DisableFirstPersonShadow;
            page.EffectsLODDistanceScaleOffset = data.RenderSettings.EffectsLODDistanceScale.Offset;
            page.EffectsLODDistanceScaleScale = data.RenderSettings.EffectsLODDistanceScale.Scale;
            page.DecalFadeDistanceScaleOffset = data.RenderSettings.DecalFadeDistanceScale.Offset;
            page.DecalFadeDistanceScaleScale = data.RenderSettings.DecalFadeDistanceScale.Scale;
            page.DisableCheapParticles = data.RenderSettings.DisableCheapParticles;
            page.DisablePatchyFog = data.RenderSettings.DisablePatchyFog;
            page.DecoratorFadeDistanceOffset = data.RenderSettings.DecoratorFadeDistance.Offset;
            page.DecoratorFadeDistanceScale = data.RenderSettings.DecoratorFadeDistance.Scale;
            page.StructureInstanceLODModiferOffset = data.RenderSettings.StructureInstanceLODModifer.Offset;
            page.StructureInstanceLODModiferScale = data.RenderSettings.StructureInstanceLODModifer.Scale;
            page.InstanceFadeModifierOffset = data.RenderSettings.InstanceFadeModifier.Offset;
            page.InstanceFadeModifierScale = data.RenderSettings.InstanceFadeModifier.Scale;

            return page;
        }

        private SystemSettingsData.GameData CopyFromGenericPropertyPage(GenericPropertyPage page)
        {
            var data = new SystemSettingsData.GameData();
            data.GeneralVideoSettings = new SystemSettingsData.GeneralVideoSettings();
            data.RenderSettings = new SystemSettingsData.RenderSettings
            {
                WaterLod = new SystemSettingsData.WaterLod(),
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
            };

            data.GeneralVideoSettings.VSync = page.VSync;
            data.GeneralVideoSettings.FPSLock = page.FPSLock;
            data.GeneralVideoSettings.TextureResolution = page.TextureResolution;
            data.GeneralVideoSettings.TextureFilteringQuality = page.TextureFilteringQuality;
            data.GeneralVideoSettings.LightingQuality = page.LightingQuality;
            data.GeneralVideoSettings.EffectsQuality = page.EffectsQuality;
            data.GeneralVideoSettings.ShadowQuality = page.ShadowQuality;
            data.GeneralVideoSettings.DetailsQuality = page.DetailsQuality;
            data.GeneralVideoSettings.PostProcessingQuality = page.PostProcessingQuality;
            data.GeneralVideoSettings.AntiAliasing = page.AntiAliasing;

            data.RenderSettings.WaterLod.Offset = page.WaterLodOffset;
            data.RenderSettings.WaterLod.Scale = page.WaterLodScale;
            data.RenderSettings.ObjectFadeModifer.Offset = page.ObjectFadeModiferOffset;
            data.RenderSettings.ObjectFadeModifer.Scale = page.ObjectFadeModiferScale;
            data.RenderSettings.ObjectDetailModifer.Offset = page.ObjectDetailModiferOffset;
            data.RenderSettings.ObjectDetailModifer.Scale = page.ObjectDetailModiferScale;
            data.RenderSettings.ObjectImposterCutoffModifer.Offset = page.ObjectImposterCutoffModiferOffset;
            data.RenderSettings.ObjectImposterCutoffModifer.Scale = page.ObjectImposterCutoffModiferScale;
            data.RenderSettings.ScreenspaceDynamicLightMaxCount.Offset = page.ScreenspaceDynamicLightMaxCountOffset;
            data.RenderSettings.ScreenspaceDynamicLightMaxCount.Scale = page.ScreenspaceDynamicLightMaxCountScale;
            data.RenderSettings.ScreenspaceDynamicLightScale.Offset = page.ScreenspaceDynamicLightScaleOffset;
            data.RenderSettings.ScreenspaceDynamicLightScale.Scale = page.ScreenspaceDynamicLightScaleScale;
            data.RenderSettings.CPUDynamicLightMaxCount.Offset = page.CPUDynamicLightMaxCountOffset;
            data.RenderSettings.CPUDynamicLightMaxCount.Scale = page.CPUDynamicLightMaxCountScale;
            data.RenderSettings.CPUDynamicLightScale.Offset = page.CPUDynamicLightScaleOffset;
            data.RenderSettings.CPUDynamicLightScale.Scale = page.CPUDynamicLightScaleScale;
            data.RenderSettings.GPUDynamicLightMaxCount.Offset = page.GPUDynamicLightMaxCountOffset;
            data.RenderSettings.GPUDynamicLightMaxCount.Scale = page.GPUDynamicLightMaxCountScale;
            data.RenderSettings.GPUDynamicLightScale.Offset = page.GPUDynamicLightScaleOffset;
            data.RenderSettings.GPUDynamicLightScale.Scale = page.GPUDynamicLightScaleScale;
            data.RenderSettings.ShadowGenerateCount.Offset = page.ShadowGenerateCountOffset;
            data.RenderSettings.ShadowGenerateCount.Scale = page.ShadowGenerateCountScale;
            data.RenderSettings.ShadowQualityLOD.Offset = page.ShadowQualityLODOffset;
            data.RenderSettings.ShadowQualityLOD.Scale = page.ShadowQualityLODScale;
            data.RenderSettings.DisableDynamicLightingShadows = page.DisableDynamicLightingShadows;
            data.RenderSettings.DisableFirstPersonShadow = page.DisableFirstPersonShadow;
            data.RenderSettings.EffectsLODDistanceScale.Offset = page.EffectsLODDistanceScaleOffset;
            data.RenderSettings.EffectsLODDistanceScale.Scale = page.EffectsLODDistanceScaleScale;
            data.RenderSettings.DecalFadeDistanceScale.Offset = page.DecalFadeDistanceScaleOffset;
            data.RenderSettings.DecalFadeDistanceScale.Scale = page.DecalFadeDistanceScaleScale;
            data.RenderSettings.DisableCheapParticles = page.DisableCheapParticles;
            data.RenderSettings.DisablePatchyFog = page.DisablePatchyFog;
            data.RenderSettings.DecoratorFadeDistance.Offset = page.DecoratorFadeDistanceOffset;
            data.RenderSettings.DecoratorFadeDistance.Scale = page.DecoratorFadeDistanceScale;
            data.RenderSettings.StructureInstanceLODModifer.Offset = page.StructureInstanceLODModiferOffset;
            data.RenderSettings.StructureInstanceLODModifer.Scale = page.StructureInstanceLODModiferScale;
            data.RenderSettings.InstanceFadeModifier.Offset = page.InstanceFadeModifierOffset;
            data.RenderSettings.InstanceFadeModifier.Scale = page.InstanceFadeModifierScale;

            return data;
        }

        private class GenericPropertyPage
        {
            [DisplayName("VSync"), Category("General Video Settings")]
            public bool VSync { get; set; }

            [DisplayName("FPS Lock"), Category("General Video Settings")]
            public bool FPSLock { get; set; }

            [DisplayName("Texture Resolution"), Category("General Video Settings")]
            public double TextureResolution { get; set; }

            [DisplayName("Texture Filtering Quality"), Category("General Video Settings")]
            public double TextureFilteringQuality { get; set; }

            [DisplayName("Lighting Quality"), Category("General Video Settings")]
            public double LightingQuality { get; set; }

            [DisplayName("Effects Quality"), Category("General Video Settings")]
            public double EffectsQuality { get; set; }

            [DisplayName("Details Quality"), Category("General Video Settings")]
            public double DetailsQuality { get; set; }

            [DisplayName("Post Processing Quality"), Category("General Video Settings")]
            public double PostProcessingQuality { get; set; }

            [DisplayName("Anti-Aliasing"), Category("General Video Settings")]
            public bool AntiAliasing { get; set; }

            [DisplayName("Shadow Quality"), Category("General Video Settings")]
            public double ShadowQuality { get; set; }

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
            public double ScreenspaceDynamicLightMaxCountOffset { get; set; }

            [DisplayName("Screenspace Dynamic Light Scale (Scale)"), Category("Render Settings")]
            public double ScreenspaceDynamicLightScaleScale { get; set; }

            [DisplayName("Screenspace Dynamic Light Scale (Offset)"), Category("Render Settings")]
            public double ScreenspaceDynamicLightScaleOffset { get; set; }

            [DisplayName("CPU Dynamic Light Max Count (Scale)"), Category("Render Settings")]
            public double CPUDynamicLightMaxCountScale { get; set; }

            [DisplayName("CPU Dynamic Light Max Count (Offset)"), Category("Render Settings")]
            public double CPUDynamicLightMaxCountOffset { get; set; }

            [DisplayName("CPU Dynamic Light Scale (Scale)"), Category("Render Settings")]
            public double CPUDynamicLightScaleScale { get; set; }

            [DisplayName("CPU Dynamic Light Scale (Offset)"), Category("Render Settings")]
            public double CPUDynamicLightScaleOffset { get; set; }

            [DisplayName("GPU Dynamic Light Max Count (Scale)"), Category("Render Settings")]
            public double GPUDynamicLightMaxCountScale { get; set; }

            [DisplayName("GPU Dynamic Light Max Count (Offset)"), Category("Render Settings")]
            public double GPUDynamicLightMaxCountOffset { get; set; }

            [DisplayName("GPU Dynamic Light Scale (Scale)"), Category("Render Settings")]
            public double GPUDynamicLightScaleScale { get; set; }

            [DisplayName("GPU Dynamic Light Scale (Offset)"), Category("Render Settings")]
            public double GPUDynamicLightScaleOffset { get; set; }

            [DisplayName("Shadow Generate Count (Scale)"), Category("Render Settings")]
            public double ShadowGenerateCountScale { get; set; }

            [DisplayName("Shadow Generate Count (Offset)"), Category("Render Settings")]
            public double ShadowGenerateCountOffset { get; set; }

            [DisplayName("Shadow Quality LOD (Scale)"), Category("Render Settings")]
            public double ShadowQualityLODScale { get; set; }

            [DisplayName("Shadow Quality LOD (Offset)"), Category("Render Settings")]
            public double ShadowQualityLODOffset { get; set; }

            [DisplayName("Disable Dynamic Lighting Shadows"), Category("Render Settings")]
            public bool DisableDynamicLightingShadows { get; set; }

            [DisplayName("Disable First-Person Shadow"), Category("Render Settings")]
            public bool DisableFirstPersonShadow { get; set; }

            [DisplayName("Effects LOD Distance Scale (Scale)"), Category("Render Settings")]
            public double EffectsLODDistanceScaleScale { get; set; }

            [DisplayName("Effects LOD Distance Scale (Offset)"), Category("Render Settings")]
            public double EffectsLODDistanceScaleOffset { get; set; }

            [DisplayName("Decal Fade Distance Scale (Scale)"), Category("Render Settings")]
            public double DecalFadeDistanceScaleScale { get; set; }

            [DisplayName("Decal Fade Distance Scale (Offset)"), Category("Render Settings")]
            public double DecalFadeDistanceScaleOffset { get; set; }

            [DisplayName("Disable Cheap Particles"), Category("Render Settings")]
            public bool DisableCheapParticles { get; set; }

            [DisplayName("Disable Patchy Fog"), Category("Render Settings")]
            public bool DisablePatchyFog { get; set; }

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

            H1Page.SelectedObject = CopyToGenericPropertyPage(data.Halo1);
            H2Page.SelectedObject = CopyToGenericPropertyPage(data.Halo2);
            H3Page.SelectedObject = CopyToGenericPropertyPage(data.Halo3);
            ODSTPage.SelectedObject = CopyToGenericPropertyPage(data.Halo3ODST);
            ReachPage.SelectedObject = CopyToGenericPropertyPage(data.HaloReach);
            H4Page.SelectedObject = CopyToGenericPropertyPage(data.Halo4);
            H2APage.SelectedObject = CopyToGenericPropertyPage(data.Halo2A);
        }

        private void WriteSystemSettingsData()
        {
            if (file == null) return;
            SystemSettingsData.Root data = new SystemSettingsData.Root();

            data.Halo1 = CopyFromGenericPropertyPage((GenericPropertyPage)H1Page.SelectedObject);
            data.Halo2 = CopyFromGenericPropertyPage((GenericPropertyPage)H2Page.SelectedObject);
            data.Halo3 = CopyFromGenericPropertyPage((GenericPropertyPage)H3Page.SelectedObject);
            data.Halo3ODST = CopyFromGenericPropertyPage((GenericPropertyPage)ODSTPage.SelectedObject);
            data.HaloReach = CopyFromGenericPropertyPage((GenericPropertyPage)ReachPage.SelectedObject);
            data.Halo4 = CopyFromGenericPropertyPage((GenericPropertyPage)H4Page.SelectedObject);
            data.Halo2A = CopyFromGenericPropertyPage((GenericPropertyPage)H2APage.SelectedObject);
            
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
                public double TextureResolution { get; set; }
                public double TextureFilteringQuality { get; set; }
                public double LightingQuality { get; set; }
                public double EffectsQuality { get; set; }
                public double ShadowQuality { get; set; }
                public double DetailsQuality { get; set; }
                public double PostProcessingQuality { get; set; }
                public bool AntiAliasing { get; set; }
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
                public double Offset { get; set; }
            }

            public class ScreenspaceDynamicLightScale
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class CPUDynamicLightMaxCount
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class CPUDynamicLightScale
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class GPUDynamicLightMaxCount
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class GPUDynamicLightScale
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
            }

            public class ShadowGenerateCount
            {
                public double Scale { get; set; }
                public double Offset { get; set; }
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

            public class RenderSettings
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

            public class GameData
            {
                public GeneralVideoSettings GeneralVideoSettings { get; set; }
                public RenderSettings RenderSettings { get; set; }
            }

            public class Root
            {
                [JsonProperty("GameData[Halo1]")]
                public GameData Halo1 { get; set; }

                [JsonProperty("GameData[Halo2]")]
                public GameData Halo2 { get; set; }

                [JsonProperty("GameData[Halo3]")]
                public GameData Halo3 { get; set; }

                [JsonProperty("GameData[Halo4]")]
                public GameData Halo4 { get; set; }

                [JsonProperty("GameData[Halo2A]")]
                public GameData Halo2A { get; set; }

                [JsonProperty("GameData[Halo3ODST]")]
                public GameData Halo3ODST { get; set; }

                [JsonProperty("GameData[HaloReach]")]
                public GameData HaloReach { get; set; }
            }

        }

    }
}
