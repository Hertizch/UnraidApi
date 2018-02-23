using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnraidApi;

namespace TestApp
{
    class Program
    {
        private static long _totalSize = 0;
        private static long _totalFree = 0;
        private static long _totalUsed = 0;

        static void Main(string[] args)
        {
            DoWork();
            Console.ReadKey();
        }

        public static async void DoWork()
        {
            await DoWorkAsync();
        }

        public static async Task DoWorkAsync()
        {
            var username = File.ReadAllText(@"C:\unraidapi\username.txt");
            var password = File.ReadAllText(@"C:\unraidapi\password.txt");
            var redirectUrl = File.ReadAllText(@"C:\unraidapi\redirectUrl.txt");

            var unraidApiClient = new UnraidApiClient("192.168.1.250", username, password, 22, true, redirectUrl);

            /*
             * SYSTEM INFO
             */
            Console.WriteLine($"\nSYSTEM INFO:");
            var systemInfo = await unraidApiClient.SystemInfoClient.GetSystemInfo();
            Console.WriteLine($"Server: {systemInfo.Identification.ServerName} ({systemInfo.Identification.Description})");
            Console.WriteLine($"{systemInfo.Registration.LicenseKey} license - Registered to: {systemInfo.Registration.RegTo} at {systemInfo.Registration.RegTm}");


            /*
             * DISKS
             */
            Console.WriteLine($"\nDISKS:");
            var disks = await unraidApiClient.DiskClient.GetDisks(false, true, true);
            foreach (var disk in disks)
            {
                _totalSize += disk.FileSystem.Size; // add to total
                _totalFree += disk.FileSystem.SizeFree; // add to total
                _totalUsed += disk.FileSystem.SizeUsed; // add to total
                Console.WriteLine($"{disk.PowerState}\t {disk.Name.ToUpper()}:\t {disk.Id} {disk.Device} - {FormatKiloBytes(disk.FileSystem.SizeFree)} of {FormatKiloBytes(disk.FileSystem.Size)} ({disk.FileSystem.SizeUsedPercentage}%) Temp: {disk.Temp}");
            }
            Console.WriteLine($"Array size:\t {FormatKiloBytes(_totalSize)} - Used: {FormatKiloBytes(_totalUsed)} - Free: {FormatKiloBytes(_totalFree)}");


            /*
             * DOCKERS
             */
            Console.WriteLine($"\nDOCKERS:");
            var dockers = await unraidApiClient.DockerClient.GetDockers();
            foreach(var docker in dockers)
                Console.WriteLine($"({(docker.Running ? "Running" : "Stopped")})\t {docker.Name}");

            unraidApiClient.Disconnect();
        }

        private static string FormatKiloBytes(long kiloBytes)
        {
            string[] Suffix = { "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = kiloBytes;
            for (i = 0; i < Suffix.Length && kiloBytes >= 1024; i++, kiloBytes /= 1024)
                dblSByte = kiloBytes / 1024.0;

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }
    }
}
