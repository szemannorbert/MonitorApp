using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.IO;
using Microsoft.Win32;

namespace Monitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> alaplap, processzor, memoria, hattertar = new List<string>();
        List<string> szoftverek = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();
            Alaplap();
            Processzor();
            Memoria();
            Hattertar();
            Szoftverek();

        }
        public void Alaplap()
        {
            ManagementObjectSearcher hw = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (var item in hw.Get())
            {
                alaplapList.Items.Add($"{item["Name"]}, {item["Model"]}");
                alaplap.Add($"Alaplap: {item["Name"]}, {item["Model"]}");
            }
        }

        public void Processzor()
        {
            ManagementObjectSearcher hw = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (var item in hw.Get())
            {
                processzorList.Items.Add($"{item["Name"]}, {item["Model"]}");
                processzor.Add($"Processzor: {item["Name"]}, {item["Model"]}");
            }
        }

        public void Memoria()
        {
            ManagementObjectSearcher hw = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            foreach (var item in hw.Get())
            {
                memoriaList.Items.Add($"{item["Name"]}, {item["Capacity"]}");
                memoria.Add($"Memória: {item["Name"]}, {item["Capacity"]}");
            }
        }

        public void Hattertar()
        {
            ManagementObjectSearcher hw = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (var item in hw.Get())
            {
                hattertarList.Items.Add($"{item["Name"]}, {item["Model"]}, {item["Size"]}");
                hattertar.Add($"Háttértár: {item["Name"]}, {item["Model"]}, {item["Size"]}");
            }
        }

        public void Szoftverek()
        {
            ManagementObjectSearcher softwares = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            foreach (var item in softwares.Get())
            {
                softwareList.Items.Add($"{item["Name"]}, {item["Version"]}");
                szoftverek.Add($"{item["Name"]}, {item["Version"]}");
            }
        }

        public void hardverekMentes()
        {
            StreamWriter hwsw = new StreamWriter("hardvermentes.txt");
            for (int i = 0; i < alaplap.Count; i++)
            {
                hwsw.WriteLine(alaplap[i]);
            }
            for (int i = 0; i < processzor.Count; i++)
            {
                hwsw.WriteLine(processzor[i]);
            }
            for (int i = 0; i < memoria.Count; i++)
            {
                hwsw.WriteLine(memoria[i]);
            }
            for (int i = 0; i < hattertar.Count; i++)
            {
                hwsw.WriteLine(hattertar[i]);
            }
            hwsw.Close();
        }

        public void szoftverekMentes()
        {
            StreamWriter softsw = new StreamWriter("szoftvermentes.txt");
            for (int i = 0; i < szoftverek.Count; i++)
            {
                softsw.WriteLine(szoftverek[i]);
            }
            softsw.Close();
        }
    }
}
