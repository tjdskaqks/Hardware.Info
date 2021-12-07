using Hardware.Info.Net6;
using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Hardware.Info.Test
{
    class Program
    {
        static readonly IHardwareInfo hardwareInfo = new HardwareInfo(useAsteriskInWMI: false);

        //static void Main(string[] _)
        //{
        //    hardwareInfo.RefreshMemoryStatus();
        //    hardwareInfo.RefreshBatteryList();
        //    hardwareInfo.RefreshBIOSList();
        //    hardwareInfo.RefreshCPUList(includePercentProcessorTime: true);
        //    hardwareInfo.RefreshDriveList();
        //    hardwareInfo.RefreshKeyboardList();
        //    hardwareInfo.RefreshMemoryList();
        //    hardwareInfo.RefreshMonitorList();
        //    hardwareInfo.RefreshMotherboardList();
        //    hardwareInfo.RefreshMouseList();
        //    hardwareInfo.RefreshNetworkAdapterList(includeBytesPerSec: true, includeNetworkAdapterConfiguration: true);
        //    hardwareInfo.RefreshPrinterList();
        //    hardwareInfo.RefreshSoundDeviceList();
        //    hardwareInfo.RefreshVideoControllerList();

        //    //hardwareInfo.RefreshAll();

        //    Console.WriteLine(hardwareInfo.MemoryStatus);

        //    //foreach (var hardware in hardwareInfo.BatteryList)
        //    //    Console.WriteLine(hardware);

        //    foreach (var hardware in hardwareInfo.BiosList)
        //        Console.WriteLine(hardware);

        //    foreach (var cpu in hardwareInfo.CpuList)
        //    {
        //        Console.WriteLine(cpu);

        //        foreach (var cpuCore in cpu.CpuCoreList)
        //            Console.WriteLine(cpuCore);
        //    }

        //    //Console.ReadLine();

        //    foreach (var drive in hardwareInfo.DriveList)
        //    {
        //        Console.WriteLine(drive);

        //        foreach (var partition in drive.PartitionList)
        //        {
        //            Console.WriteLine(partition);

        //            foreach (var volume in partition.VolumeList)
        //                Console.WriteLine(volume);
        //        }
        //    }

        //    //Console.ReadLine();

        //    //foreach (var hardware in hardwareInfo.KeyboardList)
        //    //    Console.WriteLine(hardware);

        //    foreach (var hardware in hardwareInfo.MemoryList)
        //        Console.WriteLine(hardware);

        //    foreach (var hardware in hardwareInfo.MonitorList)
        //        Console.WriteLine(hardware);

        //    foreach (var hardware in hardwareInfo.MotherboardList)
        //        Console.WriteLine(hardware);

        //    //foreach (var hardware in hardwareInfo.MouseList)
        //    //    Console.WriteLine(hardware);

        //    foreach (var hardware in hardwareInfo.NetworkAdapterList)
        //        Console.WriteLine(hardware);

        //    //foreach (var hardware in hardwareInfo.PrinterList)
        //    //    Console.WriteLine(hardware);

        //    foreach (var hardware in hardwareInfo.SoundDeviceList)
        //        Console.WriteLine(hardware);

        //    foreach (var hardware in hardwareInfo.VideoControllerList)
        //        Console.WriteLine(hardware);

        //    //Console.ReadLine();

        //    foreach (var address in HardwareInfo.GetLocalIPv4Addresses(NetworkInterfaceType.Ethernet, OperationalStatus.Up))
        //        Console.WriteLine(address);

        //    Console.WriteLine();

        //    foreach (var address in HardwareInfo.GetLocalIPv4Addresses(NetworkInterfaceType.Wireless80211))
        //        Console.WriteLine(address);

        //    Console.WriteLine();

        //    //foreach (var address in HardwareInfo.GetLocalIPv4Addresses(OperationalStatus.Up))
        //    //    Console.WriteLine(address);

        //    //Console.WriteLine();

        //    foreach (var address in HardwareInfo.GetLocalIPv4Addresses())
        //        Console.WriteLine(address);

        //    Console.ReadLine();
        //}

        static async Task Main(string[] _)
        {
            await hardwareInfo.RefreshMemoryStatusAsync();
            await hardwareInfo.RefreshBatteryListAsync();
            await hardwareInfo.RefreshBIOSListAsync();
            await hardwareInfo.RefreshCPUListAsync(includePercentProcessorTime: true);
            await hardwareInfo.RefreshDriveListAsync();
            await hardwareInfo.RefreshKeyboardListAsync();
            await hardwareInfo.RefreshMemoryListAsync();
            await hardwareInfo.RefreshMonitorListAsync();
            await hardwareInfo.RefreshMotherboardListAsync();
            await hardwareInfo.RefreshMouseListAsync();
            await hardwareInfo.RefreshNetworkAdapterListAsync(includeBytesPerSec: true, includeNetworkAdapterConfiguration: true);
            await hardwareInfo.RefreshPrinterListAsync();
            await hardwareInfo.RefreshSoundDeviceListAsync();
            await hardwareInfo.RefreshVideoControllerListAsync();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) // Environment.OSVersion.Platform == PlatformID.Unix)
            {
                await hardwareInfo.RefreshDriveList2Async();
            }
            
            //hardwareInfo.RefreshAll();

            Console.WriteLine(hardwareInfo.MemoryStatus);

            //foreach (var hardware in hardwareInfo.BatteryList)
            //    Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.BiosList)
                Console.WriteLine(hardware);

            foreach (var cpu in hardwareInfo.CpuList)
            {
                Console.WriteLine(cpu);

                foreach (var cpuCore in cpu.CpuCoreList)
                    Console.WriteLine(cpuCore);
            }

            //Console.ReadLine();

            foreach (var drive in hardwareInfo.DriveList)
            {
                Console.WriteLine(drive);

                foreach (var partition in drive.PartitionList)
                {
                    Console.WriteLine(partition);

                    foreach (var volume in partition.VolumeList)
                        Console.WriteLine(volume);
                }
            }

            foreach (var LinuxDrive in hardwareInfo.LinuxDriveList)
                Console.WriteLine(LinuxDrive);
            //Console.ReadLine();

            //foreach (var hardware in hardwareInfo.KeyboardList)
            //    Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.MemoryList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.MonitorList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.MotherboardList)
                Console.WriteLine(hardware);

            //foreach (var hardware in hardwareInfo.MouseList)
            //    Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.NetworkAdapterList)
                Console.WriteLine(hardware);

            //foreach (var hardware in hardwareInfo.PrinterList)
            //    Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.SoundDeviceList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.VideoControllerList)
                Console.WriteLine(hardware);

            //Console.ReadLine();

            foreach (var address in HardwareInfo.GetLocalIPv4Addresses(NetworkInterfaceType.Ethernet, OperationalStatus.Up))
                Console.WriteLine(address);

            Console.WriteLine();

            foreach (var address in HardwareInfo.GetLocalIPv4Addresses(NetworkInterfaceType.Wireless80211))
                Console.WriteLine(address);

            Console.WriteLine();

            //foreach (var address in HardwareInfo.GetLocalIPv4Addresses(OperationalStatus.Up))
            //    Console.WriteLine(address);

            //Console.WriteLine();

            foreach (var address in HardwareInfo.GetLocalIPv4Addresses())
                Console.WriteLine(address);

            Console.ReadLine();
        }
    }
}

