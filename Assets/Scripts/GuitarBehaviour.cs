using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuitarBehaviour : MonoBehaviour
{

    [SerializeField] PlayerController playerController;
    [SerializeField] Animator animator;

    void FixedUpdate()
    {
        transform.Rotate(13 * Time.deltaTime, 0, 0, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Epa");
        if (collision.gameObject.CompareTag("Player"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        animator.SetLayerWeight(2, 1);
        animator.SetBool("emote", true);
        playerController.enabled = false;
        StartCoroutine(WaitForEmote());
    }

    IEnumerator WaitForEmote()
    {
        yield return new WaitForSeconds(5f);
        if (Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }
    }
}
