using System.Collections;
using System.Collections.Generic;

namespace Assets.Code._4_Business.GameSystem.Memory
{
    public class _Memory : ISystem
    {
        private Dictionary<string, Dictionary<string, object>> MemoryCatalog;

        //init
        public override void Initialize()
        {
            base.Initialize();
            MemoryCatalog = new Dictionary<string, Dictionary<string, object>>();
        }

        //Release
        public override void Release()
        {
            base.Release();
            MemoryCatalog.Clear();
        }

        /// <summary>
        /// 创建内存目录
        /// </summary>
        /// <param name="paragraphTitle"></param>
        protected void CreateMemoryParagraph(string paragraphTitle)
        {
            Dictionary<string, object> itemHeap = new Dictionary<string, object>();
            MemoryCatalog.Add(paragraphTitle, itemHeap);
        }

        /// <summary>
        /// 保存物品
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="itemName"></param>
        /// <param name="item"></param>
        protected void SaveItem(string itemType, string itemName, object item)
        {
            if (!MemoryCatalog.ContainsKey(itemType))
                CreateMemoryParagraph(itemType);

            MemoryCatalog[itemType].Add(itemName, item);
        }

        /// <summary>
        /// 取得物品
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        protected object GetItem(string itemType, string itemName)
        {
            return MemoryCatalog[itemType][itemName];
        }
    }
}
