using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EfeitoDigitador : MonoBehaviour
{
    private TextMeshProUGUI componenteTxt;
    private AudioSource _audioSource;
    private string MsgOrign;
    public bool imprimindo;
    public float tempoLetras = 0.08f;

    private void Awake()
    {
        TryGetComponent(out componenteTxt);
        TryGetComponent(out _audioSource);
        MsgOrign = componenteTxt.text;
        componenteTxt.text = "";
    }

    private void OnEnable()
    {
        ImprimirMsg(MsgOrign);
    }

    private void OnDisable()
    {
        componenteTxt.text = MsgOrign;
        StopAllCoroutines();
    }

    public void ImprimirMsg(string mensagem)
    {
        if (gameObject.activeInHierarchy)
        {
            if (imprimindo) return;
            imprimindo = true;
            StartCoroutine(CadaLetra(mensagem));
        }
    }

    IEnumerator CadaLetra(string mensagem)
    {
        string msg = "";
        foreach (var letra in mensagem)
        {
            msg += letra;
            componenteTxt.text = msg;
            _audioSource.Play();
            yield return new WaitForSeconds(tempoLetras);
        }

        imprimindo = false;
        StopAllCoroutines();
    }
}
