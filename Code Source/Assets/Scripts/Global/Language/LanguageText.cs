﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class LanguageText
{

    private static LanguageText instanceLangue;
    private Dictionary<string, string> dicoUITexts;
    private Dictionary<string, string> dicoSceneNames;
    private Dictionary<string, Fact> dicoFacts;
    private Dictionary<string, Queue<string>> dicoHistory;
    private Dictionary<string, List<string>> dicoHelp;
    private Dictionary<string, string> dicoJobs;
    private List<string> languageSupported;
    private XmlDocument xml;

    private LanguageText()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("languageNew", typeof(TextAsset));
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

    public string GetSceneName(string id)
    {
        if (!dicoSceneNames.ContainsKey(id))
        {
            Debug.LogError("The specified SceneName does not exist: " + id);
            return "";
        }
        return dicoSceneNames[id];
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
            return new Fact("", "");
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

    public List<string> GetHelpTexts(string id)
    {
        if (!dicoHelp.ContainsKey(id))
        {
            Debug.LogError("The specified HelpText does not exist: " + id);
            return new List<string>();
        }
        return dicoHelp[id];
    }

    public string GetJobDescription(string id)
    {
        if (!dicoJobs.ContainsKey(id))
        {
            Debug.LogError("The specified JobDescription does not exist: " + id);
            return "";
        }
        return dicoJobs[id];
    }



    public void SetLanguage(string language)
    {
        ParseXmlFile(language.ToLower());
    }


    private void ParseLanguageSupported()
    {
        languageSupported = new List<string>();

        XmlElement elementRoot = xml.DocumentElement;
        XmlElement elementUITexts = elementRoot["uitexts"];
        XmlNode elementUIText = elementUITexts.FirstChild;


        foreach (XmlNode nodeLangage in elementUIText.ChildNodes)
        {
            languageSupported.Add(nodeLangage.Name);
        }
    }


    private void ParseXmlFile(string language)
    {
        dicoUITexts = new Dictionary<string, string>();
        dicoFacts = new Dictionary<string, Fact>();
        dicoHistory = new Dictionary<string, Queue<string>>();
        dicoSceneNames = new Dictionary<string, string>();
        dicoHelp = new Dictionary<string, List<string>>();
        dicoJobs = new Dictionary<string, string>();

        XmlElement elementRoot = xml.DocumentElement; // The xml element <english> for example

        if (elementRoot != null)
        {

            XmlElement elementUITexts = elementRoot["uitexts"];
            if (elementUITexts != null)
            {
                foreach (XmlNode nodeUITexts in elementUITexts.ChildNodes)
                {
                    dicoUITexts.Add(nodeUITexts.Attributes["id"].Value, nodeUITexts[language].InnerText);
                }
            }

            XmlElement elementSceneNames = elementRoot["sceneNames"];
            if (elementSceneNames != null)
            {
                foreach (XmlNode nodeSceneNames in elementSceneNames.ChildNodes)
                {
                    dicoSceneNames.Add(nodeSceneNames.Attributes["id"].Value, nodeSceneNames[language].InnerText);
                }
            }

            XmlElement elementFacts = elementRoot["facts"];
            if (elementFacts != null)
            {
                foreach (XmlNode nodeDialog in elementFacts.ChildNodes)
                {
                    if (nodeDialog.Name != "#comment")
                    {
                        dicoFacts.Add(nodeDialog.Attributes["id"].Value, new Fact(nodeDialog[language].InnerText, nodeDialog.LastChild.InnerText));
                    }
                }
            }


            XmlElement elementHistory = elementRoot["story"];
            if (elementHistory != null)
            {
                foreach (XmlNode nodeDialog in elementHistory.ChildNodes)
                {
                    Queue<string> tmpList = new Queue<string>();
                    foreach (XmlNode nodeStringDialog in nodeDialog.ChildNodes)
                    {
                        if (nodeStringDialog.Name == language)
                            tmpList.Enqueue(nodeStringDialog.InnerText);
                    }
                    dicoHistory.Add(nodeDialog.Attributes["id"].Value, tmpList);
                }
            }


            XmlElement elementHelp = elementRoot["help"];
            if (elementHelp != null)
            {
                foreach (XmlNode nodeDialog in elementHelp.ChildNodes)
                {
                    List<string> tmpList = new List<string>();
                    foreach (XmlNode nodeStringDialog in nodeDialog.ChildNodes)
                    {
                        if (nodeStringDialog.Name == language)
                            tmpList.Add(nodeStringDialog.InnerText);
                    }
                    dicoHelp.Add(nodeDialog.Attributes["id"].Value, tmpList);
                }
            }

            XmlElement elementJobs = elementRoot["jobsDescription"];
            if (elementJobs != null)
            {
                foreach (XmlNode nodeDialog in elementJobs.ChildNodes)
                {
                        dicoJobs.Add(nodeDialog.Attributes["id"].Value, nodeDialog[language].InnerText);
                }
            }
        }
        else
        {
            Debug.LogError("Error XML file : element " + language + " not found");
        }

    }
}
