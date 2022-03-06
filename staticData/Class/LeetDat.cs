using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.Text;
using System.IO;

namespace Binario.Class
{

	class LeetDat
	{
		
		public LeetDat()
		{
		}
				
		
		
		public static DataTable leer(string ruta)
		{
			DataTable tbl = new DataTable();	
			tbl.Columns.Add("id", typeof(string));
            tbl.Columns.Add("name", typeof(string));
			tbl.Columns.Add("Look", typeof(string));
			tbl.Columns.Add("Body", typeof(string));
			tbl.Columns.Add("Legs", typeof(string));
			tbl.Columns.Add("Feet", typeof(string));
			tbl.Columns.Add("Addon", typeof(string));
			
			FileStream fs = new FileStream(ruta, FileMode.Open);
			BinaryReader r = new BinaryReader(fs);
			int id;
			int count;
			string name;
			int Look;
			int Body;
			int Legs;
			int Feet;
			int Addon;
			int aux;
			
			try
			{
				for (int i = 0; i<100;i++)
				{
					name = "";
					r.ReadByte();
					r.ReadInt16();
					id = r.ReadByte();	
					r.ReadByte();	
					count = r.ReadByte();	
					for(int x = 0; x<count;x++)
					{
						name = name + (char)r.ReadByte();
					}
					
					r.ReadByte();
					aux = r.ReadByte();
					r.ReadByte();
					Look = r.ReadByte();					
					if(aux == 16 || aux == 15 ){r.ReadByte();}
					
					r.ReadInt16();
					r.ReadInt16();
					r.ReadByte();
					Body = r.ReadByte();
					r.ReadByte();
					Legs = r.ReadByte();
					if(aux == 16){r.ReadByte();}
					r.ReadByte();
					Feet = r.ReadByte();
					r.ReadByte();
					Addon = r.ReadByte();
					
					tbl.Rows.Add(id,name,Look,Body,Legs,Feet,Addon);
					
				}				
			}
			catch (Exception e)
	        {
				MessageBox.Show(e.ToString());
	        }
			finally
			{
				r.Close();
				fs.Close();
			}
			
			
			
			
			
			
			return tbl;
		}	
		
		public static DataTable leer2(string ruta)
		{
			DataTable tbl = new DataTable();	
			tbl.Columns.Add("hex", typeof(string));
            tbl.Columns.Add("str", typeof(string));
			
			FileStream fs = new FileStream(ruta, FileMode.Open);
			BinaryReader r = new BinaryReader(fs);
			int aux;
			try
			{
				for (int i = 0; i<1000;i++)
				{
					
					aux = r.ReadByte();
					
					tbl.Rows.Add(aux.ToString("X2"),(char)aux);
					
				}				
			}
			catch (Exception e)
	        {
				MessageBox.Show(e.ToString());
	        }
			finally
			{
				r.Close();
				fs.Close();
			}
			
			
			
			
			
			
			return tbl;
		}	
		
		public static DataTable leer3(string ruta)
		{
			DataTable tbl = new DataTable();
			tbl.Columns.Add("count", typeof(string));
			tbl.Columns.Add("str", typeof(string));
			
			FileStream fs = new FileStream(ruta, FileMode.Open);
			BinaryReader r = new BinaryReader(fs);
			int aux;
			int count;
			byte[] block;
			int numBytesToRead = (int)fs.Length;
			 
			try
			{
				while (numBytesToRead > 0)
            	{	
					aux = r.ReadByte();		 
					numBytesToRead = numBytesToRead -1;
					
					if(aux == 10) // Monst Bestary
					{
						count = r.ReadByte();
						numBytesToRead = numBytesToRead -1;
						
						block = r.ReadBytes(count);
						numBytesToRead = numBytesToRead -count;
						
						//tbl.Rows.Add(count,HexToHex(block));
					}
					else if(aux == 18) //Archiv
					{
						count = r.ReadByte();
						numBytesToRead = numBytesToRead -1;
						
						if(count >= 128)
						{
							count = count + (r.ReadByte() - 1)*128;
							numBytesToRead = numBytesToRead -1;
						}
						
						block = r.ReadBytes(count);
						numBytesToRead = numBytesToRead -count;
						
						//tbl.Rows.Add(count,HexToHex(block));
					}
					else if(aux == 26) //House
					{
						count = r.ReadByte();
						numBytesToRead = numBytesToRead -1;
						
						if(count >= 128)
						{
							count = count + (r.ReadByte() - 1)*128;
							numBytesToRead = numBytesToRead -1;
						}
												
						block = r.ReadBytes(count);
						numBytesToRead = numBytesToRead -count;						
						
						//tbl.Rows.Add(count,HexToHex(block));
					}
					else if(aux == 34) //no Bestary ?
					{
						count = r.ReadByte();
						numBytesToRead = numBytesToRead -1;
						
						if(count >= 128)
						{
							count = count + (r.ReadByte() - 1)*128;
							numBytesToRead = numBytesToRead -1;
						}
						
						block = r.ReadBytes(count);
						numBytesToRead = numBytesToRead -count;	
						
						//tbl.Rows.Add(count,HexToHex(block));
					}
					else if(aux == 42) //Quest
					{
						count = r.ReadByte();
						numBytesToRead = numBytesToRead -1;
						
						if(count >= 128)
						{
							count = count + (r.ReadByte() - 1)*128;
							numBytesToRead = numBytesToRead -1;
						}
						
						block = r.ReadBytes(count);
						numBytesToRead = numBytesToRead -count;							
						tbl.Rows.Add(count,HexToHex(block));
					}
				}

			}
			catch (Exception e)
	        {
				MessageBox.Show(e.ToString());
	        }
			finally
			{
				r.Close();
				fs.Close();
			}
			
			
			
			
			
			
			return tbl;
		}	
		
		
		private static string HexToHex(byte[] evaluar)
		{
			string salida = "";			
			int aux;
			
			for(int i=0;i< evaluar.Length;i++)
			{
				aux = evaluar[i];
				salida = salida + aux.ToString("X2") + "|";
			}
			    
			
			
			return salida;
		}	
		
		
	}
}
