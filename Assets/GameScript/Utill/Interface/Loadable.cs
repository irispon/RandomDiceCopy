using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public interface Loadable
{
    void Load(string path,XmlNodeList node);
}
