using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCache : SingletonObject<EnemyCache>
{
   public List<Sprite> normalEnemies;
   public Dictionary<string,Enemy> bosses;
    // Start is called before the first frame update


    public override void Init()
    {
        normalEnemies = new List<Sprite>();
        bosses = new Dictionary<string, Enemy>();
        DontDestroyOnLoad(this);
    }

}
