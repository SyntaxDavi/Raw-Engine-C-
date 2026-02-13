using Raylib_cs;
using System;
using System.Collections.Generic;

public class AssetManager
{
    private Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
    private Dictionary<string, Sound> _sounds = new Dictionary<string, Sound>();
    private Dictionary<string, Music> _music = new Dictionary<string, Music>();
    private Dictionary<string, Font> _fonts = new Dictionary<string, Font>();

    public static AssetManager? Instance { get; private set; }
    public int Count => _textures.Count + _sounds.Count + _music.Count + _fonts.Count;

    public static void Initialize()
    {
        if(Instance != null)
        {
            throw new InvalidOperationException("AssetManager já existe");
        }
        Instance = new AssetManager();

        // Instance.LoadTexture("default_missing_texture", "Assets/Textures/default_missing_texture.png");
        // Instance.LoadSound("default_missing_sound", "Assets/Sounds/default_missing_sound.wav");
        // Instance.LoadMusic("default_missing_music", "Assets/Music/default_missing_music.mp3");
        // Instance.LoadFont("default_missing_font", "Assets/Fonts/default_missing_font.ttf");
    }

    public Texture2D LoadTexture(string key, string path)
    {
        if(!_textures.TryGetValue(key, out var texture))
        {
            _textures.Add(key, Raylib.LoadTexture(path));
        }
        return _textures[key];
    }

    public Sound LoadSound(string key, string path)
    {
        if(!_sounds.TryGetValue(key, out var sound))
        {
            _sounds.Add(key, Raylib.LoadSound(path));
        }
        return _sounds[key];
    }

    public Music LoadMusic(string key, string path)
    {
        if(!_music.TryGetValue(key, out var music))
        {
            _music.Add(key, Raylib.LoadMusicStream(path));
        }
        return _music[key];
    }

    public Font LoadFont(string key, string path)
    {
        if(!_fonts.TryGetValue(key, out var font))
        {
            _fonts.Add(key, Raylib.LoadFont(path));
        }
        return _fonts[key];
    }

    public Texture2D GetTexture(string key)
    {
        if(_textures.TryGetValue(key, out var texture))
         return texture;

        Console.WriteLine($"Textura '{key}' não encontrada.");
        return _textures["default_missing_texture"];
    }

    public Sound GetSound(string key)
    {
        if(_sounds.TryGetValue(key, out var sound))
         return sound;

        Console.WriteLine($"Som '{key}' não encontrado.");
        return _sounds["default_missing_sound"];
    }

    public Music GetMusic(string key)
    {
        if(_music.TryGetValue(key, out var music))
         return music;

        Console.WriteLine($"Musica '{key}' não encontrada.");
        return _music["default_missing_music"];
    }

    public Font GetFont(string key)
    {
        if(_fonts.TryGetValue(key, out var font))
         return font;

        Console.WriteLine($"Fonte '{key}' não encontrada.");
        return _fonts["default_missing_font"];
    }

    public void UnloadTexture(string key)
    {
        if(_textures.TryGetValue(key, out var texture))
        {
            Raylib.UnloadTexture(texture);
            _textures.Remove(key);
        }
    }

    public void UnloadSound(string key)
    {
        if(_sounds.TryGetValue(key, out var sound))
        {
            Raylib.UnloadSound(sound);
            _sounds.Remove(key);
        }
    }

    public void UnloadMusic(string key)
    {
        if(_music.TryGetValue(key, out var music))
        {
            Raylib.UnloadMusicStream(music);
            _music.Remove(key);
        }
    }

    public void UnloadFont(string key)
    {
        if(_fonts.TryGetValue(key, out var font))
        {
            Raylib.UnloadFont(font);
            _fonts.Remove(key);
        }
    }

    public void UnloadAll()
    {
        foreach (var texture in _textures.Values)
        {
            Raylib.UnloadTexture(texture);
        }
        _textures.Clear();

        foreach (var sound in _sounds.Values)
        {
            Raylib.UnloadSound(sound);
        }
        _sounds.Clear();

        foreach (var music in _music.Values)
        {
            Raylib.UnloadMusicStream(music);
        }
        _music.Clear();

        foreach (var font in _fonts.Values)
        {
            Raylib.UnloadFont(font);
        }
        _fonts.Clear();
    }
}