using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.SceneManagement;

public class CarregarFase : MonoBehaviour
{

    public string cenaPCarregar;

    void Start()
    {
        SceneManager.LoadScene(cenaPCarregar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
