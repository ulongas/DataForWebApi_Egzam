using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace SendToWebAPI.Models
{
    public class DataManager
    {

        public double GetCpuUsage()
        {
            double cpuUsage = GetWmiValue("Win32_PerfFormattedData_PerfOS_Processor", "PercentProcessorTime");
            return cpuUsage;
        }

        // gets total ram used 
        public double GetRamUsage()
        {
            double totalMemorySize = GetWmiValue("Win32_OperatingSystem", "TotalVisibleMemorySize");
            double freeMemory = GetWmiValue("Win32_OperatingSystem", "FreePhysicalMemory");
            double usedMemoryKB = totalMemorySize - freeMemory;
            double ramUsage = (usedMemoryKB * 100) / totalMemorySize;
            return ramUsage;
        }

        private double GetWmiValue(string wmiParameterName, string propertyName)
        {
            var searcher = new ManagementObjectSearcher("select * from " + wmiParameterName);
            double value = 0.0;
            foreach (ManagementObject obj in searcher.Get().Cast<ManagementObject>())
            {
                value += Convert.ToInt32(obj[propertyName]);
            }
            return value;
        }
    }
}
