using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using System.Collections.ObjectModel;


namespace BlueTootApp.Views
{
    public partial class BluetoothManager : ContentPage
    {
        public ObservableCollection<IDevice> BluetoothInfo { get; } = new ObservableCollection<IDevice>();
        private readonly IAdapter _bluetoothAdapter;

        public BluetoothManager()
        {
            InitializeComponent();
            BindingContext = this;

            _bluetoothAdapter = CrossBluetoothLE.Current.Adapter;
            _bluetoothAdapter.DeviceDiscovered += OnDeviceDiscovered;
            DeviceList.ItemsSource = BluetoothInfo;

            
        }

        private async Task RequestBluetoothPermissionsAsync()
        {
          
        }

        private async Task InitialScan()
        {
            if (CrossBluetoothLE.Current.State != BluetoothState.On)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Please turn on Bluetooth", "OK");
                return;
            }

            try
            {
                BluetoothInfo.Clear();
                await _bluetoothAdapter.StartScanningForDevicesAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Exception: {ex.Message}", "OK");
            }
        }

        private void ShowDevice_Clicked(object sender, EventArgs e)
        {
            DeviceList.IsVisible = !DeviceList.IsVisible;
        }

        private async void TurnOn_Clicked(object sender, EventArgs e)
        {
            await InitialScan();
        }

        private void OnDeviceDiscovered(object sender, DeviceEventArgs e)
        {
            if (!BluetoothInfo.Contains(e.Device))
            {
                BluetoothInfo.Add(e.Device);
            }
        }
    }
}
