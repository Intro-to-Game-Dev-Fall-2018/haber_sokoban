using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Set",menuName = "Levels/Level Set Container")]
public class Levels : ScriptableObject
{
	[SerializeField] private bool resetOnStart;
	[SerializeField] private Set[] _sets;

	public Set Set { get; set; }

	private void OnEnable()
	{
		if (resetOnStart) ResetProgress();
		Set = _sets[0];
	}

	public Set[] Sets {get { return _sets;  }}

	public void ResetProgress()
	{
		foreach (var s in _sets)
			s.Reset();
		resetOnStart = false;
	}
}

[Serializable]
public class Set
{
	[SerializeField] private string _name;
	[SerializeField] private string _author;
	[SerializeField] private TextAsset _file;
	[SerializeField] private DIFFICULTY _difficulty;

	[SerializeField] private string _description;
	
	[SerializeField] private int _progress;
	
	private bool _complete;
	private int _size;

	public string Name
	{
		get { return _name; }
	}
	
	public string Author
	{
		get { return _author; }
	}
	
	public int Progress
	{
		get { return _progress; }
		set
		{
			_progress = value;
			if (_progress != GetSize()) return;
			
			_complete = true;
			_progress = 0;
		}
	}

	public void FinishLevel(int score)
	{
		Progress++;
	}

	public bool Complete
	{
		get { return _complete; }
	}

	public void Reset()
	{
		_complete = false;
		_progress = 0;
		_size = 0;
	}

	public int GetSize()
	{
		if (_size != 0) return _size;
		
		_size = GetLevels().Length;
		return _size;
	}
	
	public string[] GetLevels()
	{
		string[] split = {"\n\n"};
		return _file.text.Split(split, StringSplitOptions.RemoveEmptyEntries);
	}
}

public enum DIFFICULTY
{
	EASY = 0,
	MEDIUM = 1,
	HARD = 2,
	EXTREME = 3
}
