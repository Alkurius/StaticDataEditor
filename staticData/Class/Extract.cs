
using System;

namespace Binario.Class
{
	public class Extract
	{
		public Extract()
		{
		}
		
		 
		
		public static string[] M1(byte[] block)
		{
			
			string[] SalidaM1 = new String[9];			
			int apuntador = 1;
			int countAux = 0;
			int flagAux = 0;
			int ID = -1;
			string name = "";
			int Lookex = -1;
			int looktype = -1;
			int head = -1;
			int body = -1;
			int legs = -1;
			int feet = -1;
			int addon = -1;
			
			
			//Extraer el ID y maximo de 2 oportunidades
			ID = Convert.ToInt32(block[apuntador]);	
			countAux = 0;			
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{
				countAux = countAux +1;
				apuntador = apuntador +1;
				
				if(countAux == 1)
				{
					ID = ID + (Convert.ToInt32(block[apuntador])-1)*128;
				}
				
			}
			
			//Extrar Nombre
			apuntador = apuntador +2;
			countAux = Convert.ToInt32(block[apuntador]);	//digitos del nombre
			apuntador = apuntador +1;
			
			for(int i = 0; i < countAux; i++)
			{
				name = name + (char)block[apuntador];
				apuntador = apuntador +1;
				
			}
			
			
			//Extraer Flags
			apuntador = apuntador +2;
			flagAux = Convert.ToInt32(block[apuntador]);
			
			//Bandera Lookex
			apuntador = apuntador +1;
			if(flagAux == 32)
			{
				Lookex = Convert.ToInt32(block[apuntador]);	
				countAux = 0;
				if(Convert.ToInt32(block[apuntador]) >= 128)
				{
					countAux = countAux +1;
					apuntador = apuntador +1;
					
					if(countAux == 1)
					{
						Lookex = Lookex + (Convert.ToInt32(block[apuntador])-1)*128;
					}
					
				}
				apuntador = apuntador +1;
			}
			
			//Bandera looktype
			if(flagAux == 8)
			{
				looktype = Convert.ToInt32(block[apuntador]);
				countAux = 0;
				if(Convert.ToInt32(block[apuntador]) >= 128)
				{
					countAux = countAux +1;
					apuntador = apuntador +1;
					
					if(countAux == 1)
					{
						looktype = looktype + (Convert.ToInt32(block[apuntador])-1)*128;
					}
					
				}
				apuntador = apuntador +1;
			}
			
			//Leer los colores			
			if(block.Length > apuntador)
			{
				flagAux = Convert.ToInt32(block[apuntador]);
				apuntador = apuntador +3;
				
				//Head
				head = Convert.ToInt32(block[apuntador]);
				countAux = 0;
				if(Convert.ToInt32(block[apuntador]) >= 128)
				{
					countAux = countAux +1;
					apuntador = apuntador +1;
					
					if(countAux == 1)
					{
						head = head + (Convert.ToInt32(block[apuntador])-1)*128;
					}
					
				}
				apuntador = apuntador +2;	
				
				
				//Body
				body = Convert.ToInt32(block[apuntador]);
				countAux = 0;
				if(Convert.ToInt32(block[apuntador]) >= 128)
				{
					countAux = countAux +1;
					apuntador = apuntador +1;
					
					if(countAux == 1)
					{
						body = body + (Convert.ToInt32(block[apuntador])-1)*128;
					}
					
				}
				apuntador = apuntador +2;	
				
				
				//Legs
				legs = Convert.ToInt32(block[apuntador]);
				countAux = 0;
				if(Convert.ToInt32(block[apuntador]) >= 128)
				{
					countAux = countAux +1;
					apuntador = apuntador +1;
					
					if(countAux == 1)
					{
						legs = legs + (Convert.ToInt32(block[apuntador])-1)*128;
					}
					
				}
				apuntador = apuntador +2;
				
				//Feet
				feet = Convert.ToInt32(block[apuntador]);
				countAux = 0;
				if(Convert.ToInt32(block[apuntador]) >= 128)
				{
					countAux = countAux +1;
					apuntador = apuntador +1;
					
					if(countAux == 1)
					{
						feet = feet + (Convert.ToInt32(block[apuntador])-1)*128;
					}
					
				}
				apuntador = apuntador +2;
				
				//Addon
				addon = Convert.ToInt32(block[apuntador]);
				countAux = 0;
				if(Convert.ToInt32(block[apuntador]) >= 128)
				{
					countAux = countAux +1;
					apuntador = apuntador +1;
					
					if(countAux == 1)
					{
						addon = addon + (Convert.ToInt32(block[apuntador])-1)*128;
					}
					
				}
				apuntador = apuntador +2;
				
			}
			
			
			
			
			
			
			
			SalidaM1[0] = ID.ToString();
			SalidaM1[1] = name;
			SalidaM1[2] = Lookex.ToString();
			SalidaM1[3] = looktype.ToString();
			SalidaM1[4] = head.ToString();
			SalidaM1[5] = body.ToString();
			SalidaM1[6] = legs.ToString();
			SalidaM1[7] = feet.ToString();
			SalidaM1[8] = addon.ToString();
			
			return SalidaM1;
			
		}	
		
		public static string[] A1(byte[] block)
		{
			
			string[] SalidaA1 = new String[9];			
			int apuntador = 1;
			int countAux = 0;
			int ID = -1;
			string name = "";
			string descripcion = "";
			int grado = -1;
			
			
			ID = Convert.ToInt32(block[apuntador]);	
			countAux = 0;			
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{
				countAux = countAux +1;
				apuntador = apuntador +1;
				
				if(countAux == 1)
				{
					ID = ID + (Convert.ToInt32(block[apuntador])-1)*128;
				}
				
			}
			
			//Extrar Nombre
			apuntador = apuntador +2;
			countAux = Convert.ToInt32(block[apuntador]);	//digitos del nombre
			apuntador = apuntador +1;
			
			for(int i = 0; i < countAux; i++)
			{
				name = name + (char)block[apuntador];
				apuntador = apuntador +1;
				
			}
			
			//Extrar descripcion
			apuntador = apuntador +1;
			countAux = Convert.ToInt32(block[apuntador]);	//digitos de la descripcion						
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				countAux = countAux + (Convert.ToInt32(block[apuntador])-1)*128;				
			}
			apuntador = apuntador +1;			
			for(int i = 0; i < countAux; i++)
			{
				descripcion = descripcion + (char)block[apuntador];
				apuntador = apuntador +1;
				
			}
			
			//Extrar Grado
			apuntador = apuntador +1;
			grado = Convert.ToInt32(block[apuntador]);	
			
			
			
			
			SalidaA1[0] = ID.ToString();
			SalidaA1[1] = name;
			SalidaA1[2] = descripcion;
			SalidaA1[3] = grado.ToString();
			
			return SalidaA1;
			
		}	
		
		public static string[] H1(byte[] block)
		{
			
			string[] SalidaH1 = new String[12];			
			int apuntador = 1;			
			int ID = -1;
			int countAux = -1;
			string name = "";
			string descripcion = "";
			int renta = -1;
			int beds = -1;
			int posx = -1;
			int posy = -1;
			int posz = -1;
			int SQM = -1;
			int GH = -1;
			string city = "";
			int shop = -1;
			
			
			
			
			//ID
			ID = Convert.ToInt32(block[apuntador]);						
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				ID = ID + (Convert.ToInt32(block[apuntador])-1)*128;
				
			}
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				ID = ID + (Convert.ToInt32(block[apuntador])-1)*128*128;
				
			}
			
			
			//Extrar Nombre
			apuntador = apuntador +2;
			countAux = Convert.ToInt32(block[apuntador]);	//digitos del nombre
			apuntador = apuntador +1;
			
			for(int i = 0; i < countAux; i++)
			{
				name = name + (char)block[apuntador];
				apuntador = apuntador +1;
				
			}
			
			
			//Extrar descripcion
			apuntador = apuntador +1;
			countAux = Convert.ToInt32(block[apuntador]);	//digitos de la descripcion						
			apuntador = apuntador +1;			
			for(int i = 0; i < countAux; i++)
			{
				descripcion = descripcion + (char)block[apuntador];
				apuntador = apuntador +1;				
			}
			
			
			//Extrar Renta
			apuntador = apuntador +1;
			renta = Convert.ToInt32(block[apuntador]);						
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				renta = renta + (Convert.ToInt32(block[apuntador])-1)*128;
				
			}
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				renta = renta + (Convert.ToInt32(block[apuntador])-1)*128*128;
				
			}
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				renta = renta + (Convert.ToInt32(block[apuntador])-1)*128*128*128;
				
			}
			
			
			//Extrar beds
			apuntador = apuntador +2;
			beds = Convert.ToInt32(block[apuntador]);	
			
			
			//Extrar PosX
			apuntador = apuntador +4;		
			posx = Convert.ToInt32(block[apuntador]);						
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				posx = posx + (Convert.ToInt32(block[apuntador])-1)*128;
				
			}
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				posx = posx + (Convert.ToInt32(block[apuntador])-1)*128*128;
				
			}
			
			//Extrar PosY
			apuntador = apuntador +2;				
			posy = Convert.ToInt32(block[apuntador]);						
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				posy = posy + (Convert.ToInt32(block[apuntador])-1)*128;
				
			}
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				posy = posy + (Convert.ToInt32(block[apuntador])-1)*128*128;
				
			}
			
			//Extrar PosZ
			apuntador = apuntador +2;				
			posz = Convert.ToInt32(block[apuntador]);
			
			
			//Extrar SQM
			apuntador = apuntador +2;				
			SQM = Convert.ToInt32(block[apuntador]);
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				SQM = SQM + (Convert.ToInt32(block[apuntador])-1)*128;
				
			}			
			
			//Extrar GH
			apuntador = apuntador +2;				
			GH = Convert.ToInt32(block[apuntador]);
			
			
			//Extrar city
			apuntador = apuntador +2;
			countAux = Convert.ToInt32(block[apuntador]);	//digitos del nombre
			apuntador = apuntador +1;
			
			for(int i = 0; i < countAux; i++)
			{
				city = city + (char)block[apuntador];
				apuntador = apuntador +1;				
			}
			
			//Extrar shop
			apuntador = apuntador +1;				
			shop = Convert.ToInt32(block[apuntador]);
			
			
			
			
			SalidaH1[0] = ID.ToString();
			SalidaH1[1] = name;
			SalidaH1[2] = descripcion;
			SalidaH1[3] = renta.ToString();
			SalidaH1[4] = beds.ToString();
			SalidaH1[5] = posx.ToString();
			SalidaH1[6] = posy.ToString();
			SalidaH1[7] = posz.ToString();
			SalidaH1[8] = SQM.ToString();
			SalidaH1[9] = GH.ToString();
			SalidaH1[10] = city;
			SalidaH1[11] = shop.ToString();
			
			return SalidaH1;
			
		}	
		
		public static string[] B1(byte[] block)
		{
			
			string[] SalidaB1 = new String[2];			
			int apuntador = 1;			
			int ID = -1;
			int countAux = -1;
			string name = "";
			
			ID = Convert.ToInt32(block[apuntador]);
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				ID = ID + (Convert.ToInt32(block[apuntador])-1)*128;
				
			}
			
			//Extrar Nombre
			apuntador = apuntador +2;
			countAux = Convert.ToInt32(block[apuntador]);	//digitos del nombre
			apuntador = apuntador +1;
			
			for(int i = 0; i < countAux; i++)
			{
				name = name + (char)block[apuntador];
				apuntador = apuntador +1;
				
			}
			
			
			SalidaB1[0] = ID.ToString();
			SalidaB1[1] = name;
			
			return SalidaB1;
			
		}	
		
		public static string[] Q1(byte[] block)
		{
			
			string[] SalidaQ1 = new String[2];			
			int apuntador = 1;			
			int ID = -1;
			int countAux = -1;
			string name = "";
			
			ID = Convert.ToInt32(block[apuntador]);
			if(Convert.ToInt32(block[apuntador]) >= 128)
			{				
				apuntador = apuntador +1;
				ID = ID + (Convert.ToInt32(block[apuntador])-1)*128;
				
			}
			
			//Extrar Nombre
			apuntador = apuntador +2;
			countAux = Convert.ToInt32(block[apuntador]);	//digitos del nombre
			apuntador = apuntador +1;
			
			for(int i = 0; i < countAux; i++)
			{
				name = name + (char)block[apuntador];
				apuntador = apuntador +1;
				
			}
			
			
			SalidaQ1[0] = ID.ToString();
			SalidaQ1[1] = name;
			
			return SalidaQ1;
			
		}	
		
		
	}
}
