using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string npcName;
    public Sprite npcPortrait;
    [TextArea(3, 10)]
    public string[] npcSentences;

    public string playerName;
    public Sprite playerPortrait;
    [TextArea(3, 10)]
    public string[] playerSentences;
}
