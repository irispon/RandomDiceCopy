using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


/*스프라이트 => png 파일로 바꿔주는 유틸임. 찾아도 안보이길래 직접 만들었음.
 사용법은 이 스크립트가 들어간 오브젝트 만들고 원하는 스프라이트들 넣고 실행 돌리면 됨*/
public class SpriteSpliter : MonoBehaviour
{
    public Sprite[] sprites;



    // Start is called before the first frame update
    void Start()
    {
        Sprite2TextureFile(sprites);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    ///  스프라이트를 텍스쳐들로 분리해주는 함수. sprite 언팩킹 용도입니다.
    /// </summary>
    /// <param name="lbl"></param>

    public static void Sprite2TextureFile(Sprite[] sprites)
    {
        Texture2D SpriteTexture;
        Texture2D texture; ;
        int i = 0;
       
        foreach (Sprite sprite in sprites)
        {
            try
            {
                texture = sprite.texture;
                
                SpriteTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);


                int width = (int)sprite.textureRect.width ;
                int height = (int)sprite.textureRect.height;
                int arraySize =width*height+1;

                Color[] c = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                             (int)sprite.textureRect.y,
                                             (int)sprite.rect.width,
                                             (int)sprite.rect.height);





                SpriteTexture.SetPixels(c);
                SpriteTexture.Apply();

                /*


                var tImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
                if (tImporter != null)
                {
                    tImporter.textureType = TextureImporterType.Advanced;

                    tImporter.isReadable = true;

                    AssetDatabase.ImportAsset(assetPath);
                    AssetDatabase.Refresh();
                }


                 */




                ByteArrayToFile("sprite" + i + ".png", SpriteTexture.EncodeToPNG());
                i++;

            }
            catch (Exception e)
            {

                Debug.Log("d" + e);
            }


        }


    }

    private static bool ByteArrayToFile(string fileName, byte[] byteArray)
    {
        try
        {

            Debug.Log("./Splites/" + fileName);
            FileManager.CreatFolder("Splites");
           
            using (var fs = new FileStream("./Splites/" + fileName, FileMode.Create, FileAccess.Write))
            {
               
                fs.Write(byteArray, 0, byteArray.Length);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.Log("파일 변경 실패"+ex);
            return false;
        }
    }

}
