using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Sounds")] [SerializeField] private AudioClip[] musicPlayList;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource effects;
    [SerializeField] private bool rundomMusic;
    private const string PREFS_MUSIC_VOLUME = "MusicVolume"; //todo
    private const string PREFS_EFFECT_VOLUME = "EffectVolume"; //todo
    private int musicIndex;

    private int musicCount;

    // песня с индексом 0 запускается при старте
    private void Start()
    {
        // колличество песен на старте игры (длина массива)
        musicCount = musicPlayList.Length - 1;
        // воспроизвести музыку
        music.Play();
    }

    private void Update()
    {
        PLayMusic();
    }

    public void PLaySound(AudioClip audio)
    {
        effects.PlayOneShot(audio);
    }

    public void PLayMusic()
    {
        // проверка, что песня играет
        // если не играет, то включаем следующую по индексу
        if (!music.isPlaying)
        {
            ChangeMusicIndex(); // поменять индекс
            music.clip = musicPlayList[musicIndex];
            music.Play(); //воспроизвести 
        }
    }

    private void ChangeMusicIndex()
    {
        if (rundomMusic)
        {
            Shuffle();
        }
        else
        {
            Consistently();
        }
    }

    // воспроизведение музыки по кругу

    // Если песня последняя в списке, то след запускается под индексом 0, если не последняя песня в массиве

    // то увеличить индекс

    void Consistently()
    {
        if (musicIndex == musicCount)
        {
            musicIndex = 0;
        }
        else
        {
            musicIndex++;
        }
    }

    // перемешать индексы в массиве 

    void Shuffle()
    {
        musicIndex = Random.Range(0, musicCount + 1);
    }

    // задать значение 
    //todo
    public void SetMusicVolume(float volume)
    {
        // переданная громкость в функцию устанавливается в music
        music.volume = volume;
        PlayerPrefs.SetFloat("PREFS_MUSIC_VOLUME", volume); //
    }

    //todo
    // получить значение
    public float GetMusicVolume()
    {
        return music.volume;
    }

    //todo
    public void SetEffectVolume(float volume)
    {
        effects.volume = volume;
        PlayerPrefs.SetFloat("PREFS_EFFECT_VOLUME", volume); //сохраняет громкость в реестре
    }

    //todo
    // возвращает громкость эффектов
    public float GetEffectVolume()
    {
        return effects.volume;
    }
}