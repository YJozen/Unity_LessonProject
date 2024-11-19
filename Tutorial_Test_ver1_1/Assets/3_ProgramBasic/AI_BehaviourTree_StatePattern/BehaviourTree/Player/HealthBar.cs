using UnityEngine;
using UnityEngine.UI;

namespace GameNamespace
{
    public class HealthBar : MonoBehaviour
    {
        public Slider healthSlider;

        public void SetHealth(float health)
        {
            healthSlider.value = health;
        }
    }
}
