﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;

namespace Hardware.Info.Test
{
    // https://stackoverflow.com/a/49597492/4675770
    // https://stackoverflow.com/questions/55376313/class-performancecounter-documentation
    // https://stackoverflow.com/questions/23366831/c-sharp-performancecounter-list-of-possible-parameters

    class Program
    {
        static readonly HardwareInfo hardwareInfo = new HardwareInfo();

        static void Main(string[] _)
        {
            hardwareInfo.RefreshAll();

            Console.WriteLine(hardwareInfo.MemoryStatus);

            foreach (var hardware in hardwareInfo.BatteryList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.BiosList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.CpuList)
                Console.WriteLine(hardware);

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

            Console.ReadLine();

            foreach (var hardware in hardwareInfo.KeyboardList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.MemoryList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.MonitorList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.MotherboardList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.MouseList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.NetworkAdapterList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.PrinterList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.SoundDeviceList)
                Console.WriteLine(hardware);

            foreach (var hardware in hardwareInfo.VideoControllerList)
                Console.WriteLine(hardware);

            Console.ReadLine();

            foreach (var address in HardwareInfo.GetLocalIPv4Address())
                Console.WriteLine(address);

            Console.ReadLine();
        }
    }
}
