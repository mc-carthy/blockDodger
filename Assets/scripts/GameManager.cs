using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    private float timeScaleSlowDown = 4f;
    private float regularFixedDeltaTime;

    protected override void Awake ()
    {
        base.Awake ();
        regularFixedDeltaTime = Time.fixedDeltaTime;
    }

	public void EndGame ()
    {
        StartCoroutine (EndGameRoutine ());
    }

    private IEnumerator EndGameRoutine ()
    {
        Time.timeScale = 1 / timeScaleSlowDown;
        Time.fixedDeltaTime = regularFixedDeltaTime / timeScaleSlowDown;
        yield return new WaitForSeconds (3f / timeScaleSlowDown);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = regularFixedDeltaTime;
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex, LoadSceneMode.Single);
    }

}
