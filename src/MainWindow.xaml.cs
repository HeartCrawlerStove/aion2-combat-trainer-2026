using System;
using System.Windows;
using System.Windows.Interop;

namespace Aion2Trainer
{
    /// <summary>
    /// Main window for AION 2 Combat Trainer.
    /// Handles UI events, trainer configuration, and process connection status.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MemoryReader _memoryReader = new MemoryReader();
        private readonly HotkeyManager _hotkeyManager;
        private TrainerConfig _config;

        public MainWindow()
        {
            InitializeComponent();

            _config = TrainerConfig.Load();
            ApplyConfigToUI();

            _hotkeyManager = new HotkeyManager(new WindowInteropHelper(this).Handle);
            _hotkeyManager.HotkeyPressed += OnHotkeyPressed;

            // Register F1–F8 hotkeys
            for (var i = 1; i <= 8; i++)
                _hotkeyManager.Register(i);

            UpdateStatus("Ready");
        }

        private void ApplyConfigToUI()
        {
            chkGodMode.IsChecked = _config.GodMode;
            chkInfiniteHP.IsChecked = _config.InfiniteHP;
            chkInfiniteMP.IsChecked = _config.InfiniteMP;
            chkOneHitKill.IsChecked = _config.OneHitKill;
            chkInfiniteKinah.IsChecked = _config.InfiniteKinah;
            chkNoCooldown.IsChecked = _config.NoCooldown;
            chkSuperSpeed.IsChecked = _config.SuperSpeed;
            txtDamageMultiplier.Text = _config.DamageMultiplier.ToString();
        }

        private void UpdateStatus(string message)
        {
            txtStatus.Text = message;
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            SaveConfig();
            ApplyTrainerChanges();
            UpdateStatus("Changes applied");
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            _config = new TrainerConfig();
            ApplyConfigToUI();
            SaveConfig();
            ApplyTrainerChanges();
            UpdateStatus("Settings reset");
        }

        private void SaveConfig()
        {
            _config.GodMode = chkGodMode.IsChecked == true;
            _config.InfiniteHP = chkInfiniteHP.IsChecked == true;
            _config.InfiniteMP = chkInfiniteMP.IsChecked == true;
            _config.OneHitKill = chkOneHitKill.IsChecked == true;
            _config.InfiniteKinah = chkInfiniteKinah.IsChecked == true;
            _config.NoCooldown = chkNoCooldown.IsChecked == true;
            _config.SuperSpeed = chkSuperSpeed.IsChecked == true;

            if (double.TryParse(txtDamageMultiplier.Text, out var multiplier))
                _config.DamageMultiplier = multiplier;

            _config.Save();
        }

        private void ApplyTrainerChanges()
        {
            if (!_memoryReader.IsConnected)
            {
                UpdateStatus("Not connected to game process");
                return;
            }

            // Apply each enabled feature via memory writer
            if (_config.GodMode)
                _memoryReader.WriteInt(_memoryReader.GodModeAddress, 1);
            if (_config.InfiniteHP)
                _memoryReader.WriteInt(_memoryReader.InfiniteHPAddress, 999999);
            if (_config.InfiniteMP)
                _memoryReader.WriteInt(_memoryReader.InfiniteMPAddress, 999999);
            if (_config.OneHitKill)
                _memoryReader.WriteInt(_memoryReader.OneHitKillAddress, 1);
            if (_config.InfiniteKinah)
                _memoryReader.WriteInt(_memoryReader.InfiniteKinahAddress, 999999999);
            if (_config.NoCooldown)
                _memoryReader.WriteInt(_memoryReader.NoCooldownAddress, 0);
            if (_config.SuperSpeed)
                _memoryReader.WriteInt(_memoryReader.SuperSpeedAddress, 1);

            if (_config.DamageMultiplier != 1.0)
                _memoryReader.WriteInt(_memoryReader.DamageMultiplierAddress, (int)_config.DamageMultiplier);

            UpdateStatus("Trainer features applied");
        }

        private void OnHotkeyPressed(int id)
        {
            // Map hotkey IDs to trainer features
            switch (id)
            {
                case 0: // F1
                    chkGodMode.IsChecked = !chkGodMode.IsChecked;
                    break;
                case 1: // F2
                    chkInfiniteHP.IsChecked = !chkInfiniteHP.IsChecked;
                    break;
                case 2: // F3
                    chkInfiniteMP.IsChecked = !chkInfiniteMP.IsChecked;
                    break;
                case 3: // F4
                    chkOneHitKill.IsChecked = !chkOneHitKill.IsChecked;
                    break;
                case 4: // F5
                    chkInfiniteKinah.IsChecked = !chkInfiniteKinah.IsChecked;
                    break;
                case 5: // F6
                    chkNoCooldown.IsChecked = !chkNoCooldown.IsChecked;
                    break;
                case 6: // F7
                    chkSuperSpeed.IsChecked = !chkSuperSpeed.IsChecked;
                    break;
                case 7: // F8
                    BtnApply_Click(this, EventArgs.Empty);
                    break;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            _hotkeyManager?.Dispose();
            _memoryReader?.Dispose();
            base.OnClosed(e);
        }
    }
}