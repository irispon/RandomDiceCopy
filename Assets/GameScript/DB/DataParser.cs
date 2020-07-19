using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using UnityEngine;

public class DataParser 
{
    StringBuilder stringBuilder = new StringBuilder();

    public void DiceParse()
    {
        
        string sql = "SELECT*FROM AttackType ";
        IDataReader dataReader = DBManager.GetInstance().DataBaseRead(sql);
       
    
        while (dataReader.Read())
        {

            DiceStatus diceStatus = new DiceStatus();
            try

            {
              
                diceStatus.diceName = dataReader.GetString(0);
                //diceStatus.diceEye = 1;
                diceStatus.sprite = SpriteLoader.LoadNewSprite(dataReader.GetString(1));
                diceStatus.dotSprite = SpriteLoader.LoadNewSprite(dataReader.GetString(1).Replace("Dice.png", "Dot.png"));
                diceStatus.attackType.ofensiveType = EnumUtills.Parse<OfensiveType>(dataReader.GetString(2));
                diceStatus.attackType.damageType = EnumUtills.Parse<DamageType>(dataReader.GetString(3));
                diceStatus.attackType.target = EnumUtills.Parse<Target>(dataReader.GetString(4));
                diceStatus.attackType.damage = dataReader.GetFloat(5);
                diceStatus.attackType.attackSpeed = dataReader.GetFloat(6);
                diceStatus.attackType.diffusion = dataReader.GetFloat(7);
                diceStatus.attackType.range = dataReader.GetInt32(8);
                diceStatus.describe = dataReader.GetString(9);
                string path="";
                try
                {
                    path= "Animation/" + dataReader.GetString(1).Replace("./Assets/Resources/", "").Replace("Dice.png", "Dot");
                    diceStatus.animator = Resources.Load<RuntimeAnimatorController>(path);
                    Debug.Log(path);
                    if (diceStatus.animator != null) 
                    {
                        Debug.Log("애니메이션 존재");
                    }
              
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                if (!dataReader.IsDBNull(10))
                {
                    Debug.Log("이미지 로딩");
                    diceStatus.attackType.effect = SpriteLoader.LoadNewSprite(dataReader.GetString(10));
                }

                if (!dataReader.IsDBNull(11))
                {
                    diceStatus.attackType.animationEffect = Resources.Load<RuntimeAnimatorController>(dataReader.GetString(11));

                }
                // 12번은 디버프 적용 부위 설정임.
                diceStatus.attackType.potential = dataReader.GetFloat(13);
                DiceCache.GetInstance().diceCache.Add(diceStatus.diceName, diceStatus);
            }
            catch (Exception e)
            {
                Debug.Log("데이터 파싱 에러"+e);
            }


        }


    }
    public bool IDcheck(string id,string password)
    {
        
        stringBuilder.Clear();
        string sql = stringBuilder.Append("SELECT*FROM Member WHERE Id =").Append("'").Append(id).Append("'").ToString();
        try
        {
            IDataReader dataReader = DBManager.GetInstance().DataBaseRead(sql);
            while (dataReader.Read())
            {
                Debug.Log(dataReader.GetValue(0) + "번호" + dataReader.GetValue(1));
                if (password.Equals(dataReader.GetString(1)))
                {
                    Debug.Log("번호 일치");
                    DBManager.PlayerID = id;
                    return true;
                } 

            }
        }
        catch (Exception e)
        {
            Debug.Log("로그인 실패" + e);

        }

        return false;

    }
    public void DeckParser(string id)
    {

        stringBuilder.Clear();
        string sql = stringBuilder.Append("SELECT*FROM Deck WHERE Id =").Append("'").Append(id).Append("'").ToString();

        IDataReader dataReader = DBManager.GetInstance().DataBaseRead(sql);
        List<DiceStatus> dices = new List<DiceStatus>();
        DiceCache cache = DiceCache.GetInstance();

        while (dataReader.Read())
        {
       
             for(int i =1; i < dataReader.FieldCount; i++)
            {
                Debug.Log("덱 확인" + dataReader.GetString(i));
                DiceStatus diceStatus = cache.diceCache[dataReader.GetString(i)];
                dices.Add(diceStatus);ㄷ
       
            }

        }

        Deck.GetInstance().decks.Add(id, dices);

    }
}
ㄴ