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

    protected override void Awake()
    {
        base.Awake();
        eventService = new EventService();
    }

    private void Start()
    {
        mapService = new MapService(mapScriptableObject);
        playerService = new PlayerService(playerScriptableObject);
        waveService = new WaveService(waveScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
    }

    private void Update()
    {
        playerService.Update();
    }
}
