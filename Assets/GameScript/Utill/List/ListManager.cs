using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListManager : MonoBehaviour
{
    [SerializeField]
    GameObject listObject, container,parent;
    GameObject content;
   
    List<IListObjectInfo> infos;


    private void Awake()
    {
       
        infos = new List<IListObjectInfo>();
        content = null;
    }

    public void AddInfo(IListObjectInfo info)
    {
        this.infos.Add(info);

        if (content == null)
        {
            NotifyChangeList();
        }
        else
        {
            AddPanel(info);
        }
        

    }
    public void setInfos(List<IListObjectInfo> infos)
    {

        this.infos = new List<IListObjectInfo>(infos);
        NotifyChangeList();
    }

    public void AddInfos(List<IListObjectInfo> infos)
    {
        foreach (IListObjectInfo info in infos)
        {
            AddInfo(info);

        }
    }

    public virtual void NotifyChangeList()
    {
        Destroy(content);
        Debug.Log("노티파잉");
        content = Instantiate(container);
        SizeFitter.FittingContent(content, parent);
        SizeFitter.FittingSize(content);
        if(this.GetComponentInChildren<ScrollRect>() != null)
        {
         
            this.GetComponentInChildren<ScrollRect>().content = content.GetComponent<RectTransform>(); 
            
     
        }
        foreach (IListObjectInfo info in infos)
        {
            AddPanel(info);

        }
    }

    protected virtual void AddPanel(IListObjectInfo info)
    {

        Debug.Log("AddPanel");
        GameObject panel = Instantiate(this.listObject);
        ControlPanel containePanel;
        containePanel = panel.GetComponent<ControlPanel>();
        if (info.GetOption().Title)
        {
            Debug.Log(info.GetTitle());
            containePanel.SetText(info.GetTitle());
        }
        if (info.GetOption().SubTitle)
        {
            Debug.Log(info.GetSubTitle());
            containePanel.SetSubText(info.GetSubTitle());
        }
        if (info.GetOption().Sprite)
        {
            containePanel.SetSprite(info.GetSprite());
        }

        panel.transform.SetParent(content.transform);
        SizeFitter.FittingSize(panel);

    }
}
