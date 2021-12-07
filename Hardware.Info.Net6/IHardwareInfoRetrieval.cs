using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hardware.Info.Net6
{
    internal interface IHardwareInfoRetrieval
    {
        MemoryStatus GetMemoryStatus();
        List<Battery> GetBatteryList();
        List<BIOS> GetBiosList();
        List<CPU> GetCpuList(bool includePercentProcessorTime = true);
        List<Drive> GetDriveList();
        List<Keyboard> GetKeyboardList();
        List<Memory> GetMemoryList();
        List<Monitor> GetMonitorList();
        List<Motherboard> GetMotherboardList();
        List<Mouse> GetMouseList();
        List<NetworkAdapter> GetNetworkAdapterList(bool includeBytesPersec = true, bool includeNetworkAdapterConfiguration = true);
        List<Printer> GetPrinterList();
        List<SoundDevice> GetSoundDeviceList();
        List<VideoController> GetVideoControllerList();

        Task<MemoryStatus> GetMemoryStatusAsync();
        Task<List<Battery>> GetBatteryListAsync();
        Task<List<BIOS>> GetBiosListAsync();
        Task<List<CPU>> GetCpuListAsync(bool includePercentProcessorTime = true);
        Task<List<Drive>> GetDriveListAsync();
        Task<List<Keyboard>> GetKeyboardListAsync();
        Task<List<Memory>> GetMemoryListAsync();
        Task<List<Monitor>> GetMonitorListAsync();
        Task<List<Motherboard>> GetMotherboardListAsync();
        Task<List<Mouse>> GetMouseListAsync();
        Task<List<NetworkAdapter>> GetNetworkAdapterListAsync(bool includeBytesPersec = true, bool includeNetworkAdapterConfiguration = true);
        Task<List<Printer>> GetPrinterListAsync();
        Task<List<SoundDevice>> GetSoundDeviceListAsync();
        Task<List<VideoController>> GetVideoControllerListAsync();

        Task<List<LinuxVolume>> GetDriveList2Async();
    }
}
