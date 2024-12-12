using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class GameHandler : MonoBehaviour {

      private GameObject player;
      public static int playerHealth = 100;
      public int StartPlayerHealth = 100;
      public GameObject healthText;

      public static int gotTokens = 0;
      public GameObject tokensText;
	  public GameObject EnemiesKilledBG;

	public static int gotJars = 0;
	public GameObject jarsText;
	  
      public bool isDefending = false;

      public static bool GameisPaused = false;
      public GameObject pauseMenuUI;
      public AudioMixer mixer;
      public static float volumeLevel = 1.0f;
      private Slider sliderVolumeCtrl;

      public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

      private string sceneName;
      public static string lastLevelDied;  //allows replaying the Level where you died

	private CameraShake cameraShake; 

      void Awake(){
            SetLevel (volumeLevel);
            GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
            if (sliderTemp != null){
                  sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                  sliderVolumeCtrl.value = volumeLevel;
            }
      }


      void Start(){
            player = GameObject.FindWithTag("Player");
			cameraShake = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
            sceneName = SceneManager.GetActiveScene().name;
            pauseMenuUI.SetActive(false);
            GameisPaused = false;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerHealth = StartPlayerHealth;
            //}
            updateStatsDisplay();
      }

      void Update(){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){ Resume(); }
                        else{ Pause(); }
                }
                // Stat tester:
                //if (Input.GetKey("p")){
                //       Debug.Log("Player Stat = " + playerStat1);
                //}
      }

	public void Pause(){
		if (!GameisPaused){
			pauseMenuUI.SetActive(true);
			Time.timeScale = 0f;
			GameisPaused = true;
		} else {Resume();}
	}

	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameisPaused = false;
	}

      public void SetLevel (float sliderValue){
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                volumeLevel = sliderValue;
      }

      public void playerKillEnemy(int newTokens){
            gotTokens += newTokens;
            updateStatsDisplay();
      }

	public void JarsCollected(int jars){
            gotJars += jars;
            updateStatsDisplay();
	}

      public void playerGetHit(int damage){
           if (isDefending == false){
                  playerHealth -= damage;
                  if (playerHealth >=0){
                        updateStatsDisplay();
                  }
                  if (damage > 0){
                        player.GetComponent<PlayerHurt>().playerHit();       //play GetHit animation
						cameraShake.ShakeCamera(0.10f, 0.2f);
                  }
            }

           if (playerHealth > StartPlayerHealth){
                  playerHealth = StartPlayerHealth;
                  updateStatsDisplay();
            }

           if (playerHealth <= 0){
                  playerHealth = 0;
                  updateStatsDisplay();
                  playerDies();
            }
      }

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "HEALTH: " + playerHealth;

			Text jarsTextTemp = jarsText.GetComponent<Text>();
            jarsTextTemp.text = "JARS: " + gotJars;
		

            Text tokensTextTemp = tokensText.GetComponent<Text>();
            tokensTextTemp.text = "Enemies Killed: " + gotTokens;

			if (gotTokens > 0){
			EnemiesKilledBG.SetActive(true);
			} else {
				EnemiesKilledBG.SetActive(false);
			}
      }

      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();
                   //play Death animation
            lastLevelDied = sceneName;       //allows replaying the Level where you died
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            //player.GetComponent<PlayerMove>().isAlive = false;
            //player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("SceneLose");
      }

      public void StartGame() {
            SceneManager.LoadScene("Level1");
      }

      // Return to MainMenu
      public void RestartGame() {
            Time.timeScale = 1f;
            GameHandler_PauseMenu.GameisPaused = false;
            SceneManager.LoadScene("MainMenu");
             // Reset all static variables here, for new games:
            playerHealth = StartPlayerHealth;
      }

      // Replay the Level where you died
      public void ReplayLastLevel() {
            Time.timeScale = 1f;
            GameHandler_PauseMenu.GameisPaused = false;
            SceneManager.LoadScene(lastLevelDied);
             // Reset all static variables here, for new games:
            playerHealth = StartPlayerHealth;
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
}
