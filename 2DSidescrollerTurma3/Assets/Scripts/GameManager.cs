using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	void Start () {
		
	}

	public void LoadScene(int buildIndex){
		//Debug.Log (SceneManager.GetSceneByName(name).buildIndex);
		LoadingScreenManager.LoadScene(buildIndex);
	}

	public void Quit(){
		Application.Quit ();
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public void SaveGame(){
		PlayerPrefs.SetInt ("SceneIndex", SceneManager.GetActiveScene ().buildIndex);
	}

	public void LoadGame(){
		SceneManager.LoadScene (PlayerPrefs.GetInt("SceneIndex"));
	}

	public void NewGame(){
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("Level1");
	}
}
