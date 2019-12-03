using System.Windows.Forms; 
using System.Drawing;
using System;  

namespace Calculadora 
{
	public class Calculadora : Form
	{
		private System.ComponentModel.IContainer components = null; 
		private int HEIGHT = 313; 
		private int WIDTH  = 320;
	        private TextBox ENTRADA_TEXTBOX;
	        private Button button_MC;
	        private Button button_MR;
	        private Button button_Mmas;
	        private Button button_1;
	        private Button button_2;
	        private Button button_3;
	        private Button button_4;
	        private Button button_5;
	 	private Button button_6;
	        private Button button_7;
	        private Button button_8;
	        private Button button_9;
	        private Button button_0;
		private Button button_punto;
	        private Button button_Menos;
	        private Button button_Multiplicar;
	        private Button button_Mas;
	        private Button button_C;
	        private Button button_CE;
	        private Button button_MasOMenos; 
	        private Button button_Modulo;
	        private Button button_Dividir;
	        private Button button_Raiz;
	        private Button button_igual;	
		private bool comaDecimal ; 
		private char operador; 
		private byte numOperandos; 
		private double operando1; 
		private double operando2; 

		public Calculadora()
		{
                     InicialComponent(); 
		     ultimaEntrada = Entrada.NINGUNA;
		     operador = '\0';
		     numOperandos = 0; 
		     operando1 = 0; 
		     operando2 = 0;  
		}

		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose(); 
			}
			base.Dispose(disposing);
		}

		private void button_DigitosClick(object sender, EventArgs e)
                {
                        Button objButton = (Button)sender;

			if (ultimaEntrada != Entrada.DIGITO)
			{
				if (objButton.Text == "0") return; 
				ENTRADA_TEXTBOX.Text = ""; 
				ultimaEntrada = Entrada.DIGITO;
			        comaDecimal = false; 	
			}
                        ENTRADA_TEXTBOX.Text += objButton.Text;
                }
		private enum Entrada
		{
			NINGUNA,
		        DIGITO, 
		        OPERADOR, 
		        CE 	
		}
		private Entrada ultimaEntrada; 

		private void btComaDec_Click(object sender, EventArgs e)
		{
			if (ultimaEntrada != Entrada.DIGITO)
			{
				ENTRADA_TEXTBOX.Text = "0,";
				ultimaEntrada = Entrada.DIGITO; 
			}
			else if (comaDecimal == false )
				ENTRADA_TEXTBOX.Text = ENTRADA_TEXTBOX.Text + ",";
			comaDecimal = true; 
		}

		private void btOperacion_Click(object sender, EventArgs e)
		{
			Button objButton = (Button)sender;
			//obtener el texto del boton pulsado
			string textoBoton = objButton.Text; 

			if ((numOperandos == 0) && (textoBoton[0] == '-'))
				ultimaEntrada = Entrada.DIGITO; 

			if (ultimaEntrada == Entrada.DIGITO)
				numOperandos += 1; 
			if (numOperandos == 1)
				operando1 = double.Parse(ENTRADA_TEXTBOX.Text); 
			else if (numOperandos == 2)
			{
				operando2 = double.Parse(ENTRADA_TEXTBOX.Text);
				
				switch (operador)
				{
					case '+': 
						operando1 += operando2; 
						break; 
					case '-': 
						operando1 -= operando2; 
						break; 
					case '*': 
						operando1 *= operando2; 
						break; 
					case '/': 
						operando1 /= operando2;
					        break; 
					case '=': 
					        operando1 = operando2; 
					        break; 	
				}
				ENTRADA_TEXTBOX.Text = operando1.ToString(); 
				numOperandos = 1; 
			}
			operador = textoBoton[0]; 
			ultimaEntrada = Entrada.OPERADOR; 

		}
		private void btTantoporCiento_Click(object sender, EventArgs e)
		{
			double resultado; 
			if (ultimaEntrada == Entrada.DIGITO)
			{
				resultado = operando1 * double.Parse(ENTRADA_TEXTBOX.Text) / 100;
				ENTRADA_TEXTBOX.Text = resultado.ToString(); 
				button_igual.PerformClick(); 
				button_Modulo.Focus(); 
			}
		}

		private void btBorrarEntrada_Click(object sender, EventArgs e)
		{
			ENTRADA_TEXTBOX.Text = "0,";
			ultimaEntrada = Entrada.CE; 
			comaDecimal = false; 
		}

		 private double RaizCuadrada(double valor)
    		 {
    			 if(valor < 0 )
    			   return 0;
    			 else
    			    return Math.Sqrt(valor);
    		 }
    
    		 private void CuadradaButton_Click(object sender, EventArgs e)
    		 {
    			 try
    			 {
    			    double resultado =
    				 RaizCuadrada(Convert.ToDouble(ENTRADA_TEXTBOX.Text));
    			    ENTRADA_TEXTBOX.Text = resultado.ToString();
			    button_igual.PerformClick(); 
			    button_Raiz.Focus(); 
    			 }
    			 catch ( FormatException parametroFormatException )
    			 {
   				 MessageBox.Show(parametroFormatException.Message,
   						 "Formato de numero invalido", MessageBoxButtons.OK,
   					 MessageBoxIcon.Error); 
   	                 }
                 }			 
    


                #region 
		private void InicialComponent() 
		{	
		
			//
			//Button_MC
			//
			button_MC = new Button(); 
			button_MC.BackColor = SystemColors.ActiveBorder; 
			button_MC.Location = new Point(12, 103);
			button_MC.Name = "button_MC";
			button_MC.Size = new Size(38, 29);
		        button_MC.TabIndex = 1; 
		        button_MC.Text = "MC";
		        button_MC.UseVisualStyleBackColor = true; 
		        //
			//button_MR 
			//
			button_MR = new Button();
                        button_MR.BackColor = SystemColors.ActiveBorder;
                        button_MR.Location = new Point(53, 103);
                        button_MR.Name = "button_MR";
                        button_MR.Size = new Size(38, 29);
                        button_MR.TabIndex = 2;
                        button_MR.Text = "MR";  
                        button_MR.UseVisualStyleBackColor = true;	
			//
			//button_Mmas
			//
			button_Mmas = new Button();
                        button_Mmas.BackColor = SystemColors.ActiveBorder;
                        button_Mmas.Location = new Point(97, 103);
                        button_Mmas.Name = "button_Mmas";
                        button_Mmas.Size = new Size(38, 29);
                        button_Mmas.TabIndex = 3;
                        button_Mmas.Text = "M+";
                        button_Mmas.UseVisualStyleBackColor = true;
			//
			//button_Raiz
			//
			button_Raiz = new Button();
                        button_Raiz.BackColor = SystemColors.ActiveBorder;
                        button_Raiz.Location = new Point(184, 103);
                        button_Raiz.Name = "button_Raiz";
                        button_Raiz.Size = new Size(38, 29);
                        button_Raiz.TabIndex = 4;
                        button_Raiz.Text = "Raiz";  
                        button_Raiz.UseVisualStyleBackColor = true;
			//
			//button_MasOMenos
			//
		        button_MasOMenos = new Button();
                        button_MasOMenos.BackColor = SystemColors.ActiveBorder;
                        button_MasOMenos.Location = new Point(236, 103);
                        button_MasOMenos.Name = "button_MasOMenos";
                        button_MasOMenos.Size = new Size(38, 29);
                        button_MasOMenos.TabIndex = 5;
                        button_MasOMenos.Text = "+/-";  
                        button_MasOMenos.UseVisualStyleBackColor = true;
			//
                        //button_2
			//
			button_2 = new Button();
                        button_2.BackColor = SystemColors.ActiveBorder;
                        button_2.Location = new Point(53, 138);
                        button_2.Name = "button_2";
                        button_2.Size = new Size(38, 29);
                        button_2.TabIndex = 6;
                        button_2.Text = "2";
                        button_2.UseVisualStyleBackColor = true;
                        //
			//button_1
			//
			button_1 = new Button();
                        button_1.BackColor = SystemColors.ActiveBorder;
                        button_1.Location = new Point(13, 138);
                        button_1.Name = "button_1";
                        button_1.Size = new Size(38, 29);
                        button_1.TabIndex = 7;
                        button_1.Text = "1";
                        button_1.UseVisualStyleBackColor = true;
			//
			//button_3
			//
			button_3 = new Button();
                        button_3.BackColor = SystemColors.ActiveBorder;
                        button_3.Location = new Point(97, 138);
                        button_3.Name = "button_3";
                        button_3.Size = new Size(38, 29);
                        button_3.TabIndex = 8;
                        button_3.Text = "3";
                        button_3.UseVisualStyleBackColor = true;
			//
			//button_4
			//
			button_4 = new Button();
                        button_4.BackColor = SystemColors.ActiveBorder;
                        button_4.Location = new Point(13, 173);
                        button_4.Name = "button_4";
                        button_4.Size = new Size(38, 29);
                        button_4.TabIndex = 9;
                        button_4.Text = "4";
                        button_4.UseVisualStyleBackColor = true;
			//
			//button_5
			//
                        button_5 = new Button();
                        button_5.BackColor = SystemColors.ActiveBorder;
                        button_5.Location = new Point(53, 173);
                        button_5.Name = "button_5";
                        button_5.Size = new Size(38, 29);
                        button_5.TabIndex = 10;
                        button_5.Text = "5";
                        button_5.UseVisualStyleBackColor = true;
			//
			//button_6
			//
			button_6 = new Button();
                        button_6.BackColor = SystemColors.ActiveBorder;
                        button_6.Location = new Point(97, 173);
                        button_6.Name = "button_6";
                        button_6.Size = new Size(38, 29);
                        button_6.TabIndex = 11;
                        button_6.Text = "6";
                        button_6.UseVisualStyleBackColor = true;
			//
			//button_7
			//
			button_7 = new Button();
                        button_7.BackColor = SystemColors.ActiveBorder;
                        button_7.Location = new Point(13, 208);
                        button_7.Name = "button_7";
                        button_7.Size = new Size(38, 29);
                        button_7.TabIndex = 12;
                        button_7.Text = "7";
                        button_7.UseVisualStyleBackColor = true;
			//
			//button_8
			//
			button_8 = new Button();
                        button_8.BackColor = SystemColors.ActiveBorder;
                        button_8.Location = new Point(53, 208);
                        button_8.Name = "button_8";
                        button_8.Size = new Size(38, 29);
                        button_8.TabIndex = 13;
                        button_8.Text = "6";
                        button_8.UseVisualStyleBackColor = true;
			//
			//button_9 
			//
		        button_9 = new Button();
                        button_9.BackColor = SystemColors.ActiveBorder;
                        button_9.Location = new Point(97, 208);
                        button_9.Name = "button_9";
                        button_9.Size = new Size(38, 29);
                        button_9.TabIndex = 14;
                        button_9.Text = "9";
                        button_9.UseVisualStyleBackColor = true;
			//
			//button_0 
			//
			button_0 = new Button();
                        button_0.BackColor = SystemColors.ActiveBorder;
                        button_0.Location = new Point(13, 243);
                        button_0.Name = "button_0";
                        button_0.Size = new Size(78, 29);
                        button_0.TabIndex = 15;
                        button_0.Text = "0";
                        button_0.UseVisualStyleBackColor = true;
			//
			//button_igual 
			//
			//
		        button_punto = new Button();
                        button_punto.BackColor = SystemColors.ActiveBorder;
                        button_punto.Location = new Point(97, 243);
                        button_punto.Name = "button_punto";
                        button_punto.Size = new Size(38, 29);
                        button_punto.TabIndex = 16;
                        button_punto.Text = ".";
                        button_punto.UseVisualStyleBackColor = true;
			//
			//button_C
			//
			button_C = new Button();
                        button_C.BackColor = SystemColors.ActiveBorder;
                        button_C.Location = new Point(184, 138);
                        button_C.Name = "button_C";
                        button_C.Size = new Size(38, 29);
                        button_C.TabIndex = 17;
                        button_C.Text = "C";
                        button_C.UseVisualStyleBackColor = true;
			//
			//button_CE
			//
			button_CE = new Button();
                        button_CE.BackColor = SystemColors.ActiveBorder;
                        button_CE.Location = new Point(236, 138);
                        button_CE.Name = "button_CE";
                        button_CE.Size = new Size(38, 29);
                        button_CE.TabIndex = 18;
                        button_CE.Text = "CE";
                        button_CE.UseVisualStyleBackColor = true;
			//
			//button_Dividir
			//
	                button_Dividir = new Button();
                        button_Dividir.BackColor = SystemColors.ActiveBorder;
                        button_Dividir.Location = new Point(184, 173);
                        button_Dividir.Name = "button_Dividir";
                        button_Dividir.Size = new Size(38, 29);
                        button_Dividir.TabIndex = 19;
                        button_Dividir.Text = "/";
                        button_Dividir.UseVisualStyleBackColor = true;
			//
			//button_Menos 
			//
			button_Menos = new Button();
                        button_Menos.BackColor = SystemColors.ActiveBorder;
                        button_Menos.Location = new Point(236, 173);
                        button_Menos.Name = "button_Menos";
                        button_Menos.Size = new Size(38, 29);
                        button_Menos.TabIndex = 20;
                        button_Menos.Text = "-";
                        button_Menos.UseVisualStyleBackColor = true;
			//
			//button_Multiplicar
			//
			button_Multiplicar = new Button();
                        button_Multiplicar.BackColor = SystemColors.ActiveBorder;
                        button_Multiplicar.Location = new Point(184, 208);
                        button_Multiplicar.Name = "button_Multiplicar";
                        button_Multiplicar.Size = new Size(38, 29);
                        button_Multiplicar.TabIndex = 21;
                        button_Multiplicar.Text = "*";
                        button_Multiplicar.UseVisualStyleBackColor = true;
			//
			//button_Mas
			//
			button_Mas = new Button();
                        button_Mas.BackColor = SystemColors.ActiveBorder;
                        button_Mas.Location = new Point(236, 208);
                        button_Mas.Name = "button_Mas";
                        button_Mas.Size = new Size(38, 29);
                        button_Mas.TabIndex = 22;
                        button_Mas.Text = "+";
                        button_Mas.UseVisualStyleBackColor = true;
			//
			//button_igual
			//	    
		       	button_igual = new Button();
                        button_igual.BackColor = SystemColors.ActiveBorder;
                        button_igual.Location = new Point(184, 240);
                        button_igual.Name = "button_igual";
                        button_igual.Size = new Size(38, 29);
                        button_igual.TabIndex = 23;
                        button_igual.Text = "=";
                        button_igual.UseVisualStyleBackColor = true;
			//
			//button_Modulo 
			//
		        button_Modulo = new Button();
                        button_Modulo.BackColor = SystemColors.ActiveBorder;
                        button_Modulo.Location = new Point(236, 243);
                        button_Modulo.Name = "button_Modulo";
                        button_Modulo.Size = new Size(38, 29);
                        button_Modulo.TabIndex = 24;
                        button_Modulo.Text = "%";
                        button_Modulo.UseVisualStyleBackColor = true;
			//
			//ENTRADA_TEXTBOX
		        //
			ENTRADA_TEXTBOX = new TextBox(); 
			ENTRADA_TEXTBOX.BackColor = SystemColors.ActiveBorder;
			ENTRADA_TEXTBOX.Location = new Point(13, 23);
		        ENTRADA_TEXTBOX.Name = "ENTRADA";
		        ENTRADA_TEXTBOX.ReadOnly = true; 
			ENTRADA_TEXTBOX.Size = new Size(272, 39);
			ENTRADA_TEXTBOX.TabIndex = 0;
		        ENTRADA_TEXTBOX.Multiline = false; 	
			ENTRADA_TEXTBOX.TextAlign = HorizontalAlignment.Right; 
                        //
                        //form calculadora
                        //
                        AutoScaleDimensions = new SizeF(6F, 13F);
                        Name = "Calculadora";
                        Text = "Calculadora";
                        Size = new Size(HEIGHT, WIDTH);
			CenterToScreen(); 
			ResumeLayout(false);
		        PerformLayout();
		        //
			//eventos digitos 
			//
		        button_1.Click += new EventHandler(button_DigitosClick);
                        button_2.Click += new EventHandler(button_DigitosClick);
                        button_3.Click += new EventHandler(button_DigitosClick);
                        button_4.Click += new EventHandler(button_DigitosClick);
                        button_5.Click += new EventHandler(button_DigitosClick);
                        button_6.Click += new EventHandler(button_DigitosClick);
                        button_7.Click += new EventHandler(button_DigitosClick);
                        button_8.Click += new EventHandler(button_DigitosClick);
                        button_9.Click += new EventHandler(button_DigitosClick);
                        button_0.Click += new EventHandler(button_DigitosClick);
			button_punto.Click += new EventHandler(btComaDec_Click);
			button_Menos.Click += btOperacion_Click;
                        button_Multiplicar.Click += btOperacion_Click;
                        button_Mas.Click += new EventHandler(btOperacion_Click);
                        button_Dividir.Click += new EventHandler(btOperacion_Click);
                        button_igual.Click += new EventHandler(btOperacion_Click);
			button_Modulo.Click += btTantoporCiento_Click;
		        button_C.Click += btBorrarEntrada_Click; 
		        button_CE.Click += btBorrarEntrada_Click; 	
			button_Raiz.Click += CuadradaButton_Click; 
			//
			//
			//Add the Controls on the form.
			//
		        Controls.Add(ENTRADA_TEXTBOX);
		        Controls.Add(button_MC); 
		        Controls.Add(button_MR); 
		        Controls.Add(button_Mmas);
		        Controls.Add(button_Raiz);
		        Controls.Add(button_MasOMenos);
		        Controls.Add(button_2);	
			Controls.Add(button_3);
			Controls.Add(button_1);
			Controls.Add(button_4);
			Controls.Add(button_5);
			Controls.Add(button_6);
			Controls.Add(button_7);
			Controls.Add(button_8);
			Controls.Add(button_9);
			Controls.Add(button_0);
			Controls.Add(button_punto);
			Controls.Add(button_C);
			Controls.Add(button_CE);
			Controls.Add(button_Dividir);
			Controls.Add(button_Menos);
			Controls.Add(button_Multiplicar);
			Controls.Add(button_Mas);
			Controls.Add(button_igual);
			Controls.Add(button_Modulo);
                       
		}
                #endregion 


	}

	public class MApplication 
	{ 	

		static void Main()
		{
			
			if(PrimeraInstancia)
			{
				Application.EnableVisualStyles();
			        Application.SetCompatibleTextRenderingDefault(false);
			        Application.Run(new Calculadora());	
			}
			else 
			{
				MessageBox.Show("La applicacion ya esta esta ejecutando");
				Application.Exit(); 
			}
		}

		private static bool PrimeraInstancia
		{
			get 
			{
			   //Verificar si ya existe una instancia de la applicacion   
		            string nombre_exmut = "ApwinForms";
			    bool nueva; 
			    System.Threading.Mutex exmut;  
			    exmut = new System.Threading.Mutex(true, nombre_exmut, out nueva);
			    return nueva;  
			}
		}

              




	}

}
