//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Mobile.Crud{
	internal class RecallmCrud {
		///<summary>Gets one Recallm object from the database using primaryKey1(CustomerNum) and primaryKey2.  Returns null if not found.</summary>
		internal static Recallm SelectOne(long customerNum,long recallNum){
			string command="SELECT * FROM recallm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND RecallNum = "+POut.Long(recallNum);
			List<Recallm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Recallm object from the database using a query.</summary>
		internal static Recallm SelectOne(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Recallm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Recallm objects from the database using a query.</summary>
		internal static List<Recallm> SelectMany(string command){
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Recallm> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Recallm> TableToList(DataTable table){
			List<Recallm> retVal=new List<Recallm>();
			Recallm recallm;
			for(int i=0;i<table.Rows.Count;i++) {
				recallm=new Recallm();
				recallm.CustomerNum        = PIn.Long  (table.Rows[i]["CustomerNum"].ToString());
				recallm.RecallNum          = PIn.Long  (table.Rows[i]["RecallNum"].ToString());
				recallm.PatNum             = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				recallm.DateDue            = PIn.Date  (table.Rows[i]["DateDue"].ToString());
				recallm.DatePrevious       = PIn.Date  (table.Rows[i]["DatePrevious"].ToString());
				recallm.RecallStatus       = PIn.Long  (table.Rows[i]["RecallStatus"].ToString());
				recallm.Note               = PIn.String(table.Rows[i]["Note"].ToString());
				recallm.IsDisabled         = PIn.Bool  (table.Rows[i]["IsDisabled"].ToString());
				recallm.DisableUntilBalance= PIn.Double(table.Rows[i]["DisableUntilBalance"].ToString());
				recallm.DisableUntilDate   = PIn.Date  (table.Rows[i]["DisableUntilDate"].ToString());
				retVal.Add(recallm);
			}
			return retVal;
		}

		///<summary>Usually set useExistingPK=true.  Inserts one Recallm into the database.</summary>
		internal static long Insert(Recallm recallm,bool useExistingPK){
			if(!useExistingPK) {
				recallm.RecallNum=ReplicationServers.GetKey("recallm","RecallNum");
			}
			string command="INSERT INTO recallm (";
			command+="RecallNum,";
			command+="CustomerNum,PatNum,DateDue,DatePrevious,RecallStatus,Note,IsDisabled,DisableUntilBalance,DisableUntilDate) VALUES(";
			command+=POut.Long(recallm.RecallNum)+",";
			command+=
				     POut.Long  (recallm.CustomerNum)+","
				+    POut.Long  (recallm.PatNum)+","
				+    POut.Date  (recallm.DateDue)+","
				+    POut.Date  (recallm.DatePrevious)+","
				+    POut.Long  (recallm.RecallStatus)+","
				+"'"+POut.String(recallm.Note)+"',"
				+    POut.Bool  (recallm.IsDisabled)+","
				+"'"+POut.Double(recallm.DisableUntilBalance)+"',"
				+    POut.Date  (recallm.DisableUntilDate)+")";
			Db.NonQ(command);//There is no autoincrement in the mobile server.
			return recallm.RecallNum;
		}

		///<summary>Updates one Recallm in the database.</summary>
		internal static void Update(Recallm recallm){
			string command="UPDATE recallm SET "
				+"PatNum             =  "+POut.Long  (recallm.PatNum)+", "
				+"DateDue            =  "+POut.Date  (recallm.DateDue)+", "
				+"DatePrevious       =  "+POut.Date  (recallm.DatePrevious)+", "
				+"RecallStatus       =  "+POut.Long  (recallm.RecallStatus)+", "
				+"Note               = '"+POut.String(recallm.Note)+"', "
				+"IsDisabled         =  "+POut.Bool  (recallm.IsDisabled)+", "
				+"DisableUntilBalance= '"+POut.Double(recallm.DisableUntilBalance)+"', "
				+"DisableUntilDate   =  "+POut.Date  (recallm.DisableUntilDate)+" "
				+"WHERE CustomerNum = "+POut.Long(recallm.CustomerNum)+" AND RecallNum = "+POut.Long(recallm.RecallNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Recallm from the database.</summary>
		internal static void Delete(long customerNum,long recallNum){
			string command="DELETE FROM recallm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND RecallNum = "+POut.Long(recallNum);
			Db.NonQ(command);
		}

		///<summary>Converts one Recall object to its mobile equivalent.  Warning! CustomerNum will always be 0.</summary>
		internal static Recallm ConvertToM(Recall recall){
			Recallm recallm=new Recallm();
			//CustomerNum cannot be set.  Remains 0.
			recallm.RecallNum          =recall.RecallNum;
			recallm.PatNum             =recall.PatNum;
			recallm.DateDue            =recall.DateDue;
			recallm.DatePrevious       =recall.DatePrevious;
			recallm.RecallStatus       =recall.RecallStatus;
			recallm.Note               =recall.Note;
			recallm.IsDisabled         =recall.IsDisabled;
			recallm.DisableUntilBalance=recall.DisableUntilBalance;
			recallm.DisableUntilDate   =recall.DisableUntilDate;
			return recallm;
		}

	}
}