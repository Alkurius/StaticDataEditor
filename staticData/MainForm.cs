using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.IO;

namespace Binario
{
	
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		
		DataTable tbl_m1 = new DataTable();
		DataTable tbl_a1 = new DataTable();	
		DataTable tbl_h1 = new DataTable();	
		DataTable tbl_b1 = new DataTable();	
		DataTable tbl_q1 = new DataTable();	
		
		string dir_tibiadat =  "";		
		string dir_Salida =  "";	
		
		//Principal
		void Button1Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				dir_tibiadat = openFileDialog1.FileName;
				try
				{
					LeerDATA();
				}
				catch
				{
					MessageBox.Show("Archivo corrupto o equivocado =(");
				}
			}
			
		}
		
		
		//Generar DATA
		void Button2Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
			{
        		dir_Salida = saveFileDialog1.FileName; 
				MessageBox.Show(Class.Exportar.GenerarDATA(dir_Salida,tbl_m1,tbl_a1,tbl_h1,tbl_b1,tbl_q1));        		
    		} 
		}
		
		//Eventos M1
		void DataGridView1SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView1.CurrentRow.Index != -1)
	            {
					numericUpDown1.Value = Convert.ToInt32(tbl_m1.Rows[dataGridView1.CurrentRow.Index]["id"].ToString());
					textBox1.Text = tbl_m1.Rows[dataGridView1.CurrentRow.Index]["name"].ToString();
					
					if(tbl_m1.Rows[dataGridView1.CurrentRow.Index]["LookEx"].ToString() != "-1")
					{
						radioButton2.Checked = true;
						numericUpDown2.Value = Convert.ToInt32(tbl_m1.Rows[dataGridView1.CurrentRow.Index]["LookEx"].ToString());
						numericUpDown3.Value = 0;
						numericUpDown4.Value = 0;
						numericUpDown5.Value = 0;
						numericUpDown6.Value = 0;
						numericUpDown7.Value = 0;					
						
					}
					else
					{
						radioButton1.Checked = true;
						numericUpDown2.Value = Convert.ToInt32(tbl_m1.Rows[dataGridView1.CurrentRow.Index]["Look"].ToString());
						numericUpDown3.Value = Convert.ToInt32(tbl_m1.Rows[dataGridView1.CurrentRow.Index]["Head"].ToString());
						numericUpDown4.Value = Convert.ToInt32(tbl_m1.Rows[dataGridView1.CurrentRow.Index]["Body"].ToString());
						numericUpDown5.Value = Convert.ToInt32(tbl_m1.Rows[dataGridView1.CurrentRow.Index]["Legs"].ToString());
						numericUpDown6.Value = Convert.ToInt32(tbl_m1.Rows[dataGridView1.CurrentRow.Index]["Feet"].ToString());
						numericUpDown7.Value = Convert.ToInt32(tbl_m1.Rows[dataGridView1.CurrentRow.Index]["Addon"].ToString());	
					}
				} 
			}
			catch{}
		}
		void Button3Click(object sender, EventArgs e)
		{
			int validar = -1;
			
			for(int i = 0; i<tbl_m1.Rows.Count;i++)
			{
				if(numericUpDown1.Value == Convert.ToInt32(tbl_m1.Rows[i]["id"].ToString()))
				{
					validar = i;
					i = tbl_m1.Rows.Count;
				}
			}
			
			
			
			if(validar == -1)
			{
				//nuevo registro
				if(radioButton1.Checked == true)
				{
					tbl_m1.Rows.Add(
						numericUpDown1.Value
						,textBox1.Text
						, -1
						, numericUpDown2.Value
						, numericUpDown3.Value
						, numericUpDown4.Value
						, numericUpDown5.Value
						, numericUpDown6.Value
						, numericUpDown7.Value
					);
				}
				else
				{
					tbl_m1.Rows.Add(
						numericUpDown1.Value
						,textBox1.Text
						, numericUpDown2.Value
						, -1
						, -1
						, -1
						, -1
						, -1
						, -1
					);
				}		
				
			}
			else
			{	//editar registro
				if(radioButton1.Checked == true)
				{
					tbl_m1.Rows[validar]["id"] = numericUpDown1.Value;
					tbl_m1.Rows[validar]["name"] = textBox1.Text;
					tbl_m1.Rows[validar]["LookEx"] = -1;
					tbl_m1.Rows[validar]["Look"] = numericUpDown2.Value;
					tbl_m1.Rows[validar]["Head"] = numericUpDown3.Value;
					tbl_m1.Rows[validar]["id"] = numericUpDown4.Value;
					tbl_m1.Rows[validar]["id"] = numericUpDown5.Value;
					tbl_m1.Rows[validar]["id"] = numericUpDown6.Value;
					tbl_m1.Rows[validar]["id"] = numericUpDown7.Value;					
				}
				else
				{
					tbl_m1.Rows[validar]["id"] = numericUpDown1.Value;
					tbl_m1.Rows[validar]["name"] = textBox1.Text;
					tbl_m1.Rows[validar]["LookEx"] = numericUpDown2.Value;
					tbl_m1.Rows[validar]["Look"] = -1;
					tbl_m1.Rows[validar]["Head"] = -1;
					tbl_m1.Rows[validar]["id"] = -1;
					tbl_m1.Rows[validar]["id"] = -1;
					tbl_m1.Rows[validar]["id"] = -1;
					tbl_m1.Rows[validar]["id"] = -1;	
					
				}
				
				
				
			}
			
		}
		
		//Eventos A1
		void DataGridView2SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView2.CurrentRow.Index != -1)
	            {
					numericUpDown8.Value = Convert.ToInt32(tbl_a1.Rows[dataGridView2.CurrentRow.Index]["id"].ToString());
					textBox2.Text = tbl_a1.Rows[dataGridView2.CurrentRow.Index]["name"].ToString();
					textBox3.Text = tbl_a1.Rows[dataGridView2.CurrentRow.Index]["description"].ToString();
					numericUpDown9.Value = Convert.ToInt32(tbl_a1.Rows[dataGridView2.CurrentRow.Index]["grade"].ToString());
				} 
			}
			catch{}
		}
		void Button4Click(object sender, EventArgs e)
		{
			int validar = -1;
			
			for(int i = 0; i<tbl_a1.Rows.Count;i++)
			{
				if(numericUpDown8.Value == Convert.ToInt32(tbl_a1.Rows[i]["id"].ToString()))
				{
					validar = i;
					i = tbl_a1.Rows.Count;
				}
			}
			
			
			
			if(validar == -1)
			{
				//nuevo registro
				tbl_a1.Rows.Add(
						numericUpDown8.Value
						, textBox2.Text
						, textBox3.Text
						, numericUpDown9.Value
					);
			}
			else
			{
				tbl_a1.Rows[validar]["id"] = numericUpDown8.Value;
				tbl_a1.Rows[validar]["name"] = textBox2.Text;
				tbl_a1.Rows[validar]["description"] = textBox3.Text;
				tbl_a1.Rows[validar]["grade"] = numericUpDown9.Value;									
			}	
		}
				
		//Eventos H1
		void DataGridView3SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView3.CurrentRow.Index != -1)
	            {
					numericUpDown10.Value = Convert.ToInt32(tbl_h1.Rows[dataGridView3.CurrentRow.Index]["id"].ToString());
					textBox5.Text = tbl_h1.Rows[dataGridView3.CurrentRow.Index]["name"].ToString();
					textBox4.Text = tbl_h1.Rows[dataGridView3.CurrentRow.Index]["description"].ToString();					
					numericUpDown11.Value = Convert.ToInt32(tbl_h1.Rows[dataGridView3.CurrentRow.Index]["rent"].ToString());
					numericUpDown12.Value = Convert.ToInt32(tbl_h1.Rows[dataGridView3.CurrentRow.Index]["beds"].ToString());
					numericUpDown13.Value = Convert.ToInt32(tbl_h1.Rows[dataGridView3.CurrentRow.Index]["posX"].ToString());
					numericUpDown14.Value = Convert.ToInt32(tbl_h1.Rows[dataGridView3.CurrentRow.Index]["posY"].ToString());
					numericUpDown15.Value = Convert.ToInt32(tbl_h1.Rows[dataGridView3.CurrentRow.Index]["posZ"].ToString());
					numericUpDown16.Value = Convert.ToInt32(tbl_h1.Rows[dataGridView3.CurrentRow.Index]["sqm"].ToString());					
					if(Convert.ToInt32(tbl_h1.Rows[dataGridView3.CurrentRow.Index]["GH"].ToString()) == 1){checkBox1.Checked = true;}else{checkBox1.Checked = false;}
					textBox6.Text = tbl_h1.Rows[dataGridView3.CurrentRow.Index]["city"].ToString();
					if(Convert.ToInt32(tbl_h1.Rows[dataGridView3.CurrentRow.Index]["shop"].ToString()) == 1){checkBox2.Checked = true;}else{checkBox2.Checked = false;}
				} 
			}
			catch{}
		}
		void Button5Click(object sender, EventArgs e)
		{
			int validar = -1;
			
			for(int i = 0; i<tbl_h1.Rows.Count;i++)
			{
				if(numericUpDown10.Value == Convert.ToInt32(tbl_h1.Rows[i]["id"].ToString()))
				{
					validar = i;
					i = tbl_h1.Rows.Count;
				}
			}
			
			
			int valorGH = 0;
			int valorSP = 0;
			if(checkBox1.Checked == true){valorGH = 1;}
			if(checkBox2.Checked == true){valorSP = 1;}
			
			if(validar == -1)
			{
				//nuevo registro
				tbl_h1.Rows.Add(
						numericUpDown10.Value
						, textBox5.Text
						, textBox4.Text
						, numericUpDown11.Value
						, numericUpDown12.Value
						, numericUpDown13.Value
						, numericUpDown14.Value
						, numericUpDown15.Value
						, numericUpDown16.Value
						, valorGH
						, textBox6.Text
						, valorSP
					);
			}
			else
			{
				tbl_h1.Rows[validar]["id"] = numericUpDown10.Value;
				tbl_h1.Rows[validar]["name"] = textBox5.Text;
				tbl_h1.Rows[validar]["description"] = textBox4.Text;
				tbl_h1.Rows[validar]["rent"] = numericUpDown11.Value;
				tbl_h1.Rows[validar]["beds"] = numericUpDown12.Value;	
				tbl_h1.Rows[validar]["posX"] = numericUpDown13.Value;	
				tbl_h1.Rows[validar]["posY"] = numericUpDown14.Value;	
				tbl_h1.Rows[validar]["posZ"] = numericUpDown15.Value;	
				tbl_h1.Rows[validar]["sqm"] = numericUpDown16.Value;	
				tbl_h1.Rows[validar]["GH"] = valorGH;	
				tbl_h1.Rows[validar]["city"] = textBox6.Text;
				tbl_h1.Rows[validar]["shop"] = valorSP;
			}
		}
				
		//Eventos B1
		void DataGridView4SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView4.CurrentRow.Index != -1)
	            {
					numericUpDown17.Value = Convert.ToInt32(tbl_b1.Rows[dataGridView4.CurrentRow.Index]["id"].ToString());
					textBox7.Text = tbl_b1.Rows[dataGridView4.CurrentRow.Index]["name"].ToString();
				} 
			}
			catch{}
		}
		void Button6Click(object sender, EventArgs e)
		{
			int validar = -1;
			
			for(int i = 0; i<tbl_b1.Rows.Count;i++)
			{
				if(numericUpDown17.Value == Convert.ToInt32(tbl_b1.Rows[i]["id"].ToString()))
				{
					validar = i;
					i = tbl_b1.Rows.Count;
				}
			}
			
			if(validar == -1)
			{
				//nuevo registro
				tbl_b1.Rows.Add(
						numericUpDown17.Value
						, textBox7.Text
					);
			}
			else
			{
				tbl_b1.Rows[validar]["id"] = numericUpDown17.Value;
				tbl_b1.Rows[validar]["name"] = textBox7.Text;
			}	
		}
		
		//Eventos Q1
		void DataGridView5SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView5.CurrentRow.Index != -1)
	            {
					numericUpDown18.Value = Convert.ToInt32(tbl_q1.Rows[dataGridView5.CurrentRow.Index]["id"].ToString());
					textBox8.Text = tbl_q1.Rows[dataGridView5.CurrentRow.Index]["name"].ToString();
				} 
			}
			catch{}
		}
		void Button7Click(object sender, EventArgs e)
		{
			int validar = -1;
			
			for(int i = 0; i<tbl_q1.Rows.Count;i++)
			{
				if(numericUpDown18.Value == Convert.ToInt32(tbl_q1.Rows[i]["id"].ToString()))
				{
					validar = i;
					i = tbl_q1.Rows.Count;
				}
			}
			
			if(validar == -1)
			{
				//nuevo registro
				tbl_q1.Rows.Add(
						numericUpDown18.Value
						, textBox8.Text
					);
			}
			else
			{
				tbl_q1.Rows[validar]["id"] = numericUpDown18.Value;
				tbl_q1.Rows[validar]["name"] = textBox8.Text;
			}
		}
		
		//Funcion
		private void LeerDATA()
		{
			FileStream fs = new FileStream(dir_tibiadat, FileMode.Open);
			BinaryReader r = new BinaryReader(fs);
			int aux;
			int count;
			byte[] block;
			int numBytesToRead = (int)fs.Length;
			string[] m1;
			string[] a1;
			string[] h1;
			string[] b1;
			string[] q1;
			
			tbl_m1 = Class.formatoTbl.formatoM1();
			tbl_a1 = Class.formatoTbl.formatoA1();
			tbl_h1 = Class.formatoTbl.formatoH1();
			tbl_b1 = Class.formatoTbl.formatoB1();
			tbl_q1 = Class.formatoTbl.formatoQ1();
						
			
				while (numBytesToRead > 0)
            	{	
					aux = r.ReadByte();		 
					numBytesToRead = numBytesToRead -1;
					
					#region M1
					if(aux == 10) 
					{
						count = r.ReadByte();
						numBytesToRead = numBytesToRead -1;
						
						block = r.ReadBytes(count);
						numBytesToRead = numBytesToRead -count;
						m1 = Class.Extract.M1(block);
						tbl_m1.Rows.Add(m1[0], m1[1], m1[2], m1[3], m1[4], m1[5], m1[6], m1[7], m1[8]);
					}
					#endregion
					
					#region A1
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
						
						a1 = Class.Extract.A1(block);
						tbl_a1.Rows.Add(a1[0],a1[1],a1[2],a1[3]);
					}
					#endregion
					
					#region H1
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
						
						h1 = Class.Extract.H1(block);
						tbl_h1.Rows.Add(h1[0],h1[1],h1[2],h1[3],h1[4],h1[5],h1[6],h1[7],h1[8],h1[9],h1[10],h1[11]);
					}
					#endregion
					
					#region B1
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
						
						b1 = Class.Extract.B1(block);
						tbl_b1.Rows.Add(b1[0],b1[1]);
					}
					#endregion
					
					#region Q1
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
						
						q1 = Class.Extract.Q1(block);
						tbl_q1.Rows.Add(q1[0],q1[1]);
					}
					#endregion
				}
				
				
				dataGridView1.DataSource = tbl_m1;
				dataGridView2.DataSource = tbl_a1;
				dataGridView3.DataSource = tbl_h1;
				dataGridView4.DataSource = tbl_b1;
				dataGridView5.DataSource = tbl_q1;
				dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
				dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
				dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
				dataGridView4.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
				dataGridView5.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);				
				foreach (DataGridViewColumn Col in dataGridView1.Columns){Col.SortMode = DataGridViewColumnSortMode.NotSortable;}
				foreach (DataGridViewColumn Col in dataGridView2.Columns){Col.SortMode = DataGridViewColumnSortMode.NotSortable;}
				foreach (DataGridViewColumn Col in dataGridView3.Columns){Col.SortMode = DataGridViewColumnSortMode.NotSortable;}
				foreach (DataGridViewColumn Col in dataGridView4.Columns){Col.SortMode = DataGridViewColumnSortMode.NotSortable;}
				foreach (DataGridViewColumn Col in dataGridView5.Columns){Col.SortMode = DataGridViewColumnSortMode.NotSortable;}
				
				r.Close();
				fs.Close();
                fs.Dispose();
		}
		
		
	}
}
