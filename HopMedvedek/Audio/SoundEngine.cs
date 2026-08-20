using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace HopMedvedek.Audio;

public sealed class SoundEngine : GameComponent
{
    private SoundEffect[] _soundEffects = new SoundEffect[(int)SoundEffectType.LastType];
    private List<SoundEffectInstance> _soundEffectInstances = new();
    private SoundEffectInstance _music;
    private static SoundEngine _instance;

    private SoundEngine(Game game)
        : base(game)
    {
    }

    public static void Init(Game game)
    {
        _instance = new SoundEngine(game);
        game.Components.Add(_instance);
    }


    public static SoundEngine Instance
    {
        get
        {
            if (_instance == null)
                throw new Exception("Sound Engine not initialized.");
            return _instance;
        }
    }

    public override void Initialize()
    {
        _soundEffects[(int)SoundEffectType.HopMedvedekMainTheme] = Game.Content.Load<SoundEffect>("HopMedvedekMainTheme");
        _soundEffects[(int)SoundEffectType.BearJump] = Game.Content.Load<SoundEffect>("BearJump");
        _soundEffects[(int)SoundEffectType.BearThrow] = Game.Content.Load<SoundEffect>("BearThrow");
        _soundEffects[(int)SoundEffectType.BearHit] = Game.Content.Load<SoundEffect>("BearHit");
        _soundEffects[(int)SoundEffectType.BearDie] = Game.Content.Load<SoundEffect>("BearDie");
        _soundEffects[(int)SoundEffectType.CrowAttack] = Game.Content.Load<SoundEffect>("CrowAttack");
        _soundEffects[(int)SoundEffectType.CrowHit] = Game.Content.Load<SoundEffect>("CrowHit");
        _soundEffects[(int)SoundEffectType.OwlQuestion] = Game.Content.Load<SoundEffect>("OwlQuestion");
        _soundEffects[(int)SoundEffectType.CorrectAnswer] = Game.Content.Load<SoundEffect>("CorrectAnswer");
        _soundEffects[(int)SoundEffectType.WrongAnswer] = Game.Content.Load<SoundEffect>("WrongAnswer");
        _soundEffects[(int)SoundEffectType.ButtonPressed] = Game.Content.Load<SoundEffect>("ButtonPressed");
        _soundEffects[(int)SoundEffectType.ButtonHover] = Game.Content.Load<SoundEffect>("ButtonHover");
        _soundEffects[(int)SoundEffectType.Coin] = Game.Content.Load<SoundEffect>("CoinSound");
        _soundEffects[(int)SoundEffectType.Leaves] = Game.Content.Load<SoundEffect>("Leaves");
    }

    public static void Play(SoundEffectType type, Vector2? playerPosition, Vector2? emitterPosition, float volume, float pan = 0f, bool looping=false, bool music=false)
    {
        _instance.PlaySound(type, playerPosition, emitterPosition, volume, pan, looping, music);
    }

    public void PlaySound(SoundEffectType type, Vector2? playerPosition, Vector2? emitterPosition, float volume, float pan = 0f, bool looping=false, bool music = false)
    {
        pan = Math.Clamp(pan, -1f, 1f);
        //_soundEffects[(int)type].Play(1, 0, pan);
        //_soundEffectInstances.Add(_soundEffects[(int)type], ) = ;

        SoundEffectInstance soundEffectInstance = _soundEffects[(int)type].CreateInstance();

        if (playerPosition != null && emitterPosition != null)
        {
            AudioListener _player = new AudioListener();
            _player.Position = new Vector3((Vector2)playerPosition, 0);

            AudioEmitter _emitter = new AudioEmitter();
            _emitter.Position = new Vector3((Vector2)emitterPosition, 0);

            soundEffectInstance.Apply3D(_player, _emitter);
        }

        soundEffectInstance.Volume = volume;
        soundEffectInstance.IsLooped = looping;

        soundEffectInstance.Play();

        if (music)
            _music = soundEffectInstance;
        else
            _soundEffectInstances.Add(soundEffectInstance);

        

        //soundEffectInstance.Volume = Options.Options.Current.GameVolume;

    }

    public void SetMusicVolume(float volume)
    { 
        _music.Volume = volume;
    }
    public void SetSoundsVolume(float volume)
    {
        foreach (SoundEffectInstance sei in _soundEffectInstances)
            sei.Volume = volume;
    }
}