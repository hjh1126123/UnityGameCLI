using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Assets.Code._3_Service;

namespace Assets.Code._4_Business
{
    public class _Business : _Service
    {
        public virtual void Initialize() { GetUnityEngineHelper().DeBug("【" + DateTime.Now.ToString("yyyy-MM-dd HH:ss:dd") + "】" + GetType().Name + "初始化"); }

        public virtual void Update() { }

        public virtual void Release() { GetUnityEngineHelper().DeBug("【" + DateTime.Now.ToString("yyyy-MM-dd HH:ss:dd") + "】" + GetType().Name + "销毁"); }

        public virtual void Exit() { }
    }
}
