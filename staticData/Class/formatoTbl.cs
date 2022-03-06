using System;
using System.Data;


namespace Binario.Class
{
	/// <summary>
	/// Description of formatoTbl.
	/// </summary>
	public class formatoTbl
	{
		public formatoTbl()
		{
		}
		
		
		public static DataTable formatoM1()
		{
			DataTable tbl = new DataTable();
			tbl.Columns.Add("id", typeof(string));
            tbl.Columns.Add("name", typeof(string));
            tbl.Columns.Add("LookEx", typeof(string));	
			tbl.Columns.Add("Look", typeof(string));
			tbl.Columns.Add("Head", typeof(string));
			tbl.Columns.Add("Body", typeof(string));
			tbl.Columns.Add("Legs", typeof(string));
			tbl.Columns.Add("Feet", typeof(string));
			tbl.Columns.Add("Addon", typeof(string));
			return tbl;
		}	
		
		public static DataTable formatoA1()
		{
			DataTable tbl = new DataTable();
			tbl.Columns.Add("id", typeof(string));
            tbl.Columns.Add("name", typeof(string));
            tbl.Columns.Add("description", typeof(string));	
			tbl.Columns.Add("grade", typeof(string));
			return tbl;
		}
		
		public static DataTable formatoH1()
		{
			DataTable tbl = new DataTable();
			tbl.Columns.Add("id", typeof(string));
            tbl.Columns.Add("name", typeof(string));
            tbl.Columns.Add("description", typeof(string));	
			tbl.Columns.Add("rent", typeof(string));
			tbl.Columns.Add("beds", typeof(string));
			tbl.Columns.Add("posX", typeof(string));
			tbl.Columns.Add("posY", typeof(string));
			tbl.Columns.Add("posZ", typeof(string));
			tbl.Columns.Add("sqm", typeof(string));
			tbl.Columns.Add("GH", typeof(string));
			tbl.Columns.Add("city", typeof(string));
			tbl.Columns.Add("shop", typeof(string));
			return tbl;
		}
		
		public static DataTable formatoB1()
		{
			DataTable tbl = new DataTable();
			tbl.Columns.Add("id", typeof(string));
            tbl.Columns.Add("name", typeof(string));
			return tbl;
		}
		
		public static DataTable formatoQ1()
		{
			DataTable tbl = new DataTable();
			tbl.Columns.Add("id", typeof(string));
            tbl.Columns.Add("name", typeof(string));
			return tbl;
		}
		
	}
}
