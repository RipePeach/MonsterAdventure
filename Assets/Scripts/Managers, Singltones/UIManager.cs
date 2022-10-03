using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Managers__Singltones
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private float fadeDuration;
        [SerializeField] private CanvasGroup popUp;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider effectsSlider;
        [SerializeField] private MusicManager musicManager;

        private void Awake()
        {
            popUp.gameObject.SetActive(false);
        }

        public void ShowVolumeMenu()
        {
            // включает меню
            popUp.gameObject.SetActive(true);
            popUp.alpha = 0;
            // плавное проявление меню с 0 до 1 по алфаканалу за fadeDuration. 
            // Твин выполнится со скоростью 1 независимо от значения Time.timeScale
            popUp.DOFade(1, fadeDuration).SetUpdate(true);
        
            Time.timeScale = 0;
            // слайдеру(громкости) передаётся значение, записанное в AudioManager
            musicSlider.value = musicManager.GetMusicVolume() * musicSlider.maxValue;
            effectsSlider.value = musicManager.GetEffectVolume() * effectsSlider.maxValue;
        }

        public void HideVolumeMenu()
        {
            // плавное увядание меню с 1 до 0 по алфаканалу за fadeDuration
            popUp.DOFade(0, fadeDuration).OnComplete(() =>
                {
                    // выключает меню
                    popUp.gameObject.SetActive(false);
                    Time.timeScale = 1;
                }
            ).SetUpdate(true);
        }
        
        public  void MusicVolumeChanged()
        {
            // Делим на maxValue для того, чтобы совпадало значение в слайдере от 0 до 10, а в AudioSours от 0,1 до 1
            musicManager.SetMusicVolume(musicSlider.value / musicSlider.maxValue);
        }
        public  void EffectVolumeChanged()
        {
            musicManager.SetEffectVolume(effectsSlider.value / effectsSlider.maxValue);
        }
    }
}