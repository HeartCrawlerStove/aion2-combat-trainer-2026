using System;
using System.IO;
using System.Text.Json;

namespace Aion2Trainer
{
    /// <summary>
    /// Represents trainer configuration persisted to JSON.
    /// </summary>
    public class TrainerConfig
    {
        public bool GodMode { get; set; }
        public bool InfiniteHP { get; set; }
        public bool InfiniteMP { get; set; }
        public bool OneHitKill { get; set; }
        public double DamageMultiplier { get; set; } = 1.0;
        public bool InfiniteKinah { get; set; }
        public bool NoCooldown { get; set; }
        public bool SuperSpeed { get; set; }

        private static readonly string ConfigPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "AION2Trainer",
            "config.json");

        /// <summary>
        /// Loads configuration from disk. Returns default values if file does not exist.
        /// </summary>
        public static TrainerConfig Load()
        {
            try
            {
                if (!File.Exists(ConfigPath))
                    return new TrainerConfig();

                var json = File.ReadAllText(ConfigPath);
                return JsonSerializer.Deserialize<TrainerConfig>(json) ?? new TrainerConfig();
            }
            catch
            {
                return new TrainerConfig();
            }
        }

        /// <summary>
        /// Saves configuration to disk.
        /// </summary>
        public void Save()
        {
            try
            {
                var dir = Path.GetDirectoryName(ConfigPath);
                if (!string.IsNullOrEmpty(dir))
                    Directory.CreateDirectory(dir);

                var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigPath, json);
            }
            catch
            {
                // Silently ignore save failures
            }
        }
    }
}