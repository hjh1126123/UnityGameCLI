using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code._4_Business.State.SimpleState
{
    public class SimpleStateController
    {
        private SimpleState m_state;
        private bool m_stateIsBegin = false;

        private AsyncOperation asyncOp = null;
        public void SetState(SimpleState state)
        {
            m_stateIsBegin = false;

            LoadScene(state.GetSceneName());
            SimpleMediator.GetInstance().Release();

            if (m_state != null)
                m_state.StateEnd();

            m_state = state;
        }

        public void UpdateState()
        {
            if (asyncOp != null && !asyncOp.isDone)
                return;

            if (m_state != null && !m_stateIsBegin)
            {
                m_state.StateBegin();
                m_stateIsBegin = true;
            }

            m_state.StateUpdate();
        }

        /// <summary>
        /// 异步载入场景
        /// </summary>
        /// <param name="sceneName">场景名称</param>
        public void LoadScene(string sceneName)
        {
            if (String.IsNullOrEmpty(sceneName))
                return;

            asyncOp = SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
