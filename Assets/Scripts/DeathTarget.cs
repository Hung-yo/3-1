using UnityEngine;

public class DeathTarget : DeathDestroy
{
    public float numDeaths;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numDeaths = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public override void DeathEvent()
    {
        numDeaths++;
    }
}
