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
        _soundEffects[(int)SoundEffectType.PineconeFlying] = Game.Content.Load<SoundEffect>("PineconeFlying");
    }
    public void Calculate3DSound(SoundEffectInstance soundEffectInstance, Vector2 playerPosition, Vector2 emitterPosition)
    {
        // Volume
        float distance = Vector2.Distance(playerPosition, emitterPosition);
        float relativeVolume = 1f - (distance / 500f);
        System.Diagnostics.Debug.WriteLine(playerPosition + " " + emitterPosition + " " + relativeVolume);
        ; // Adjust the divisor to control the falloff distance

        soundEffectInstance.Volume = Math.Clamp(relativeVolume * Options.Options.Current.GameVolume, 0f, 1f);

        // Pan
        float pan = (emitterPosition.X - playerPosition.X) / 500f; // Adjust the divisor to control the pan sensitivity
        soundEffectInstance.Pan = Math.Clamp(pan, -1f, 1f);
    }
    public static SoundEffectInstance Play(SoundEffectType type, Vector2? playerPosition, Vector2? emitterPosition, float volume, float pan = 0f, bool looping=false, bool music=false)
    {
        return _instance.PlaySound(type, playerPosition, emitterPosition, volume, pan, looping, music);
    }

    public SoundEffectInstance PlaySound(SoundEffectType type, Vector2? playerPosition, Vector2? emitterPosition, float volume, float pan = 0f, bool looping=false, bool music = false)
    {
        pan = Math.Clamp(pan, -1f, 1f);
        //_soundEffects[(int)type].Play(1, 0, pan);
        //_soundEffectInstances.Add(_soundEffects[(int)type], ) = ;

        SoundEffectInstance soundEffectInstance = _soundEffects[(int)type].CreateInstance();

        soundEffectInstance.IsLooped = looping;
        soundEffectInstance.Volume = volume;

        if (playerPosition != null && emitterPosition != null)
        {
            Calculate3DSound(soundEffectInstance, (Vector2)playerPosition, (Vector2)emitterPosition);
        }
        soundEffectInstance.Play();

        if (music)
            _music = soundEffectInstance;
        else
            _soundEffectInstances.Add(soundEffectInstance);

        
        return soundEffectInstance;
        //soundEffectInstance.Volume = Options.Options.Current.GameVolume;

    }
    public void StopSound(SoundEffectInstance soundEffectInstance)
    { 
        soundEffectInstance.Stop();
        _soundEffectInstances.Remove(soundEffectInstance);
    }
    public void StopSounds()
    {
        foreach (SoundEffectInstance sei in _soundEffectInstances)
        {
            sei.Stop();
        }
        _soundEffectInstances.Clear();
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