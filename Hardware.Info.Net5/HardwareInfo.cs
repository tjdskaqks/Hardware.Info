using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Hardware.Info.Net5
{
    public class HardwareInfo : IHardwareInfo
    {
        public MemoryStatus MemoryStatus { get; private set; } = new MemoryStatus();
        public List<Battery> BatteryList { get; private set; } = new List<Battery>();
        public List<BIOS> BiosList { get; private set; } = new List<BIOS>();
        public List<CPU> CpuList { get; private set; } = new List<CPU>();
        public List<Drive> DriveList { get; private set; } = new List<Drive>();
        public List<LinuxVolume> LinuxDriveList { get; private set; } = new();
        public List<Keyboard> KeyboardList { get; private set; } = new List<Keyboard>();
        public List<Memory> MemoryList { get; private set; } = new List<Memory>();
        public List<Monitor> MonitorList { get; private set; } = new List<Monitor>();
        public List<Motherboard> MotherboardList { get; private set; } = new List<Motherboard>();
        public List<Mouse> MouseList { get; private set; } = new List<Mouse>();
        public List<NetworkAdapter> NetworkAdapterList { get; private set; } = new List<NetworkAdapter>();
        public List<Printer> PrinterList { get; private set; } = new List<Printer>();
        public List<SoundDevice> SoundDeviceList { get; private set; } = new List<SoundDevice>();
        public List<VideoController> VideoControllerList { get; private set; } = new List<VideoController>();

        private readonly IHardwareInfoRetrieval _hardwareInfoRetrieval = null!;

        public HardwareInfo(bool useAsteriskInWMI = true, TimeSpan? timeoutInWMI = null)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                _hardwareInfoRetrieval = new Hardware.Info.Net5.Windows.HardwareInfoRetrieval(timeoutInWMI) { UseAsteriskInWMI = useAsteriskInWMI };
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) // Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                _hardwareInfoRetrieval = new Hardware.Info.Net5.Mac.HardwareInfoRetrieval();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) // Environment.OSVersion.Platform == PlatformID.Unix)
            {
                _hardwareInfoRetrieval = new Hardware.Info.Net5.Linux.HardwareInfoRetrieval();
            }
        }

        public void RefreshAll()
        {
            RefreshMemoryStatus();

            RefreshBatteryList();
            RefreshBIOSList();
            RefreshCPUList();
            RefreshDriveList();
            RefreshKeyboardList();
            RefreshMemoryList();
            RefreshMonitorList();
            RefreshMotherboardList();
            RefreshMouseList();
            RefreshNetworkAdapterList();
            RefreshPrinterList();
            RefreshSoundDeviceList();
            RefreshVideoControllerList();
        }

        public void RefreshMemoryStatus() => MemoryStatus = _hardwareInfoRetrieval.GetMemoryStatus();
        public void RefreshBatteryList() => BatteryList = _hardwareInfoRetrieval.GetBatteryList();
        public void RefreshBIOSList() => BiosList = _hardwareInfoRetrieval.GetBiosList();
        public void RefreshCPUList(bool includePercentProcessorTime = true) => CpuList = _hardwareInfoRetrieval.GetCpuList(includePercentProcessorTime);
        public void RefreshDriveList() => DriveList = _hardwareInfoRetrieval.GetDriveList();
        public void RefreshKeyboardList() => KeyboardList = _hardwareInfoRetrieval.GetKeyboardList();
        public void RefreshMemoryList() => MemoryList = _hardwareInfoRetrieval.GetMemoryList();
        public void RefreshMonitorList() => MonitorList = _hardwareInfoRetrieval.GetMonitorList();
        public void RefreshMotherboardList() => MotherboardList = _hardwareInfoRetrieval.GetMotherboardList();
        public void RefreshMouseList() => MouseList = _hardwareInfoRetrieval.GetMouseList();
        public void RefreshNetworkAdapterList(bool includeBytesPerSec = true, bool includeNetworkAdapterConfiguration = true) => NetworkAdapterList = _hardwareInfoRetrieval.GetNetworkAdapterList(includeBytesPerSec, includeNetworkAdapterConfiguration);
        public void RefreshPrinterList() => PrinterList = _hardwareInfoRetrieval.GetPrinterList();
        public void RefreshSoundDeviceList() => SoundDeviceList = _hardwareInfoRetrieval.GetSoundDeviceList();
        public void RefreshVideoControllerList() => VideoControllerList = _hardwareInfoRetrieval.GetVideoControllerList();

        public async void RefreshAllAsync()
        {
            await RefreshMemoryStatusAsync();

            await RefreshBatteryListAsync();
            await RefreshBIOSListAsync();
            await RefreshCPUListAsync();
            await RefreshDriveListAsync();
            await RefreshKeyboardListAsync();
            await RefreshMemoryListAsync();
            await RefreshMonitorListAsync();
            await RefreshMotherboardListAsync();
            await RefreshMouseListAsync();
            await RefreshNetworkAdapterListAsync();
            await RefreshPrinterListAsync();
            await RefreshSoundDeviceListAsync();
            await RefreshVideoControllerListAsync();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                await RefreshDriveList2Async();
            }
        }

        public async Task RefreshMemoryStatusAsync() => MemoryStatus = await _hardwareInfoRetrieval.GetMemoryStatusAsync();
        public async Task RefreshBatteryListAsync() => BatteryList = await _hardwareInfoRetrieval.GetBatteryListAsync();
        public async Task RefreshBIOSListAsync() => BiosList = await _hardwareInfoRetrieval.GetBiosListAsync();
        public async Task RefreshCPUListAsync(bool includePercentProcessorTime = true) => CpuList = await _hardwareInfoRetrieval.GetCpuListAsync(includePercentProcessorTime);
        public async Task RefreshDriveListAsync() => DriveList = await _hardwareInfoRetrieval.GetDriveListAsync();
        public async Task RefreshKeyboardListAsync() => KeyboardList = await _hardwareInfoRetrieval.GetKeyboardListAsync();
        public async Task RefreshMemoryListAsync() => MemoryList = await _hardwareInfoRetrieval.GetMemoryListAsync();
        public async Task RefreshMonitorListAsync() => MonitorList = await _hardwareInfoRetrieval.GetMonitorListAsync();
        public async Task RefreshMotherboardListAsync() => MotherboardList = await _hardwareInfoRetrieval.GetMotherboardListAsync();
        public async Task RefreshMouseListAsync() => MouseList = await _hardwareInfoRetrieval.GetMouseListAsync();
        public async Task RefreshNetworkAdapterListAsync(bool includeBytesPerSec = true, bool includeNetworkAdapterConfiguration = true) => NetworkAdapterList = await _hardwareInfoRetrieval.GetNetworkAdapterListAsync(includeBytesPerSec, includeNetworkAdapterConfiguration);
        public async Task RefreshPrinterListAsync() => PrinterList = await _hardwareInfoRetrieval.GetPrinterListAsync();
        public async Task RefreshSoundDeviceListAsync() => SoundDeviceList = await _hardwareInfoRetrieval.GetSoundDeviceListAsync();
        public async Task RefreshVideoControllerListAsync() => VideoControllerList = await _hardwareInfoRetrieval.GetVideoControllerListAsync();
        public async Task RefreshDriveList2Async() => LinuxDriveList = await _hardwareInfoRetrieval.GetDriveList2Async();


        #region Static

        private static bool _pingInProgress;
        private static Action<bool>? _onPingComplete;

        public static async Task<PingReply> PingAsync(string hostNameOrAddress, Action<bool> onPingComplete)
        {
            if (_pingInProgress)
                return null;

            _pingInProgress = true;

            _onPingComplete = onPingComplete;

            using Ping pingSender = new Ping();
            pingSender.PingCompleted += new PingCompletedEventHandler(PingCompleted);

            byte[] buffer = Enumerable.Repeat<byte>(97, 32).ToArray();

            int timeout = 12000;

            return await pingSender.SendPingAsync(hostNameOrAddress, timeout, buffer, new(64, true));
        }

        private static void PingCompleted(object sender, PingCompletedEventArgs e)
        {
            _pingInProgress = false;

            bool success = true;

            if (e.Cancelled)
                success = false;

            if (e.Error != null)
                success = false;

            PingReply reply = e.Reply;

            if (reply == null)
                success = false;
            else if (reply.Status != IPStatus.Success)
                success = false;

            _onPingComplete?.Invoke(success);
        }

        public static IEnumerable<IPAddress> GetLocalIPv4Addresses()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return NetworkInterface.GetAllNetworkInterfaces()
                                   .SelectMany(networkInterface => networkInterface.GetIPProperties().UnicastAddresses)
                                   .Where(addressInformation => addressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                                   .Select(addressInformation => addressInformation.Address);
            }
            else
            {
                return Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            }
        }

        public static IEnumerable<IPAddress> GetLocalIPv4Addresses(NetworkInterfaceType networkInterfaceType)
        {
            return NetworkInterface.GetAllNetworkInterfaces()
                                   .Where(networkInterface => networkInterface.NetworkInterfaceType == networkInterfaceType)
                                   .SelectMany(networkInterface => networkInterface.GetIPProperties().UnicastAddresses)
                                   .Where(addressInformation => addressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                                   .Select(addressInformation => addressInformation.Address);
        }

        public static IEnumerable<IPAddress> GetLocalIPv4Addresses(OperationalStatus operationalStatus)
        {
            return NetworkInterface.GetAllNetworkInterfaces()
                                   .Where(networkInterface => networkInterface.OperationalStatus == operationalStatus)
                                   .SelectMany(networkInterface => networkInterface.GetIPProperties().UnicastAddresses)
                                   .Where(addressInformation => addressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                                   .Select(addressInformation => addressInformation.Address);
        }

        public static IEnumerable<IPAddress> GetLocalIPv4Addresses(NetworkInterfaceType networkInterfaceType, OperationalStatus operationalStatus)
        {
            return NetworkInterface.GetAllNetworkInterfaces()
                                   .Where(networkInterface => networkInterface.NetworkInterfaceType == networkInterfaceType && networkInterface.OperationalStatus == operationalStatus)
                                   .SelectMany(networkInterface => networkInterface.GetIPProperties().UnicastAddresses)
                                   .Where(addressInformation => addressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                                   .Select(addressInformation => addressInformation.Address);
        }

        #endregion
    }
}
