using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Assets.Code._1_Infrastructure.Base;

namespace Assets.Code._1_Infrastructure.Tool
{
    public class XMLHelper
    {
        private string xmlSavePath;

        private static XMLHelper _instance;
        public static XMLHelper GetInstance()
        {
            if (_instance == null)
                _instance = new XMLHelper();

            return _instance;
        }
        private XMLHelper()
        {
            xmlSavePath = UnityEngine.Application.streamingAssetsPath + "/";
        }

        /// <summary>
        /// 创建XML文档
        /// </summary>
        /// <param name="_xmlFileName">XML根节点以及XML文件名</param>
        /// <returns></returns>
        public string CreateDataToXML(string _xmlFileName)
        {
            if (string.IsNullOrEmpty(xmlSavePath))
                return "保存路径不存在";

            if (File.Exists(xmlSavePath + _xmlFileName))
                return "文件已存在";

            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(dec);
                XmlElement root = doc.CreateElement(_xmlFileName);
                doc.AppendChild(root);


                doc.Save(xmlSavePath + _xmlFileName + ".xml");
            }
            catch (XmlException xmlEx)
            {
                return xmlEx.Message;
            }

            return "创建数据成功";
        }

        /// <summary>
        /// 对XML添加数据
        /// </summary>
        /// <param name="_xmlFileName">XML文件名</param>
        /// <param name="_childName">XML节点名称</param>
        /// <param name="_CusSymbol">自定义分割标记</param>
        /// <param name="Datas">XML数据</param>
        /// <returns></returns>
        public string AddDataToXML<Model>(string _xmlFileName, string _childName, string _id, Model _M)
        {
            CreateDataToXML(_xmlFileName);

            XmlDocument _doc = new XmlDocument();
            _doc.Load(xmlSavePath + _xmlFileName + ".xml");
            XmlElement _root = _doc.DocumentElement;

            #region 查重
            for (int _coount = 0; _coount < _root.ChildNodes.Count; _coount++)
            {
                var childNodeName = _root.ChildNodes[_coount].Name;
                var childNodeId = _root.ChildNodes[_coount].Attributes["id"];
                if (childNodeName.Equals(_childName) && childNodeId.Equals(_id))
                {
                    return "重复";
                }
            }
            #endregion

            XmlElement _child = _doc.CreateElement(KeyHelper.GetInstance().EncryptData(_childName));
            _child.SetAttribute("id", KeyHelper.GetInstance().EncryptData(_id));

            List<string> _proL = ReflectionHelper.GetInstance().GetAllProName<Model>();
            foreach (var _p in _proL)
            {
                XmlElement _xEle = _doc.CreateElement(KeyHelper.GetInstance().EncryptData(_p));
                XmlText _xTxt = _doc.CreateTextNode(KeyHelper.GetInstance().EncryptData(ReflectionHelper.GetInstance().GetPropertyValue(_p, _M)));
                _xEle.AppendChild(_xTxt);
                _child.AppendChild(_xEle);
            }

            _root.AppendChild(_child);
            _doc.Save(xmlSavePath + _xmlFileName + ".xml");

            return "添加数据完成";
        }

        public Model GetDataFromXml<Model>(string xmlFileName, string childNode, string id) where Model : new()
        {
            XDocument _document = XDocument.Load(xmlSavePath + xmlFileName + ".xml");
            List<XElement> _XEleList = _document.Root.Elements(KeyHelper.GetInstance().EncryptData(childNode)).ToList();
            List<string> proNameList = ReflectionHelper.GetInstance().GetAllProName<Model>();
            Model _M = new Model();
            foreach (var _XEle in _XEleList)
            {
                if (_XEle.Attribute("id").Value.Equals(KeyHelper.GetInstance().EncryptData(id)))
                {
                    List<XElement> _childXEleList = _XEle.Elements().ToList();
                    foreach (var _childXEle in _childXEleList)
                    {
                        foreach (var _proName in proNameList)
                        {
                            if (_proName.Equals(KeyHelper.GetInstance().DecryptData(_childXEle.Name.ToString())))
                            {
                                ReflectionHelper.GetInstance().SetPropertyValue(_proName, KeyHelper.GetInstance().DecryptData(_childXEle.Value), _M);
                            }
                        }
                    }
                }
            }
            return _M;
        }
    }
}
