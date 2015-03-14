﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class LanguageText
{

    private static LanguageText instanceLangue;
    private Dictionary<string, string> dicoUITexts;
    private Dictionary<string, Fact> dicoFacts;
    private Dictionary<string, Queue<string>> dicoHistory;
    private List<string> languageSupported;
    private XmlDocument xml;

    private LanguageText()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("language", typeof(TextAsset));
        xml = new XmlDocument();
        xml.LoadXml(textAsset.text);

        ParseLanguageSupported();
        string defaultLanguage = Application.systemLanguage.ToString();

        if (languageSupported.Contains(defaultLanguage.ToLower()))
        {
            SetLanguage(defaultLanguage);
        }
        else
        {
            SetLanguage("english");
        }
    }



    public static LanguageText Instance
    {
        get
        {
            if (instanceLangue == null)
            {
                instanceLangue = new LanguageText();
            }
            return instanceLangue;
        }
    }



    public string GetUIText(string id)
    {
        if (!dicoUITexts.ContainsKey(id))
        {
            Debug.LogError("The specified UIText does not exist: " + id);
            return "";
        }
        return dicoUITexts[id];
    }

    public Fact GetFact(string id)
    {
        if (!dicoFacts.ContainsKey(id))
        {
            Debug.LogError("The specified fact does not exist: " + id);
            return new Fact("","");
        }
        return dicoFacts[id];
    }

    public Queue<string> GetHistoryTexts(string id)
    {
        if (!dicoHistory.ContainsKey(id))
        {
            Debug.LogError("The specified HistoryText does not exist: " + id);
            return new Queue<string>();
        }
        return new Queue<string>(dicoHistory[id]);
    }


    public void SetLanguage(string language)
    {
        ParseXmlFile(language.ToLower());
    }


    private void ParseLanguageSupported()
    {
        languageSupported = new List<string>();

        XmlElement elementRoot = xml.DocumentElement;

        foreach (XmlNode nodeLangage in elementRoot.ChildNodes)
        {
            languageSupported.Add(nodeLangage.Name);
        }
    }


    private void ParseXmlFile(string language)
    {
        dicoUITexts = new Dictionary<string, string>();
        dicoFacts = new Dictionary<string, Fact>();
        dicoHistory = new Dictionary<string, Queue<string>>();

        XmlElement elementLanguage = xml.DocumentElement[language]; // The xml element <english> for example

        if (elementLanguage != null)
        {

            XmlElement elementUITexts = elementLanguage["uitexts"];
            if (elementUITexts != null)
            {
                foreach (XmlNode nodeUITexts in elementUITexts.ChildNodes)
                {
                    dicoUITexts.Add(nodeUITexts.Attributes["id"].Value, nodeUITexts.InnerText);
                }
            }

            XmlElement elementFacts = elementLanguage["facts"];
            if (elementFacts != null)
            {
                foreach (XmlNode nodeDialog in elementFacts.ChildNodes)
                {
                    dicoFacts.Add(nodeDialog.Attributes["id"].Value, new Fact(nodeDialog.FirstChild.InnerText, nodeDialog.LastChild.InnerText));
                }
            }


            XmlElement elementHistory = elementLanguage["story"];
            if (elementHistory != null)
            {
                foreach (XmlNode nodeDialog in elementHistory.ChildNodes)
                {
                    Queue<string> tmpList = new Queue<string>();
                    foreach (XmlNode nodeStringDialog in nodeDialog.ChildNodes)
                    {
                        tmpList.Enqueue(nodeStringDialog.InnerText);
                    }
                    dicoHistory.Add(nodeDialog.Attributes["id"].Value, tmpList);
                }
            }
        }
        else
        {
            Debug.LogError("Error XML file : element " + language + " not found");
        }

    }
}
