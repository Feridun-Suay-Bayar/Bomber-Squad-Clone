using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

namespace BomberSquad.Health
{
    public class HealthImage : MonoBehaviour
    {
        Image _image;
        public HealthImage(Image image)
        {
            _image= image;
        }
        public void SetImage(float currentHealth,float maxHealth) 
        {
            if (currentHealth >= 70)
            {
                _image.color = Color.green;
            }
            else if (currentHealth < 70 && currentHealth >= 40)
            {
                _image.color = Color.yellow;
            }
            else if (currentHealth < 40)
            {
                _image.color = Color.red;
            }
            _image.fillAmount = currentHealth / maxHealth;
        }
        public void SetImage(float currentHealth,float maxHealth, Color color)
        {
            _image.color = Color.red;
            _image.fillAmount = currentHealth / maxHealth;
        }
    }
}