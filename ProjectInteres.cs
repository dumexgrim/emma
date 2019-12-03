using System; 
using System.Windows.Forms; 
using System.Drawing;  

namespace InterestProject 
{
	public class Interest : Form 
	{
		private Label AmountLabel; 
		private TextBox AmountTextBox; 
		private Label InterestLabel; 
		private TextBox InterestTextBox; 
		private Button  TotalButton;
	        private NumericUpDown yearsNumericUpDown; 
	        private Label yearsLabel; 
	        private TextBox ShowResultTextBox;
	        private Label AccountLabel;
	        private System.ComponentModel.IContainer components = null; 	

		public Interest()
		{
			InitialComponent(); 
		}

                #region
		private void InitialComponent() 
		{
			AmountLabel = new Label(); 
			AmountTextBox = new TextBox(); 
			InterestLabel = new Label(); 
	         	InterestTextBox = new TextBox(); 
			TotalButton = new Button(); 
			yearsNumericUpDown = new NumericUpDown(); 
			yearsLabel = new Label(); 
			ShowResultTextBox = new TextBox();
		        AccountLabel = new Label();

			//AmountLabel 
			AmountLabel.AutoSize = true; 
			AmountLabel.Font = new Font("Serif",12F);
			AmountLabel.Location = new Point(23, 37);
			AmountLabel.Name = "AmountLabel";
			AmountLabel.Size = new Size(72, 20);
			AmountLabel.TabIndex = 0; 
			AmountLabel.Text ="Amount";

			//AmountTextBox 
			AmountTextBox.Location = new Point(146, 37);
			AmountTextBox.Name = "AmountTextBox";
			AmountTextBox.Size = new Size(193, 20);
			AmountTextBox.TabIndex = 1; 
			AmountTextBox.TextAlign = HorizontalAlignment.Right; 

			//InterestLabel 
			InterestLabel.AutoSize = true; 
			InterestLabel.Font = new Font("Sherif", 12);
			InterestLabel.Location = new Point(23, 92);
			InterestLabel.Name = "InterestLabel";
			InterestLabel.Size = new Size(72, 20);
			InterestLabel.TabIndex = 2; 
			InterestLabel.Text = "Interest";
		        
		        //InterestTextBox
			InterestTextBox.Location = new Point(146, 91);
		        InterestTextBox.Name = "InterestTextBox";
		        InterestTextBox.Size = new Size(193, 20);
			InterestTextBox.TabIndex = 3; 
			InterestTextBox.TextAlign = HorizontalAlignment.Right; 

			//TotalButton
			TotalButton.Location = new Point(375, 55);
			TotalButton.Name = "TotalButton";
			TotalButton.Size = new Size(97, 38);
			TotalButton.TabIndex = 4; 
			TotalButton.Text = "Total";
			TotalButton.UseVisualStyleBackColor = true;
		        TotalButton.Click += TotalButton_Click; 	

			//yearsNumericUpDown
			yearsNumericUpDown.Location = new Point(146, 146);
			yearsNumericUpDown.Name = "yearsNumericUpDown";
			yearsNumericUpDown.Size = new Size(193, 20);
			yearsNumericUpDown.TabIndex = 5;  
			yearsNumericUpDown.TextAlign = HorizontalAlignment.Left;

			//yearsLabel
			yearsLabel.AutoSize = true; 
			yearsLabel.Font = new Font("Sherif",12);
			yearsLabel.Location = new Point(23, 143);
			yearsLabel.Name = "yearsLabel";
			yearsLabel.Size = new Size(46, 20);
			yearsLabel.TabIndex = 6; 
			yearsLabel.Text = "Years";

			//AccountLabel
			AccountLabel.AutoSize = true; 
			AccountLabel.Font = new Font("Sherif", 12);
			AccountLabel.Location = new Point(27, 203);
			AccountLabel.Name = "AccountLabel";
			AccountLabel.Size = new Size(188, 20);
			AccountLabel.TabIndex = 7; 
			AccountLabel.Text ="Amount due";

			//ShowResultTextBox
			ShowResultTextBox.Location = new Point(31, 244);
			ShowResultTextBox.Multiline = true; 
			ShowResultTextBox.Name = "ShowResultTextBox";
			ShowResultTextBox.ReadOnly = true; 
			ShowResultTextBox.Size = new Size(377, 175);
			ShowResultTextBox.TabIndex = 8;
		        
		        //Form 
			Size = new Size(480, 450);
		        Controls.Add(AmountLabel);
		        Controls.Add(AmountTextBox);
		        Controls.Add(InterestLabel);
		        Controls.Add(InterestTextBox);
		        Controls.Add(TotalButton);
		        Controls.Add(yearsNumericUpDown);
		        Controls.Add(yearsLabel);
		        Controls.Add(AccountLabel);
		        Controls.Add(ShowResultTextBox);
			Name = "InterestForm";
			Text = "Calculate interest from a loan";
			CenterToScreen(); 
		}
                #endregion

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose(); 
			}
			base.Dispose(disposing);
		}

		private void TotalButton_Click(object sender, EventArgs e)
		{
			decimal AmountText; 
			double interestText; 
			int yearNumeric; 
		        decimal Amount; 
		        string ShowOut; 	

			try 
			{
				AmountText = Convert.ToDecimal(AmountTextBox.Text);
				interestText = Convert.ToDouble(InterestTextBox.Text);
				yearNumeric = Convert.ToInt32(yearsNumericUpDown.Value);

				ShowOut = "Anos\tMonto en depositor\r\n";

				for(int CountYear = 1; CountYear <= yearNumeric; CountYear++)
				{
					Amount = AmountText * ((decimal)Math.Pow((1 + interestText / 100), CountYear));
					ShowOut += (CountYear + "\t" + string.Format("{0:C}", Amount) + "\r\n");
				}

				ShowResultTextBox.Text = ShowOut; 

			}
			catch ( FormatException parametroFormatException )
   			 {
   				 MessageBox.Show(parametroFormatException.Message,
   						 "Formato de numero invalido", MessageBoxButtons.OK,
   						 MessageBoxIcon.Error );
   
   	                 }


		}

	}

	public static class MApplication
	{
		private static void Main()
		{
			Application.Run(new Interest());

		}
	}
}

