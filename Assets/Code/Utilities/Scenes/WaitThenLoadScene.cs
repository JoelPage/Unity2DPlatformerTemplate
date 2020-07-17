using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class WaitThenLoadScene : MonoBehaviour
{
    public float seconds = 0.0f;
    public Object scene;

    void Awake()
    {
        Assert.IsTrue(scene.GetType() != typeof(Scene), "Object used in WaitThenLoadScene is not a Scene!");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(seconds);
        // WARNING - THIS DOES NOT WORK IN BUILDS, ONLY IN THE EDITOR
        // See : https://answers.unity.com/questions/605184/scene-as-a-variable.html
        SceneManager.LoadScene(scene.name);
    }
}
