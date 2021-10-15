using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Hardware.Info.Net5;
using System.Threading.Tasks;

namespace Hardware.Info.Benchmark
{
    public class Benchmarks
    {
        readonly IHardwareInfo hardwareInfo = new HardwareInfo();

        [Benchmark]
        public void RefreshMemoryStatus() => hardwareInfo.RefreshMemoryStatus();
        [Benchmark]
        public void RefreshBatteryList() => hardwareInfo.RefreshBatteryList();
        [Benchmark]
        public void RefreshBIOSList() => hardwareInfo.RefreshBIOSList();
        [Benchmark]
        public void RefreshCPUList() => hardwareInfo.RefreshCPUList();
        [Benchmark]
        public void RefreshDriveList() => hardwareInfo.RefreshDriveList();
        [Benchmark]
        public void RefreshKeyboardList() => hardwareInfo.RefreshKeyboardList();
        [Benchmark]
        public void RefreshMemoryList() => hardwareInfo.RefreshMemoryList();
        [Benchmark]
        public void RefreshMonitorList() => hardwareInfo.RefreshMonitorList();


        [Benchmark]
        public void RefreshMotherboardList() => hardwareInfo.RefreshMotherboardList();
        [Benchmark]
        public void RefreshMouseList() => hardwareInfo.RefreshMouseList();
        [Benchmark]
        public void RefreshNetworkAdapterList() => hardwareInfo.RefreshNetworkAdapterList();
        [Benchmark]
        public void RefreshPrinterList() => hardwareInfo.RefreshPrinterList();
        [Benchmark]
        public void RefreshSoundDeviceList() => hardwareInfo.RefreshSoundDeviceList();
        [Benchmark]
        public void RefreshVideoControllerList() => hardwareInfo.RefreshVideoControllerList();

        [Benchmark]
        public async Task RefreshMemoryStatusAsync() => await hardwareInfo.RefreshMemoryStatusAsync();
        [Benchmark]
        public async Task RefreshBatteryListAsync() => await hardwareInfo.RefreshBatteryListAsync();
        [Benchmark]
        public async Task RefreshBIOSListAsync() => await hardwareInfo.RefreshBIOSListAsync();
        [Benchmark]
        public async Task RefreshCPUListAsync() => await hardwareInfo.RefreshCPUListAsync();
        [Benchmark]
        public async Task RefreshDriveListAsync() => await hardwareInfo.RefreshDriveListAsync();
        [Benchmark]
        public async Task RefreshKeyboardListAsync() => await hardwareInfo.RefreshKeyboardListAsync();
        [Benchmark]
        public async Task RefreshMemoryListAsync() => await hardwareInfo.RefreshMemoryListAsync();
        [Benchmark]
        public async Task RefreshMonitorListAsync() => await hardwareInfo.RefreshMonitorListAsync();
        [Benchmark]
        public async Task RefreshMotherboardListAsync() => await hardwareInfo.RefreshMotherboardListAsync();
        [Benchmark]
        public async Task RefreshMouseListAsync() => await hardwareInfo.RefreshMouseListAsync();
        [Benchmark]
        public async Task RefreshNetworkAdapterListAsync() => await hardwareInfo.RefreshNetworkAdapterListAsync();
        [Benchmark]
        public async Task RefreshPrinterListAsync() => await hardwareInfo.RefreshPrinterListAsync();
        [Benchmark]
        public async Task RefreshSoundDeviceListAsync() => await hardwareInfo.RefreshSoundDeviceListAsync();
        [Benchmark]
        public async Task RefreshVideoControllerListAsync() => await hardwareInfo.RefreshVideoControllerListAsync();
    }

    class Program
    {
        static void Main(string[] _)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
