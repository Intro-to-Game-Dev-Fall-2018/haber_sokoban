using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Level Set",menuName = "Levels/Level Set Container")]
public class Levels : ScriptableObject
{
	[SerializeField] private bool resetOnStart;
	[SerializeField] private Set[] _sets;

	public Set Set;

	private void OnEnable()
	{
		if (resetOnStart) ResetProgress();
		Set = _sets[0];
	}

	public Set Iterate(int amount)
	{
		int next = (Array.IndexOf(_sets,Set) + amount) % _sets.Length;
		if (next < 0) next = _sets.Length-1;
		Set = _sets[next];
		return Set;
	}

	public void ResetProgress()
	{
		foreach (Set s in _sets)
			s.ResetProgress();
		resetOnStart = false;
	}
}

[Serializable]
public class Set
{
	[SerializeField] private string _name;
	[SerializeField] private string _author;
	[SerializeField] private TextAsset _file;

	[SerializeField] private string _description;
	
	[SerializeField] private int _progress;

	[SerializeField] private UnityEvent onComplete;

	private int _size;

	public string Name
	{
		get { return _name; }
	}

	public string Description
	{
		get { return _description; }
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
			
			Complete = true;
			_progress = 0;
			onComplete.Invoke();
		}
	}

	public void FinishLevel(int score)
	{
		Progress++;
	}

	public bool Complete { get; private set; }

	public void ResetProgress()
	{
		Complete = false;
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
