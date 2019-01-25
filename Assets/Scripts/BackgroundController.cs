using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	private void BackToWait()
    {
        GetComponent<Animator>().SetBool("jump", false);
    }
}
