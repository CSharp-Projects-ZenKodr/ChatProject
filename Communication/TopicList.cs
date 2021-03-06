﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Communication
{
    [Serializable]
    public class TopicList : List<Topic>
    {
        public void Serialize()
        {
            Stream stream = File.Open("TopicList.txt", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
            stream.Close();
        }

        public static TopicList Deserialize()
        {
            Stream stream = File.Open("TopicList.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            TopicList topicList = (TopicList)bf.Deserialize(stream);
            stream.Close();
            return topicList;
        }

        public override string ToString()
        {
            if (Count > 0)
            {
                string outStr = "Topic list:\n";
                foreach (Topic topic in this) { outStr += "||-> " + topic + "\n"; }
                return outStr;
            }
            else return "No topic yet";
        }
    }
}
