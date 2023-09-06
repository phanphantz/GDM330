using System.Collections.Generic;
using PhEngine.Core;
using UnityEngine;

namespace SuperGame
{
    public class InputManager : Singleton<InputManager>
    {
        [SerializeField] string horizontalKey = "Horizontal";
        [SerializeField] KeyCode leftKey;
        [SerializeField] KeyCode rightKey;
        [SerializeField] List<KeyCode> jumpKeyList = new List<KeyCode>();
       
        public float HorizontalInput => horizontalInput;
        float horizontalInput;

        public bool IsJump => isJump;
        bool isJump;

        public bool IsLeftKeyDown { get; private set; }
        public bool IsRightKeyDown { get; private set; }
        
        protected override void InitAfterAwake()
        {
        }

        void Update()
        {
           horizontalInput = Input.GetAxis(horizontalKey);
           IsLeftKeyDown = Input.GetKeyDown(leftKey);
           IsRightKeyDown = Input.GetKeyDown(rightKey);

           isJump = false;
           foreach (var keyCode in jumpKeyList)
           {
               if (Input.GetKeyDown(keyCode))
                   isJump = true;
           }
        }
    }
}