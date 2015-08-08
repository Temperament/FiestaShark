﻿using System;
using System.IO;
using System.Reflection;
using WeifenLuo.WinFormsUI.Docking;

namespace FiestaShark {
	public partial class ScriptForm : DockContent
    {
        private string mPath = "";
        private FiestaPacket mPacket = null;

        public ScriptForm(string pPath, FiestaPacket pPacket)
        {
            mPath = pPath;
            mPacket = pPacket;
            InitializeComponent();
            Text = "Script 0x" + pPacket.Opcode.ToString("X4") + ", " + (pPacket.Outbound ? "Outbound" : "Inbound");
        }

        internal FiestaPacket Packet { get { return mPacket; } }

        private void ScriptForm_Load(object pSender, EventArgs pArgs)
        {
            mScriptEditor.Document.SetSyntaxFromEmbeddedResource(Assembly.GetExecutingAssembly(), "FiestaShark.ScriptSyntax.txt");
            if (File.Exists(mPath)) mScriptEditor.Open(mPath);
        }

        private void mScriptEditor_TextChanged(object pSender, EventArgs pArgs)
        {
            mSaveButton.Enabled = true;
        }

        private void mSaveButton_Click(object pSender, EventArgs pArgs)
        {
            if (mScriptEditor.Document.Text.Length == 0) File.Delete(mPath);
            else mScriptEditor.Save(mPath);
            Close();
        }
    }
}
