// File: robjam1990/Psychosis/Models/CommandLine.cs
/*
 * Psychosis
 * A text-based game set in the world of Thear.
 * Copyright 2017-2024 robjam1990
 * @license MIT
 */

using System;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Psychosis.Scripts;

namespace Psychosis.Models
{
    public class CommandLine
    {
        // Function to check if KVM is supported
        public static bool CheckKvm(string psychosisBin)
        {
            string contents = "";

            try
            {
                contents = File.ReadAllText("/proc/cpuinfo");
            }
            catch (FileNotFoundException)
            {
                return false;
            }

            if (!Regex.IsMatch(contents, @"(vmx|svm|0xc0f)"))
                return false;

            // Checking if Psychosis has permissions to use KVM
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = psychosisBin,
                    Arguments = "-nographic",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Timeout = 1000
                }).WaitForExit();
            }
            catch (Exception)
            {
                return true;
            }
        }

        // Function to get platform details from arguments or latest link
        public static PlatformDetails GetPlatformDetails(string[] argv)
        {
            var args = ProcessArguments.Process(argv);
            string[] link = File.ReadLines("out/latest");
            string cpu_family = args.ContainsKey("cpu_family") ? args["cpu_family"] : link.Length >= 3 ? link[link.Length - 3] : null;
            string machine = args.ContainsKey("machine") ? args["machine"] : link.Length >= 2 ? link[link.Length - 2] : null;
            string platform = args.ContainsKey("platform") ? args["platform"] : link.Length >= 1 ? link[link.Length - 1] : null;
            return new PlatformDetails(cpu_family, machine, platform);
        }

        // Function to prepare default command line arguments
        public static string[] PrepareDefaultArguments()
        {
            return new string[]
            {
                "-machine", "default_machine",
                "-m", "256M",
                "-vga", "std",
                "-net", "nic",
                "-net", "user,id=eth0,hostfwd=tcp::50080-:80",
                "-net", "user,id=eth1,hostfwd=tcp::50443-:443"
            };
        }

        // Function to prepare command line arguments based on output option
        public static string[] PrepareOutputArguments(string output)
        {
            switch (output)
            {
                case "curses":
                    return new string[] { "-curses" };
                case "nographic":
                    return new string[] { "-nographic" };
                default:
                    return new string[0];
            }
        }

        // Function to prepare command line arguments based on platform
        public static string[] PreparePlatformArguments(string platform)
        {
            switch (platform)
            {
                case "disk":
                    return new string[] { "-hda", "disk.img" };
                case "img":
                    return new string[] { "-hda", "bootfs.img", "-hdb", "usersfs.img" };
                case "iso":
                    return new string[] { "-cdrom", "bootfs.iso", "-hda", "usersfs.img" };
                case "Psychosis":
                    string[] append = { "root=/dev/sda", "ip=dhcp" };
                    return new string[]
                    {
                        "--kernel", "kernel",
                        "--initrd", "initramfs.cpio.gz",
                        "-drive", $"file=usersfs.img,format=raw,index=0",
                        "-append", string.Join(" ", append)
                    };
                default:
                    return new string[0];
            }
        }

        // Function to prepare command line arguments
        public static CommandDetails PrepareCommandLine(string[] argv, string output)
        {
            PlatformDetails details = GetPlatformDetails(argv);
            string[] defaultArgs = PrepareDefaultArguments();
            string[] outputArgs = PrepareOutputArguments(output);
            string[] platformArgs = PreparePlatformArguments(details.Platform);
            string[] allArgs = new string[defaultArgs.Length + outputArgs.Length + platformArgs.Length];
            Array.Copy(defaultArgs, allArgs, defaultArgs.Length);
            Array.Copy(outputArgs, 0, allArgs, defaultArgs.Length, outputArgs.Length);
            Array.Copy(platformArgs, 0, allArgs, defaultArgs.Length + outputArgs.Length, platformArgs.Length);
            double timeout_rate = CheckKvm("Psychosis-system-" + details.CpuFamily) ? 0.1 : 1;
            string cwd = Path.Combine("out", details.CpuFamily, details.Machine, details.Platform);
            return new CommandDetails("Psychosis-system-" + details.CpuFamily, allArgs, cwd, details.Platform, timeout_rate);
        }
    }
}
