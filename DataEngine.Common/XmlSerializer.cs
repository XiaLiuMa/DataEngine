using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace DataEngine.Common
{
    /// <summary>
    /// xml文件序列化助手
    /// </summary>
    public class XmlSerializer
    {
        /// <summary>
        /// 反序列化(xml文件加载到对象)
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public static T Load<T>(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(fs);
            }
            catch (Exception)
            {
                Thread.Sleep(3000);
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(fs);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
        
        /// <summary>
        /// 序列化(对象保存为xml文件)
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件路径</param>
        public static void Save(object obj, string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                var serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
    }
}
