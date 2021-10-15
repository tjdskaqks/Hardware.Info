using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hardware.Info.Net5
{
    public interface IHardwareInfo
    {
        MemoryStatus MemoryStatus { get; }
        List<Battery> BatteryList { get; }
        List<BIOS> BiosList { get; }
        List<CPU> CpuList { get; }
        List<Drive> DriveList { get; }
        List<Keyboard> KeyboardList { get; }
        List<Memory> MemoryList { get; }
        List<Monitor> MonitorList { get; }
        List<Motherboard> MotherboardList { get; }
        List<Mouse> MouseList { get; }
        List<NetworkAdapter> NetworkAdapterList { get; }
        List<Printer> PrinterList { get; }
        List<SoundDevice> SoundDeviceList { get; }
        List<VideoController> VideoControllerList { get; }
        List<LinuxVolume> LinuxDriveList { get; }

        void RefreshAll();
        void RefreshMemoryStatus();
        void RefreshBatteryList();
        void RefreshBIOSList();
        void RefreshCPUList(bool includePercentProcessorTime = true);
        void RefreshDriveList();
        void RefreshKeyboardList();
        void RefreshMemoryList();
        void RefreshMonitorList();
        void RefreshMotherboardList();
        void RefreshMouseList();
        void RefreshNetworkAdapterList(bool includeBytesPerSec = true, bool includeNetworkAdapterConfiguration = true);
        void RefreshPrinterList();
        void RefreshSoundDeviceList();
        void RefreshVideoControllerList();

        void RefreshAllAsync();
        Task RefreshMemoryStatusAsync();
        Task RefreshBatteryListAsync();
        Task RefreshBIOSListAsync();
        Task RefreshCPUListAsync(bool includePercentProcessorTime = true);
        Task RefreshDriveListAsync();
        Task RefreshKeyboardListAsync();
        Task RefreshMemoryListAsync();
        Task RefreshMonitorListAsync();
        Task RefreshMotherboardListAsync();
        Task RefreshMouseListAsync();
        Task RefreshNetworkAdapterListAsync(bool includeBytesPerSec = true, bool includeNetworkAdapterConfiguration = true);
        Task RefreshPrinterListAsync();
        Task RefreshSoundDeviceListAsync();
        Task RefreshVideoControllerListAsync();
        Task RefreshDriveList2Async();
    }
}