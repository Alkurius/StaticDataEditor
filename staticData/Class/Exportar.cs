using System;
using System.Text;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace Binario.Class
{
	/// <summary>
	/// Description of Exportar.
	/// </summary>
	public class Exportar
	{
		public Exportar()
		{
		}
		
		
		public static string GenerarDATA(string ruta, DataTable tbl_m1,DataTable tbl_a1, 
		                                 DataTable tbl_h1, DataTable tbl_b1, DataTable tbl_q1)
		{			
			string salida = "Guardado";
			
			byte[] id;
			byte[] name;
			byte[] descripcion;
			byte[] LookEx;
			byte[] Look;
			byte[] Head;
			byte[] Body;			
			byte[] Legs;			
			byte[] Feet;
			byte[] Addon;
			byte[] grupo;
			byte[] NameLength;
			byte[] DescripcionLength;
			byte[] cityLength;
			byte[] ArrayCountTotal;
			byte[] rent;
			byte[] beds;
			byte[] posX;
			byte[] posY;
			byte[] posZ;
			byte[] sqm;
			byte[] GH;
			byte[] city;
			byte[] shop;
			double countColors = 0;
			double countAdons = 0;
			double countLook = 0;
			double countSubTotal = 0;
			double countTotal = 0;
			
			
			
			using(FileStream
            fileStream = new FileStream(ruta, FileMode.Create))
			{
				//Vaciado de M1
				for(int i = 0; i<tbl_m1.Rows.Count; i++)
				{
					countColors = 0;
					countAdons = 0;
					countLook = 0;
					countSubTotal =0;
					countTotal = 0;
					
					
					id = IntToHEX(Convert.ToDouble(tbl_m1.Rows[i]["id"].ToString()));
					name = StrToHEX(tbl_m1.Rows[i]["name"].ToString());					
					LookEx = IntToHEX(Convert.ToDouble(tbl_m1.Rows[i]["LookEx"].ToString()));
					Look = IntToHEX(Convert.ToDouble(tbl_m1.Rows[i]["Look"].ToString()));
					Head = IntToHEX(Convert.ToDouble(tbl_m1.Rows[i]["Head"].ToString()));
					Body = IntToHEX(Convert.ToDouble(tbl_m1.Rows[i]["Body"].ToString()));
					Legs = IntToHEX(Convert.ToDouble(tbl_m1.Rows[i]["Legs"].ToString()));
					Feet = IntToHEX(Convert.ToDouble(tbl_m1.Rows[i]["Feet"].ToString()));
					Addon = IntToHEX(Convert.ToDouble(tbl_m1.Rows[i]["Addon"].ToString()));
					
					NameLength = IntToHEX(name.Length);
					countColors =  						
						+ Head.Length 
						+ Body.Length 
						+ Legs.Length 
						+ Feet.Length;
					if(countColors >0){ countColors = countColors +4;}
					
					countAdons = Addon.Length;
					if(countAdons >0){ countAdons = countAdons +1;}
										
					countLook = LookEx.Length + Look.Length;
					if(countLook >0){ countLook = countLook +1;}
					
					countSubTotal = countColors + countAdons + countLook;
					
					if(countColors + countAdons >0)
					{
						countSubTotal = countSubTotal + 2;
					}
					
					countTotal = 5+ id.Length + name.Length + countSubTotal;
										
					fileStream.WriteByte(Convert.ToByte(10));
					fileStream.WriteByte(Convert.ToByte(countTotal));
					fileStream.WriteByte(Convert.ToByte(8));
					foreach (byte x in id){fileStream.WriteByte(x);}						
					fileStream.WriteByte(Convert.ToByte(18));
					fileStream.WriteByte(Convert.ToByte(name.Length));
					foreach (byte x in name){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(26));
					
					if(LookEx.Length >0)
					{
						fileStream.WriteByte(Convert.ToByte(1+LookEx.Length));
						fileStream.WriteByte(Convert.ToByte(32));
						foreach (byte x in LookEx){fileStream.WriteByte(x);}	
					}
					else
					{
						fileStream.WriteByte(Convert.ToByte(countSubTotal));
						fileStream.WriteByte(Convert.ToByte(8));
						foreach (byte x in Look){fileStream.WriteByte(x);}
						fileStream.WriteByte(Convert.ToByte(18));
						fileStream.WriteByte(Convert.ToByte(countColors));
						
						fileStream.WriteByte(Convert.ToByte(8));
						foreach (byte x in Head){fileStream.WriteByte(x);}
						
						fileStream.WriteByte(Convert.ToByte(16));
						foreach (byte x in Body){fileStream.WriteByte(x);}
						
						fileStream.WriteByte(Convert.ToByte(24));
						foreach (byte x in Legs){fileStream.WriteByte(x);}
						
						fileStream.WriteByte(Convert.ToByte(32));
						foreach (byte x in Feet){fileStream.WriteByte(x);}
												
						fileStream.WriteByte(Convert.ToByte(24));
						foreach (byte x in Addon){fileStream.WriteByte(x);}
					}
					
				}
			
				//Vaciado de A1
				for(int i = 0; i<tbl_a1.Rows.Count; i++)
				{
					
					countTotal =0;					
					
					id = IntToHEX(Convert.ToDouble(tbl_a1.Rows[i]["id"].ToString()));
					name = StrToHEX(tbl_a1.Rows[i]["name"].ToString());	
					descripcion = StrToHEX(tbl_a1.Rows[i]["description"].ToString());
					grupo = IntToHEX(Convert.ToDouble(tbl_a1.Rows[i]["grade"].ToString()));
					
					NameLength = IntToHEX(name.Length);
					DescripcionLength = IntToHEX(descripcion.Length);
										
					countTotal = 1 + id.Length + 1 + 1 + name.Length + 1 + DescripcionLength.Length + descripcion.Length + 1 +grupo.Length;
					ArrayCountTotal = IntToHEX(countTotal);
						
					fileStream.WriteByte(Convert.ToByte(18));
					foreach (byte x in ArrayCountTotal){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(8));
					foreach (byte x in id){fileStream.WriteByte(x);}						
					fileStream.WriteByte(Convert.ToByte(18));
					fileStream.WriteByte(Convert.ToByte(name.Length));
					foreach (byte x in name){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(26));
					foreach (byte x in DescripcionLength){fileStream.WriteByte(x);}
					foreach (byte x in descripcion){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(32));
					foreach (byte x in grupo){fileStream.WriteByte(x);}
					
					
					
				}
			
				//Vaciado de H1
				for(int i = 0; i<tbl_h1.Rows.Count; i++)
				{
					
					countTotal =0;					
					
					id = IntToHEX(Convert.ToDouble(tbl_h1.Rows[i]["id"].ToString()));
					name = StrToHEX(tbl_h1.Rows[i]["name"].ToString());	
					descripcion = StrToHEX(tbl_h1.Rows[i]["description"].ToString());
					rent = IntToHEX(Convert.ToDouble(tbl_h1.Rows[i]["rent"].ToString()));
					beds = IntToHEX(Convert.ToDouble(tbl_h1.Rows[i]["beds"].ToString()));
					posX = IntToHEX(Convert.ToDouble(tbl_h1.Rows[i]["posX"].ToString()));
					posY = IntToHEX(Convert.ToDouble(tbl_h1.Rows[i]["posY"].ToString()));
					posZ = IntToHEX(Convert.ToDouble(tbl_h1.Rows[i]["posZ"].ToString()));
					sqm = IntToHEX(Convert.ToDouble(tbl_h1.Rows[i]["sqm"].ToString()));
					GH = IntToHEX(Convert.ToDouble(tbl_h1.Rows[i]["GH"].ToString()));
					city = StrToHEX(tbl_h1.Rows[i]["city"].ToString());
					shop = IntToHEX(Convert.ToDouble(tbl_h1.Rows[i]["shop"].ToString()));
					
					NameLength = IntToHEX(name.Length);
					DescripcionLength = IntToHEX(descripcion.Length);
					cityLength = IntToHEX(city.Length);
					
					countTotal = id.Length + 
								name.Length + 
								descripcion.Length + 
								rent.Length + 
								beds.Length + 
								posX.Length + 
								posY.Length + 
								posZ.Length + 
								sqm.Length + 
								GH.Length + 
								city.Length + 
								shop.Length + 17;
					
					
					ArrayCountTotal = IntToHEX(countTotal);
											
					
					fileStream.WriteByte(Convert.ToByte(26));
					foreach (byte x in ArrayCountTotal){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(8));
					foreach (byte x in id){fileStream.WriteByte(x);}						
					fileStream.WriteByte(Convert.ToByte(18));
					fileStream.WriteByte(Convert.ToByte(name.Length));
					foreach (byte x in name){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(26));					
					foreach (byte x in DescripcionLength){fileStream.WriteByte(x);}
					foreach (byte x in descripcion){fileStream.WriteByte(x);}					
					fileStream.WriteByte(Convert.ToByte(32));
					foreach (byte x in rent){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(40));
					foreach (byte x in beds){fileStream.WriteByte(x);}					
					fileStream.WriteByte(Convert.ToByte(50));
					fileStream.WriteByte(Convert.ToByte(10));
					fileStream.WriteByte(Convert.ToByte(8));
					foreach (byte x in posX){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(16));
					foreach (byte x in posY){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(24));
					foreach (byte x in posZ){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(56));
					foreach (byte x in sqm){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(64));
					foreach (byte x in GH){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(74));
					foreach (byte x in cityLength){fileStream.WriteByte(x);}
					foreach (byte x in city){fileStream.WriteByte(x);}	
					fileStream.WriteByte(Convert.ToByte(80));
					foreach (byte x in shop){fileStream.WriteByte(x);}
				}
			
				//Vaciado de B1
				for(int i = 0; i<tbl_b1.Rows.Count; i++)
				{
					
					countTotal =0;					
					
					id = IntToHEX(Convert.ToDouble(tbl_b1.Rows[i]["id"].ToString()));
					name = StrToHEX(tbl_b1.Rows[i]["name"].ToString());
					NameLength = IntToHEX(name.Length);
					
					countTotal = id.Length + 
								name.Length + 3;
					
					
					ArrayCountTotal = IntToHEX(countTotal);
					
					fileStream.WriteByte(Convert.ToByte(34));
					foreach (byte x in ArrayCountTotal){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(8));
					foreach (byte x in id){fileStream.WriteByte(x);}						
					fileStream.WriteByte(Convert.ToByte(18));
					fileStream.WriteByte(Convert.ToByte(name.Length));
					foreach (byte x in name){fileStream.WriteByte(x);}
				}
			
				//Vaciado de Q1
				for(int i = 0; i<tbl_q1.Rows.Count; i++)
				{
					
					countTotal =0;					
					
					id = IntToHEX(Convert.ToDouble(tbl_q1.Rows[i]["id"].ToString()));
					name = StrToHEX(tbl_q1.Rows[i]["name"].ToString());
					NameLength = IntToHEX(name.Length);
					
					countTotal = id.Length + 
								name.Length + 3;
					
					
					ArrayCountTotal = IntToHEX(countTotal);
					
					fileStream.WriteByte(Convert.ToByte(42));
					foreach (byte x in ArrayCountTotal){fileStream.WriteByte(x);}
					fileStream.WriteByte(Convert.ToByte(8));
					foreach (byte x in id){fileStream.WriteByte(x);}						
					fileStream.WriteByte(Convert.ToByte(18));
					fileStream.WriteByte(Convert.ToByte(name.Length));
					foreach (byte x in name){fileStream.WriteByte(x);}
				}
			
				
			}
			
				
			return salida;
			
		}	
		
		
		
		
		
		
		public static byte[] IntToHEX(double Input)
		{
			
			List<double> listaAux = new List<double>();
			
			double aux = 0;			
			if(Input >=0)
			{
				if(Input >= (128*128*128))
				{
					aux = Input / (128*128*128);				
					Input = Input - ((Math.Truncate(aux)-1)*128*128*128);
					aux = Math.Truncate(aux);
				}
				if(aux >0){listaAux.Add(aux);}
				
				
				
				if(Input >= (128*128))
				{
					aux = Input / (128*128);				
					Input = Input - ((Math.Truncate(aux)-1)*128*128);
					aux = Math.Truncate(aux);
				}
				if(aux >0){listaAux.Add(aux);}
				
				
				if(Input >= (128))
				{
					aux = Input / (128);				
					Input = Input - ((Math.Truncate(aux)-1)*128);
					aux = Math.Truncate(aux);
				}
				
				if(aux >0){listaAux.Add(aux);}
				listaAux.Add(Input);
				listaAux.Reverse();
			}
			
			byte[] salida = new byte[listaAux.Count];
			
			for(int i = 0; i<listaAux.Count;i++)
			{
				salida[i] = Convert.ToByte(listaAux[i]);
			}
		
			return salida;
			
		}	
		
		public static byte[] StrToHEX(string Input)
		{
			
			byte[] salida = Encoding.Default.GetBytes(Input);
		
			return salida;
			
		}	
		
	}
}
