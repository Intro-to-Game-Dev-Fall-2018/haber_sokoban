using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Inputs")] [SerializeField] private TextAsset _levelSet;

    [Header("Assets")] [SerializeField] private GameObject _wall;
    [SerializeField] private GameObject _box;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _floor;

    private GameObject[][] _map;
    private string[] _levels;
    private int currentLevel;

    private void nextLevel()
    {
        var lines = _levels[currentLevel].Split('\n');
        var size = lines.Select(line => line.Length).Concat(new[] {0}).Max();
        _map = new GameObject[lines.Length][];

        for (var i = 0; i < _map.Length; i++)
        {
            _map[i] = new GameObject[size];
            for (var j = 0; j < lines[i].Length; j++)
            {
                switch (lines[i][j])
                {
                    case '#':
                        _map[i][j] = Instantiate(_wall);
                        break;
                    case '@':
                        _map[i][j] = Instantiate(_player);
                        break;
                    case '$':
                        _map[i][j] = Instantiate(_box);
                        break;
                    default:
                        _map[i][j] = Instantiate(_floor);
                        break;
                }
            }
        }
    }

    private void Start()
    {
        string[] split = {"\n\n"};
        currentLevel = 0;
        _levels = _levelSet.text.Split(split, StringSplitOptions.RemoveEmptyEntries);
    }

    // Update is called once per frame
    void Update()
    {
    }
}