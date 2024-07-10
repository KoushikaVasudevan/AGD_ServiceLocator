using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Map;
using ServiceLocator.Wave;
using ServiceLocator.Events;
using ServiceLocator.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public MapService mapService { get; private set; }
    public WaveService waveService { get; private set; }
    public EventService eventService { get; private set; }

    [SerializeField] private UIService uIService;

    public UIService UIService => uIService;


    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;

    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

    private void Start()
    {
        eventService = new EventService();
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        mapService = new MapService(mapScriptableObject);
        waveService = new WaveService(waveScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }
}
