using System.Collections;
using UnityEngine;

public class Bot : Unit
{
    public float actionTime = 5f;
    public MagicWand wand;
    public Transform target;

    private void Awake()
    {
        StartCoroutine(RandomActions());
    }

    IEnumerator RandomActions()
    {
        while (true)
        {
            wand.transform.LookAt(target);
            int num = Random.Range(0, 3);

            switch (num)
            {
                case 0:
                    wand.UpCast();
                    break;
                case 1:
                    wand.RightCast();
                    break;
                case 2:
                    wand.LeftCast();
                    break;
                case 3:
                    wand.DownCast();
                    break;
            }
            yield return new WaitForSeconds(actionTime + Random.Range(-2,2));
        }
    }
}
