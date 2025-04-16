using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;


namespace modul8_103022330140
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public int transfer { get; set; }
        public string methods { get; set; }
        public string confirmations { get; set; }

        private static readonly string configPath = "bank_transfer_config";

        public BankTransferConfig()
        {
            LoadConfig();
        }
        private void LoadConfig()
        {
            if (File.Exist(configPath))
            {
                string json = File.ReadAllText(configPath);
                var config = JsonSerializer.Deserialize<BankTransferConfig>(json);

                lang = config.lang;
                transfer = config.transfer;
                methods = config.methods;
                confirmations = config.confirmations;
            }
            else 
            {
                SetDefaultConfig();
                SaveConfig();
            }
        }

        private void SetDefaultConfig()
        {
            lang = "en";
            transfer
                {
                treshold = 25000000;
                low_fee = 6500;
                high_fee = 15000;
                }
            methods = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"];
                confirmations: {
                en = "yes";
                id = "ya";
                }
        }

        public void SaveConfig()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configPath, json);
        }
    }
}
