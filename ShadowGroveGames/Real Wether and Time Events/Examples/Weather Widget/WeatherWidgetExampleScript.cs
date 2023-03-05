using ShadowGroveGames.RealWeatherAndTimeEvents.Scripts.OpenWeatherApi.DTO;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace ShadowGroveGames.RealWeatherAndTimeEvents.Example
{
    public class WeatherWidgetExampleScript : MonoBehaviour
    {
        [Header("Top Information")]
        [SerializeField] private Image _weatherIcon;
        [SerializeField] private Text _city;
        [SerializeField] private Text _time;
        [SerializeField] private Text _coordinates;
        [SerializeField] private Text _temprature;
        [SerializeField] private Text _description;

        [Header("Bottom Information")]
        [SerializeField] private Text _wind;
        [SerializeField] private Text _humidity;
        [SerializeField] private Text _pressure;
        [SerializeField] private Text _visibility;

        public void OnWeatherInformationReady(WeatherInformation weatherInformation)
        {
            DisplayWeatherInformation(weatherInformation);
        }

        public void OnWeatherInformationUpdate(WeatherInformation weatherInformation)
        {
            DisplayWeatherInformation(weatherInformation);
        }

        void DisplayWeatherInformation(WeatherInformation weatherInformation)
        {
            var cultureInfo = CultureInfo.GetCultureInfo("en-US");

            // Icon load from Resources folder
            _weatherIcon.sprite = Resources.Load<Sprite>($"WeatherIcons/{weatherInformation.Weather.Icon}");

            #region Top Information
            _city.text = weatherInformation.CityName + ", " + weatherInformation.General.Country.ToString();
            _time.text = weatherInformation.DateTime.ToString("f", cultureInfo);
            _coordinates.text = $"Lat: {weatherInformation.Coordinates.Latitude.ToString("0.000", cultureInfo)} Lon: {weatherInformation.Coordinates.Longitude.ToString("0.000", cultureInfo)}";
            _temprature.text = $"{weatherInformation.Main.Temperature.FahrenheitCurrent.ToString("0.00", cultureInfo)} �F";
            _description.text = weatherInformation.Weather.Description;
            #endregion

            #region Bottom Information
            _wind.text = $"<b>Wind:</b> {weatherInformation.Wind.SpeedMetersPerHour.ToString("0.00")} mph from {Wind.WindDirectionToString(weatherInformation.Wind.Direction)} ({weatherInformation.Wind.Degree}�)";
            _humidity.text = $"<b>Humidity:</b> {weatherInformation.Main.Humidity} %";
            _pressure.text = $"<b>Pressure:</b> {weatherInformation.Main.Pressure} hPa";
            _visibility.gameObject.SetActive(weatherInformation.Visibility != null);
            _visibility.text = $"<b>Visibility:</b> {(weatherInformation.Visibility ?? 1) / 1000} km";
            #endregion
        }
    }
}

