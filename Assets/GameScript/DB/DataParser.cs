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

                diceStatus.attackType.ofensiveType = EnumUtills.Parse<OfensiveType>(dataReader.GetString(2));
                diceStatus.attackType.damageType = EnumUtills.Parse<DamageType>(dataReader.GetString(3));
                diceStatus.attackType.target = EnumUtills.Parse<Target>(dataReader.GetString(4));
                diceStatus.attackType.damage = dataReader.GetFloat(5);
                diceStatus.attackType.attackSpeed = dataReader.GetFloat(6);
                diceStatus.attackType.diffusion = dataReader.GetFloat(7);
                diceStatus.attackType.range = dataReader.GetInt32(8);
                diceStatus.describe = dataReader.GetString(9);

                DiceCache.GetInstance().diceCache.Add(diceStatus.diceName, diceStatus);
            }
            catch (Exception e)
            {
                Debug.Log("데이터 파싱 에러"+e);
            }


        }


    }

    public void DeckParser(string id)
    {
        Debug.Log("아이디 인증 과정 생략");

        string sql = stringBuilder.Append("SELECT*FROM Player WHERE Player =").Append("'").Append(id).Append("'").ToString();
        stringBuilder.Clear();
        IDataReader dataReader = DBManager.GetInstance().DataBaseRead(sql);
        List<DiceStatus> dices = new List<DiceStatus>();
        DiceCache cache = DiceCache.GetInstance();

        while (dataReader.Read())
        {
       
             for(int i =1; i < dataReader.FieldCount; i++)
            {
                Debug.Log("덱 확인" + dataReader.GetString(i));
                DiceStatus diceStatus = cache.diceCache[dataReader.GetString(i)];
                dices.Add(diceStatus);
       
            }

        }

        Deck.GetInstance().decks.Add(id, dices);

    }
}
