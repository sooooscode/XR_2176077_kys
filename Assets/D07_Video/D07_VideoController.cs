using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Video;



public class HW02_Audio_Controller: MonoBehaviour

{

    public VideoPlayer Video;



    void Start()

    {

        Video.Play();

        Video.isLooping = true;

    }



    void Update()

    {

        if (Input.GetKeyDown(KeyCode.Return))

        {

            if (Video.isPlaying)

            {

                //Video.Stop(); 

                Video.Pause();

            }

            else

            {

                Video.Play();

            }

        }

    }

}