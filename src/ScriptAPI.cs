﻿using ScriptNET.Runtime;
using System.IO;

namespace FiestaShark {
	public sealed class ScriptAPI {
		private StructureForm mStructure = null;

		[Bindable(false)]
		internal ScriptAPI(StructureForm pStructure) { mStructure = pStructure; }

		public byte GetEquipTypeByItemID(ushort ItemID) { return mStructure.APIGetEquipTypeByItemID(ItemID); }
		public byte GetItemTypeByID(ushort ItemID) {
			return mStructure.APIGetItemTypeByID(ItemID);
		}
		public byte GetItemTypeByName(string InxName) {
			return mStructure.APIGetItemTypeByName(InxName);
		}
		public bool IsItemTwoHand(ushort ItemID) {
			return mStructure.APIIsItemTwoHand(ItemID);
		}
		public byte GetItemClassByName(string ItemInxName) {
			return mStructure.APIGetItemClassByName(ItemInxName);
		}
		public byte GetItemClassByID(ushort ItemID) {
			return mStructure.APIGetItemClassByID(ItemID);
		}
		public long AddByte(string pName) {
			return mStructure.APIAddByte(pName);
		}
		public long AddSByte(string pName) {
			return mStructure.APIAddSByte(pName);
		}
		public long AddUShort(string pName) {
			return mStructure.APIAddUShort(pName);
		}
		public long AddShort(string pName) {
			return mStructure.APIAddShort(pName);
		}
		public long AddUInt(string pName) {
			return mStructure.APIAddUInt(pName);
		}
		public long AddInt(string pName) {
			return mStructure.APIAddInt(pName);
		}
		public long AddLong(string pName) {
			return mStructure.APIAddLong(pName);
		}
		public double AddFloat(string pName) {
			return mStructure.APIAddFloat(pName);
		}
		public double AddDouble(string pName) {
			return mStructure.APIAddDouble(pName);
		}
		public string AddString(string pName) {
			return mStructure.APIAddString(pName);
		}
		public string AddPaddedString(string pName, int pLength) {
			return mStructure.APIAddPaddedString(pName, pLength);
		}
		public void AddField(string pName, int pLength) {
			mStructure.APIAddField(pName, pLength);
		}
		public void AddComment(string pComment) {
			mStructure.APIAddComment(pComment);
		}
		public void StartNode(string pName) {
			mStructure.APIStartNode(pName);
		}
		public void EndNode(bool pExpand) {
			mStructure.APIEndNode(pExpand);
		}
		public void Write(string pPath, string pLine) {
			using (StreamWriter writer = File.AppendText(pPath)) writer.WriteLine(pLine);
		}
		public long Remaining() {
			return mStructure.APIRemaining();
		}
	}
}
