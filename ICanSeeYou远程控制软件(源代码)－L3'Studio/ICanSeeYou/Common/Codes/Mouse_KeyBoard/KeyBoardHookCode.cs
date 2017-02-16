using System;
namespace ICanSeeYou.Codes
{
    /// <summary>
    /// º¸≈ÃHook÷∏¡Ó
    /// </summary>
    [Serializable]
    class KeyBoardHookCode : BaseCode
    {
        private System.Windows.Forms.Keys keyCode;
        /// <summary>
        /// º¸÷µ
        /// </summary>
        public System.Windows.Forms.Keys KeyCode
        {
            get { return keyCode; }
            set { keyCode = value; }
        }
    }
}
