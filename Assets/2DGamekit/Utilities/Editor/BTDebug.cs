using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace Gamekit2D
{
    public class BTDebug : EditorWindow
    {
        private object _currentRoot;

        [MenuItem("Kit Tools/Behaviour Tree Debug")]
        static void OpenWindow()
        {
            BTDebug btdebug = GetWindow<BTDebug>();
            btdebug.Show();
        }

        private void OnGUI()
        {
            if (!Application.isPlaying)
            {
                EditorGUILayout.HelpBox("Only work during play mode.", MessageType.Info);
            }
            else
            {
                if (_currentRoot == null)
                    FindRoot();
                else
                {
                    RecursiveTreeParsing(_currentRoot, 0, true);
                }
            }
        }

        private void RecursiveTreeParsing(object currentRoot, int v1, bool v2)
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            Repaint();
        }

        void FindRoot()
        {
            if (Selection.activeGameObject == null)
            {
                _currentRoot = null;
                return;
            }

            IBTDebugable debugable = Selection.activeGameObject.GetComponentInChildren<IBTDebugable>();

            if(debugable != null)
            {
            }
        }

    }
}