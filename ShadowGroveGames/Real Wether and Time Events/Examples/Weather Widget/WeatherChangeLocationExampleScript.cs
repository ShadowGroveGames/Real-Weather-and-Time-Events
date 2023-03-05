using ShadowGroveGames.RealWeatherAndTimeEvents.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace ShadowGroveGames.RealWeatherAndTimeEvents.Example
{
    public class WeatherChangeLocationExampleScript : MonoBehaviour
    {
        [SerializeField] private InputField _cityInputField;

        public void OnSubmit()
        {
            RealWeatherAndTimeEventsScript.Instance.ChangeLocation(_cityInputField.text);
        }
    }
}

