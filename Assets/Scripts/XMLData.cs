using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace RollABall
{
    public class XMLData : IData<SavedData>
    {
        private readonly string _saveFolder = "Saves";
        private readonly string _fileName = "MySave.txt";
        public string _savePath { get; }

        public XMLData()
        {
            _savePath = Path.Combine(Application.dataPath, _saveFolder, _fileName);
        }

        public void Save(SavedData savedData, string path)
        {
            var xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement("SavedData");
            xmlDoc.AppendChild(rootNode);

            XmlNode coinsElement = xmlDoc.CreateElement("CoinsPositions");
            rootNode.AppendChild(coinsElement);
            XmlNode buffsElement = xmlDoc.CreateElement("BuffsPositions");
            rootNode.AppendChild(buffsElement);
            XmlNode trapsElement = xmlDoc.CreateElement("TrapsPositions");
            rootNode.AppendChild(trapsElement);

            foreach(Coin coin in savedData._coinsList)
            {
                CreatePositionNodes(savedData, xmlDoc, coinsElement, savedData._coinsList, coin);
            }
            foreach (Buff buff in savedData._buffsList)
            {
                CreatePositionNodes(savedData, xmlDoc, buffsElement, savedData._buffsList, buff);
            }
            foreach(Trap trap in savedData._trapsList)
            {
                CreatePositionNodes(savedData, xmlDoc, trapsElement, savedData._trapsList, trap);
            }

            //string date = $"{DateTime.Now:dd-MM-yyyy-HH-mm-ss}.txt";
            //string s = String.Concat(path, date);

            xmlDoc.Save(path);
        }

        private void CreatePositionNodes<T>(SavedData savedData, XmlDocument xmlDoc, XmlNode element, T[] bonusArray, T bonus) where T : Bonus
        {
            string bonusName = Regex.Replace(bonus.name, @"\W", String.Empty);
            bonusName = Regex.Replace(bonusName, @"[0-9]", String.Empty);

            XmlElement node = xmlDoc.CreateElement($"{bonusName}");
            element.AppendChild(node);

            SetPositionAttribute(bonus, node);
        }

        private void SetPositionAttribute<T>(T bonus, XmlElement element) where T : Bonus
        {
            element.SetAttribute("X", bonus.transform.position.x.ToString());
            element.SetAttribute("Y", bonus.transform.position.y.ToString());
            element.SetAttribute("Z", bonus.transform.position.z.ToString());
        }

        public SavedData Load(SavedData savedData, string path)
        {
            var data = new SavedData();
            int coinIndex = 0;
            int trapIndex = 0;
            int buffIndex = 0;

            if(!File.Exists(path)) { throw new FileNotFoundException("File not found"); }

            using (var reader = new XmlTextReader(path))
            { 
                while (reader.Read()) { 
                    switch (reader.Name)
                    {
                        case "Coin":
                            savedData._coinsList[coinIndex].transform.position = new Vector3(
                                float.Parse(reader.GetAttribute("X")), 
                                float.Parse(reader.GetAttribute("Y")), 
                                float.Parse(reader.GetAttribute("Z")));
                            coinIndex++;
                            break; 
                        case "Trap":
                            savedData._trapsList[trapIndex].transform.position = new Vector3(
                                float.Parse(reader.GetAttribute("X")), 
                                float.Parse(reader.GetAttribute("Y")), 
                                float.Parse(reader.GetAttribute("Z")));
                            trapIndex += 1;
                            break; 
                        case "Buff":
                            savedData._buffsList[buffIndex].transform.position = new Vector3(
                                float.Parse(reader.GetAttribute("X")), 
                                float.Parse(reader.GetAttribute("Y")), 
                                float.Parse(reader.GetAttribute("Z")));
                            buffIndex += 1;
                            break;
                    }
                    
                }

            }

            return data;
        }
    }
}
