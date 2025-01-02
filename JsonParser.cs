using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Platformer
{
    public class JsonParser
    {
        private static JObject wholeObject;
        private static string currentFileName;
        public static Rectangle GetRectangle(string fileName, string propertyName)
        {
            if (wholeObject == null || currentFileName == null || currentFileName != fileName)
            {
                GetJObjectFromFile(fileName);
            }

            JObject obj = (JObject)wholeObject.GetValue(propertyName);
            Rectangle rec = GetRectangle(obj);
            return rec;
        }

        public static List<Rectangle> GetRecangleList(string fileName, string propertyName)
        {
            if (wholeObject == null || currentFileName == null || currentFileName != fileName)
            {
                GetJObjectFromFile(fileName);
            }

            List<Rectangle> recList = new List<Rectangle>();
            JArray arrayObject = (JArray)wholeObject.GetValue(propertyName);

            for (int i = 0; i < arrayObject.Count; i++)
            {
                JObject obj = (JObject)arrayObject[i];
                Rectangle rec = GetRectangle(obj);
                recList.Add(rec);
            }

            return recList;
        }

        public static void GetJObjectFromFile(string fileName)
        {
            currentFileName = fileName;
            StreamReader file = File.OpenText(fileName);
            JsonTextReader reader = new JsonTextReader(file);
            wholeObject = JObject.Load(reader);
            file.Close();
        }

        private static Rectangle GetRectangle(JObject obj)
        {
            int x = Convert.ToInt32(obj.GetValue("positionX"));
            int y = Convert.ToInt32(obj.GetValue("positionY"));
            int height = Convert.ToInt32(obj.GetValue("height"));
            int width = Convert.ToInt32(obj.GetValue("width"));
            Rectangle rec = new Rectangle(x, y, width, height);
            return rec;
        }
    }
}
