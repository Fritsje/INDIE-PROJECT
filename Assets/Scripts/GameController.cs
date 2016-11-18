using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public enum GameState
	{
		Start,
		Playing,
		Dead
	}

	private int _highScore;
	private int _levelStep;
	private GameObject _lastLevelPart;

	public GameObject[] levelParts;

	void Start() {
		if(levelParts.Length == 0) {
			Debug.LogError("LevelParts not given");
		}
		NewGame();

	}

	void NewGame () {
		_levelStep = 1;

		for (int i = 0; i < 5; i++) {
			CreateLevel();
		}
	}

	public void GameOver(int highScore) {
		_highScore = highScore;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void CreateLevel() {
		int x = Random.Range(0, levelParts.Length);
		if (levelParts[x] == null) {
			Debug.LogError("LevelFormat doesnt exist");
			return;
		}
		if(_lastLevelPart != null) {
			//Transform oldLastLevel = _lastLevelPart.transform;
			_lastLevelPart = Instantiate(levelParts[x], new Vector3(0, 0, _levelStep * 20f), Quaternion.identity) as GameObject;
		} else {
			_lastLevelPart = Instantiate(levelParts[x], new Vector3(0, 0, _levelStep * 20f), Quaternion.identity) as GameObject;
		}
		_levelStep++;
		
	}


}
