using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public void PlayCurrentScene()
    {
        StartCoroutine(DelayCurrentScene());
    }

    private IEnumerator DelayCurrentScene()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayNextScene()
    {
        int nextSceneIndex;
        int totalSceneCount = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        nextSceneIndex = currentSceneIndex + 1 < totalSceneCount ? currentSceneIndex + 1 : 0;
        StartCoroutine(DelayNextScene(nextSceneIndex));
    }

    private IEnumerator DelayNextScene(int nextSceneIndex)
    {
        yield return new WaitForSeconds(.5f);
        /*
  --------------------- WIZ KHALIFA / WE OWN IT ------------------------ 
         
It's Young Khalifa man
2 Chainz!
Money's the motivation
Money's the conversation
You on vacation, we gettin' paid so
We on paid-cation, I did it for the fam
It's whatever we had to do, it's just who I am
Yeah, it's the life I chose
Gunshots in the dark, one eye closed
And we got it cookin' like a one-eyed stove
You can catch me kissin' my girl with both eye' closed
Perfectin' my passion, thanks for askin'
Couldn't slow down, so we had to crash it
You use plastic, we 'bout cash
I see some people ahead that we gon' pass, yeah!
I never fear death or dyin'
I only fear never tryin'
I am whatever I am
Only God can judge me now
One shot, everything rides on tonight
Even if I got three strikes, I'ma go for it
This moment, we own it
Ayy, I'm not to be played with
Because it could get dangerous
See these people I ride with
This moment, we own it
And the same ones that I ride with, be the same ones that I die with
Put it all out on the line with, if you're looking for me
You could find Wiz in the new car or the crowd
With my new broad, that's a fine chick
And no other squad I'm down with, ain't (no way around it)
What you say? Tell me what you say
Workin' hard, reppin' for my dogs, do this everyday
Takin' off, lookin' out for all, makin' sure we ball
Like the mob, all you do is call
Catch you if you fall, Young Khalifa
I never fear death or dyin'
I only fear never tryin'
I am whatever I am
Only God can judge me now
One shot, everything rides on tonight
Even if I got three strikes, I'ma go for it
This moment, we own it
Ayy, I'm not to be played with (I ride or die for mine)
Because it could get dangerous
See these people I ride with (I ride or die for life)
This moment, we own it
This the biggest day of my life
We got big guns, been graduated from knives
It's the day in the life, and I'm ready to ride
Got the spirit, I'm feeling like a killer inside
Oh, financial outbreak, I'm free, but I ain't out yet
Ridin' with the plugs, so I'm close to the outlet
At the red light, rims sittin' offset
I look better on your girl (than her outfit)
Stuck to the plan, always said that we would stand up, never ran
We the fam, and loyalty never change up
Been down since day one, look at where we came from
Jumpin' out on anybody who tryin' to say somethin'
One thing about it, got a problem? I got the same one
Money rose, we fold
Playin' in clubs we closed
Follow the same code
Never turn our backs
Our cars don't even lose control
One shot, everything rides on tonight
Even if I got three strikes, I'ma go for it
This moment, we own it
Ayy, I'm not to be played with (I ride or die for mine)
Because it could get dangerous
See these people I ride with (I ride or die for life)
This moment, we own it
This moment, we own it
I ride or die for mine
I'm ride or die material
One life to live, so here we go
This moment, we own it
        */
        SceneManager.LoadScene(nextSceneIndex);
    }
}