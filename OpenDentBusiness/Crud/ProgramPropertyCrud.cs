//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class ProgramPropertyCrud {
		///<summary>Gets one ProgramProperty object from the database using the primary key.  Returns null if not found.</summary>
		public static ProgramProperty SelectOne(long programPropertyNum) {
			string command="SELECT * FROM programproperty "
				+"WHERE ProgramPropertyNum = "+POut.Long(programPropertyNum);
			List<ProgramProperty> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ProgramProperty object from the database using a query.</summary>
		public static ProgramProperty SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ProgramProperty> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ProgramProperty objects from the database using a query.</summary>
		public static List<ProgramProperty> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ProgramProperty> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ProgramProperty> TableToList(DataTable table) {
			List<ProgramProperty> retVal=new List<ProgramProperty>();
			ProgramProperty programProperty;
			foreach(DataRow row in table.Rows) {
				programProperty=new ProgramProperty();
				programProperty.ProgramPropertyNum= PIn.Long  (row["ProgramPropertyNum"].ToString());
				programProperty.ProgramNum        = PIn.Long  (row["ProgramNum"].ToString());
				programProperty.PropertyDesc      = PIn.String(row["PropertyDesc"].ToString());
				programProperty.PropertyValue     = PIn.String(row["PropertyValue"].ToString());
				programProperty.ComputerName      = PIn.String(row["ComputerName"].ToString());
				programProperty.ClinicNum         = PIn.Long  (row["ClinicNum"].ToString());
				programProperty.IsMasked          = PIn.Bool  (row["IsMasked"].ToString());
				programProperty.IsHighSecurity    = PIn.Bool  (row["IsHighSecurity"].ToString());
				retVal.Add(programProperty);
			}
			return retVal;
		}

		///<summary>Converts a list of ProgramProperty into a DataTable.</summary>
		public static DataTable ListToTable(List<ProgramProperty> listProgramPropertys,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ProgramProperty";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ProgramPropertyNum");
			table.Columns.Add("ProgramNum");
			table.Columns.Add("PropertyDesc");
			table.Columns.Add("PropertyValue");
			table.Columns.Add("ComputerName");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("IsMasked");
			table.Columns.Add("IsHighSecurity");
			foreach(ProgramProperty programProperty in listProgramPropertys) {
				table.Rows.Add(new object[] {
					POut.Long  (programProperty.ProgramPropertyNum),
					POut.Long  (programProperty.ProgramNum),
					            programProperty.PropertyDesc,
					            programProperty.PropertyValue,
					            programProperty.ComputerName,
					POut.Long  (programProperty.ClinicNum),
					POut.Bool  (programProperty.IsMasked),
					POut.Bool  (programProperty.IsHighSecurity),
				});
			}
			return table;
		}

		///<summary>Inserts one ProgramProperty into the database.  Returns the new priKey.</summary>
		public static long Insert(ProgramProperty programProperty) {
			return Insert(programProperty,false);
		}

		///<summary>Inserts one ProgramProperty into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ProgramProperty programProperty,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				programProperty.ProgramPropertyNum=ReplicationServers.GetKey("programproperty","ProgramPropertyNum");
			}
			string command="INSERT INTO programproperty (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ProgramPropertyNum,";
			}
			command+="ProgramNum,PropertyDesc,PropertyValue,ComputerName,ClinicNum,IsMasked,IsHighSecurity) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(programProperty.ProgramPropertyNum)+",";
			}
			command+=
				     POut.Long  (programProperty.ProgramNum)+","
				+"'"+POut.String(programProperty.PropertyDesc)+"',"
				+    DbHelper.ParamChar+"paramPropertyValue,"
				+"'"+POut.String(programProperty.ComputerName)+"',"
				+    POut.Long  (programProperty.ClinicNum)+","
				+    POut.Bool  (programProperty.IsMasked)+","
				+    POut.Bool  (programProperty.IsHighSecurity)+")";
			if(programProperty.PropertyValue==null) {
				programProperty.PropertyValue="";
			}
			OdSqlParameter paramPropertyValue=new OdSqlParameter("paramPropertyValue",OdDbType.Text,POut.StringParam(programProperty.PropertyValue));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramPropertyValue);
			}
			else {
				programProperty.ProgramPropertyNum=Db.NonQ(command,true,"ProgramPropertyNum","programProperty",paramPropertyValue);
			}
			return programProperty.ProgramPropertyNum;
		}

		///<summary>Inserts many ProgramPropertys into the database.</summary>
		public static void InsertMany(List<ProgramProperty> listProgramPropertys) {
			InsertMany(listProgramPropertys,false);
		}

		///<summary>Inserts many ProgramPropertys into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<ProgramProperty> listProgramPropertys,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(ProgramProperty programProperty in listProgramPropertys) {
					Insert(programProperty);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listProgramPropertys.Count) {
					ProgramProperty programProperty=listProgramPropertys[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO programproperty (");
						if(useExistingPK) {
							sbCommands.Append("ProgramPropertyNum,");
						}
						sbCommands.Append("ProgramNum,PropertyDesc,PropertyValue,ComputerName,ClinicNum,IsMasked,IsHighSecurity) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(programProperty.ProgramPropertyNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(programProperty.ProgramNum)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(programProperty.PropertyDesc)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(programProperty.PropertyValue)+"'"); sbRow.Append(",");
					sbRow.Append("'"+POut.String(programProperty.ComputerName)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(programProperty.ClinicNum)); sbRow.Append(",");
					sbRow.Append(POut.Bool(programProperty.IsMasked)); sbRow.Append(",");
					sbRow.Append(POut.Bool(programProperty.IsHighSecurity)); sbRow.Append(")");
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Db.NonQ(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listProgramPropertys.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one ProgramProperty into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProgramProperty programProperty) {
			return InsertNoCache(programProperty,false);
		}

		///<summary>Inserts one ProgramProperty into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ProgramProperty programProperty,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO programproperty (";
			if(!useExistingPK && isRandomKeys) {
				programProperty.ProgramPropertyNum=ReplicationServers.GetKeyNoCache("programproperty","ProgramPropertyNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ProgramPropertyNum,";
			}
			command+="ProgramNum,PropertyDesc,PropertyValue,ComputerName,ClinicNum,IsMasked,IsHighSecurity) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(programProperty.ProgramPropertyNum)+",";
			}
			command+=
				     POut.Long  (programProperty.ProgramNum)+","
				+"'"+POut.String(programProperty.PropertyDesc)+"',"
				+    DbHelper.ParamChar+"paramPropertyValue,"
				+"'"+POut.String(programProperty.ComputerName)+"',"
				+    POut.Long  (programProperty.ClinicNum)+","
				+    POut.Bool  (programProperty.IsMasked)+","
				+    POut.Bool  (programProperty.IsHighSecurity)+")";
			if(programProperty.PropertyValue==null) {
				programProperty.PropertyValue="";
			}
			OdSqlParameter paramPropertyValue=new OdSqlParameter("paramPropertyValue",OdDbType.Text,POut.StringParam(programProperty.PropertyValue));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramPropertyValue);
			}
			else {
				programProperty.ProgramPropertyNum=Db.NonQ(command,true,"ProgramPropertyNum","programProperty",paramPropertyValue);
			}
			return programProperty.ProgramPropertyNum;
		}

		///<summary>Updates one ProgramProperty in the database.</summary>
		public static void Update(ProgramProperty programProperty) {
			string command="UPDATE programproperty SET "
				+"ProgramNum        =  "+POut.Long  (programProperty.ProgramNum)+", "
				+"PropertyDesc      = '"+POut.String(programProperty.PropertyDesc)+"', "
				+"PropertyValue     =  "+DbHelper.ParamChar+"paramPropertyValue, "
				+"ComputerName      = '"+POut.String(programProperty.ComputerName)+"', "
				+"ClinicNum         =  "+POut.Long  (programProperty.ClinicNum)+", "
				+"IsMasked          =  "+POut.Bool  (programProperty.IsMasked)+", "
				+"IsHighSecurity    =  "+POut.Bool  (programProperty.IsHighSecurity)+" "
				+"WHERE ProgramPropertyNum = "+POut.Long(programProperty.ProgramPropertyNum);
			if(programProperty.PropertyValue==null) {
				programProperty.PropertyValue="";
			}
			OdSqlParameter paramPropertyValue=new OdSqlParameter("paramPropertyValue",OdDbType.Text,POut.StringParam(programProperty.PropertyValue));
			Db.NonQ(command,paramPropertyValue);
		}

		///<summary>Updates one ProgramProperty in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ProgramProperty programProperty,ProgramProperty oldProgramProperty) {
			string command="";
			if(programProperty.ProgramNum != oldProgramProperty.ProgramNum) {
				if(command!="") { command+=",";}
				command+="ProgramNum = "+POut.Long(programProperty.ProgramNum)+"";
			}
			if(programProperty.PropertyDesc != oldProgramProperty.PropertyDesc) {
				if(command!="") { command+=",";}
				command+="PropertyDesc = '"+POut.String(programProperty.PropertyDesc)+"'";
			}
			if(programProperty.PropertyValue != oldProgramProperty.PropertyValue) {
				if(command!="") { command+=",";}
				command+="PropertyValue = "+DbHelper.ParamChar+"paramPropertyValue";
			}
			if(programProperty.ComputerName != oldProgramProperty.ComputerName) {
				if(command!="") { command+=",";}
				command+="ComputerName = '"+POut.String(programProperty.ComputerName)+"'";
			}
			if(programProperty.ClinicNum != oldProgramProperty.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(programProperty.ClinicNum)+"";
			}
			if(programProperty.IsMasked != oldProgramProperty.IsMasked) {
				if(command!="") { command+=",";}
				command+="IsMasked = "+POut.Bool(programProperty.IsMasked)+"";
			}
			if(programProperty.IsHighSecurity != oldProgramProperty.IsHighSecurity) {
				if(command!="") { command+=",";}
				command+="IsHighSecurity = "+POut.Bool(programProperty.IsHighSecurity)+"";
			}
			if(command=="") {
				return false;
			}
			if(programProperty.PropertyValue==null) {
				programProperty.PropertyValue="";
			}
			OdSqlParameter paramPropertyValue=new OdSqlParameter("paramPropertyValue",OdDbType.Text,POut.StringParam(programProperty.PropertyValue));
			command="UPDATE programproperty SET "+command
				+" WHERE ProgramPropertyNum = "+POut.Long(programProperty.ProgramPropertyNum);
			Db.NonQ(command,paramPropertyValue);
			return true;
		}

		///<summary>Returns true if Update(ProgramProperty,ProgramProperty) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ProgramProperty programProperty,ProgramProperty oldProgramProperty) {
			if(programProperty.ProgramNum != oldProgramProperty.ProgramNum) {
				return true;
			}
			if(programProperty.PropertyDesc != oldProgramProperty.PropertyDesc) {
				return true;
			}
			if(programProperty.PropertyValue != oldProgramProperty.PropertyValue) {
				return true;
			}
			if(programProperty.ComputerName != oldProgramProperty.ComputerName) {
				return true;
			}
			if(programProperty.ClinicNum != oldProgramProperty.ClinicNum) {
				return true;
			}
			if(programProperty.IsMasked != oldProgramProperty.IsMasked) {
				return true;
			}
			if(programProperty.IsHighSecurity != oldProgramProperty.IsHighSecurity) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ProgramProperty from the database.</summary>
		public static void Delete(long programPropertyNum) {
			string command="DELETE FROM programproperty "
				+"WHERE ProgramPropertyNum = "+POut.Long(programPropertyNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many ProgramPropertys from the database.</summary>
		public static void DeleteMany(List<long> listProgramPropertyNums) {
			if(listProgramPropertyNums==null || listProgramPropertyNums.Count==0) {
				return;
			}
			string command="DELETE FROM programproperty "
				+"WHERE ProgramPropertyNum IN("+string.Join(",",listProgramPropertyNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<ProgramProperty> listNew,List<ProgramProperty> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<ProgramProperty> listIns    =new List<ProgramProperty>();
			List<ProgramProperty> listUpdNew =new List<ProgramProperty>();
			List<ProgramProperty> listUpdDB  =new List<ProgramProperty>();
			List<ProgramProperty> listDel    =new List<ProgramProperty>();
			listNew.Sort((ProgramProperty x,ProgramProperty y) => { return x.ProgramPropertyNum.CompareTo(y.ProgramPropertyNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((ProgramProperty x,ProgramProperty y) => { return x.ProgramPropertyNum.CompareTo(y.ProgramPropertyNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			ProgramProperty fieldNew;
			ProgramProperty fieldDB;
			//Because both lists have been sorted using the same criteria, we can now walk each list to determine which list contians the next element.  The next element is determined by Primary Key.
			//If the New list contains the next item it will be inserted.  If the DB contains the next item, it will be deleted.  If both lists contain the next item, the item will be updated.
			while(idxNew<listNew.Count || idxDB<listDB.Count) {
				fieldNew=null;
				if(idxNew<listNew.Count) {
					fieldNew=listNew[idxNew];
				}
				fieldDB=null;
				if(idxDB<listDB.Count) {
					fieldDB=listDB[idxDB];
				}
				//begin compare
				if(fieldNew!=null && fieldDB==null) {//listNew has more items, listDB does not.
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew==null && fieldDB!=null) {//listDB has more items, listNew does not.
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				else if(fieldNew.ProgramPropertyNum<fieldDB.ProgramPropertyNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.ProgramPropertyNum>fieldDB.ProgramPropertyNum) {//dbPK less than newPK, dbItem is 'next'
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				//Both lists contain the 'next' item, update required
				listUpdNew.Add(fieldNew);
				listUpdDB.Add(fieldDB);
				idxNew++;
				idxDB++;
			}
			//Commit changes to DB
			for(int i=0;i<listIns.Count;i++) {
				Insert(listIns[i]);
			}
			for(int i=0;i<listUpdNew.Count;i++) {
				if(Update(listUpdNew[i],listUpdDB[i])) {
					rowsUpdatedCount++;
				}
			}
			DeleteMany(listDel.Select(x => x.ProgramPropertyNum).ToList());
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}