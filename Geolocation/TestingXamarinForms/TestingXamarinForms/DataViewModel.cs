using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TestingXamarinForms
{
    class DataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Data data;
        public DataViewModel()
        {
            data = new Data();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Task.Run(async () =>
                {
                    await GetLocation();
                });
                return true;
            });
        }

        public double? Altitude
        {
            get { return data.Altitude; }
            set
            {
                if (data.Altitude != value)
                {
                    data.Altitude = value;
                    OnPropertyChanged("Altitude");
                }
            }
        }

        public double Longitude
        {
            get { return data.Longitude; }
            set
            {
                if (data.Longitude != value)
                {
                    data.Longitude = value;
                    OnPropertyChanged("Longitude");
                }
            }
        }

        public double Latitude
        {
            get { return data.Latitude; }
            set
            {
                if (data.Latitude != value)
                {
                    data.Latitude = value;
                    OnPropertyChanged("Latitude");
                }
            }
        }

        public string IpAddress
        {
            get { return data.IpAddress; }
            set
            {
                if (data.IpAddress != value)
                {
                    data.IpAddress = value;
                    OnPropertyChanged("IpAddress");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(propName));
        }
        public async Task GetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    this.Altitude = location.Altitude;
                    this.Latitude = location.Latitude;
                    this.Longitude = location.Longitude;
                    this.IpAddress = Dns.GetHostAddresses(Dns.GetHostName()).Where(address=>address.AddressFamily==AddressFamily.InterNetwork).First().ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                throw new Exception("FeatureNotSupported");
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                throw new Exception("Exception 2");
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                throw new Exception("Exception 3");
                // Handle permission exception
            }
            catch (Exception ex)
            {
                throw new Exception("Exception");
                // Unable to get location
            }
        }
    }
}
