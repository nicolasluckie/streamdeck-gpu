using BarRaider.SdTools;
using BarRaider.SdTools.Wrappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenHardwareMonitor.Hardware;
using System;
using System.Drawing;
using System.Threading.Tasks;


namespace gpu {
    [PluginActionId("com.nicolasluckie.gpu.gpu")]
    public class PluginActionGPU : KeypadBase {

        // Create a computer object
        static Computer computer = new Computer() { CPUEnabled = true, GPUEnabled = true, MainboardEnabled = true, RAMEnabled = true, HDDEnabled = true };

        private class PluginSettings {
            public static PluginSettings CreateDefaultSettings() {
                PluginSettings instance = new PluginSettings {
                    OutputFileName = String.Empty,
                    InputString = String.Empty
                };
                return instance;
            }

            [FilenameProperty]
            [JsonProperty(PropertyName = "outputFileName")]
            public string OutputFileName { get; set; }

            [JsonProperty(PropertyName = "inputString")]
            public string InputString { get; set; }
        }

        private readonly PluginSettings settings;

        /// <summary>
        /// 1. Initialize PluginActionGPU and settings
        /// 2. Subscribe to various events
        /// 3. Open the computer object to start monitoring hardware components
        /// </summary>
        /// <param name="connection">The connection to Stream Deck.</param>
        /// <param name="payload">The initial payload.</param>
        public PluginActionGPU(ISDConnection connection, InitialPayload payload) : base(connection, payload) {
            if (payload.Settings == null || payload.Settings.Count == 0) {
                this.settings = PluginSettings.CreateDefaultSettings();
            }
            else {
                this.settings = payload.Settings.ToObject<PluginSettings>();
            }

            Connection.OnApplicationDidLaunch += Connection_OnApplicationDidLaunch;
            Connection.OnApplicationDidTerminate += Connection_OnApplicationDidTerminate;
            Connection.OnDeviceDidConnect += Connection_OnDeviceDidConnect;
            Connection.OnDeviceDidDisconnect += Connection_OnDeviceDidDisconnect;
            Connection.OnPropertyInspectorDidAppear += Connection_OnPropertyInspectorDidAppear;
            Connection.OnPropertyInspectorDidDisappear += Connection_OnPropertyInspectorDidDisappear;
            Connection.OnSendToPlugin += Connection_OnSendToPlugin;
            Connection.OnTitleParametersDidChange += Connection_OnTitleParametersDidChange;
            computer.Open();
        }

        private void Connection_OnTitleParametersDidChange(object sender, BarRaider.SdTools.Wrappers.SDEventReceivedEventArgs<BarRaider.SdTools.Events.TitleParametersDidChange> e) {
        }

        private void Connection_OnSendToPlugin(object sender, BarRaider.SdTools.Wrappers.SDEventReceivedEventArgs<BarRaider.SdTools.Events.SendToPlugin> e) {
        }

        private void Connection_OnPropertyInspectorDidDisappear(object sender, BarRaider.SdTools.Wrappers.SDEventReceivedEventArgs<BarRaider.SdTools.Events.PropertyInspectorDidDisappear> e) {
        }

        private void Connection_OnPropertyInspectorDidAppear(object sender, BarRaider.SdTools.Wrappers.SDEventReceivedEventArgs<BarRaider.SdTools.Events.PropertyInspectorDidAppear> e) {
        }

        private void Connection_OnDeviceDidDisconnect(object sender, BarRaider.SdTools.Wrappers.SDEventReceivedEventArgs<BarRaider.SdTools.Events.DeviceDidDisconnect> e) {
        }

        private void Connection_OnDeviceDidConnect(object sender, BarRaider.SdTools.Wrappers.SDEventReceivedEventArgs<BarRaider.SdTools.Events.DeviceDidConnect> e) {
        }

        private void Connection_OnApplicationDidTerminate(object sender, BarRaider.SdTools.Wrappers.SDEventReceivedEventArgs<BarRaider.SdTools.Events.ApplicationDidTerminate> e) {
        }

        private void Connection_OnApplicationDidLaunch(object sender, BarRaider.SdTools.Wrappers.SDEventReceivedEventArgs<BarRaider.SdTools.Events.ApplicationDidLaunch> e) {
        }


        /// <summary>
        /// 1. Close the computer object to stop monitoring hardware components
        /// 2. Free and release resources
        /// </summary>
        public override void Dispose() {
            computer.Close();
            Connection.OnApplicationDidLaunch -= Connection_OnApplicationDidLaunch;
            Connection.OnApplicationDidTerminate -= Connection_OnApplicationDidTerminate;
            Connection.OnDeviceDidConnect -= Connection_OnDeviceDidConnect;
            Connection.OnDeviceDidDisconnect -= Connection_OnDeviceDidDisconnect;
            Connection.OnPropertyInspectorDidAppear -= Connection_OnPropertyInspectorDidAppear;
            Connection.OnPropertyInspectorDidDisappear -= Connection_OnPropertyInspectorDidDisappear;
            Connection.OnSendToPlugin -= Connection_OnSendToPlugin;
            Connection.OnTitleParametersDidChange -= Connection_OnTitleParametersDidChange;
            Logger.Instance.LogMessage(TracingLevel.INFO, $"Destructor called");
        }

        public async override void KeyPressed(KeyPayload payload) {
            //Logger.Instance.LogMessage(TracingLevel.INFO, "Key Pressed");
            //TitleParameters tp = new TitleParameters(new FontFamily("Arial"), FontStyle.Bold, 20, Color.White, true, TitleVerticalAlignment.Middle);
            //using (Image image = Tools.GenerateGenericKeyImage(out Graphics graphics)) {
            //    graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, image.Width, image.Height);
            //    graphics.AddTextPath(tp, image.Height, image.Width, "Test");
            //    graphics.Dispose();

            //    await Connection.SetImageAsync(image);
            //}
        }

        public async override void KeyReleased(KeyPayload payload) {
            //TitleParameters tp = new TitleParameters(new FontFamily("Arial"), FontStyle.Bold, 20, Color.White, true, TitleVerticalAlignment.Middle);
            //using (Image image = Tools.GenerateGenericKeyImage(out Graphics graphics)) {
            //    graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, image.Width, image.Height);
            //    graphics.AddTextPath(tp, image.Height, image.Width, "Test", Color.Black, 7);
            //    graphics.Dispose();

            //    await Connection.SetImageAsync(image);
            //}
        }


        /// <summary>
        /// 1. Updates the hardware components
        /// 2. Retrieves the GPU temperature
        /// 3. Draws the temperature % on the key
        /// 
        /// This function is called every second by the Stream Deck software.
        /// It is not called if the plugin is not visible.
        /// </summary>
        public async override void OnTick() {
            // Update all the hardware components to get accurate readings
            foreach (IHardware hardware in computer.Hardware) {
                hardware.Update();
            }

            // Get the GPU load %
            int gpuTemp;
            gpuTemp = (int)Math.Round(computer.Hardware[3].Sensors[0].Value ?? 0.0);

            TitleParameters tp = new TitleParameters(new FontFamily("Arial"), FontStyle.Bold, 24, Color.White, true, TitleVerticalAlignment.Middle);
            using (Image image = Tools.GenerateGenericKeyImage(out Graphics graphics)) {
                graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, image.Width, image.Height);
                Image img = Image.FromFile("Images/wood-bg.png");
                graphics.DrawImage(img, 0, 0, img.Width, img.Height);
                graphics.AddTextPath(tp, image.Height, image.Width, gpuTemp + "°C", Color.Black, 7);
                graphics.Dispose();

                await Connection.SetImageAsync(image);
            }
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload) {
            Tools.AutoPopulateSettings(settings, payload.Settings);
            SaveSettings();
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload) { }

        private Task SaveSettings() {
            return Connection.SetSettingsAsync(JObject.FromObject(settings));
        }
    }
}