namespace Trem
{
	partial class FormTrem
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.trem = new System.Windows.Forms.Label();
            this.tempo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // trem
            // 
            this.trem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trem.AutoSize = true;
            this.trem.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trem.Location = new System.Drawing.Point(2, 70);
            this.trem.Name = "trem";
            this.trem.Size = new System.Drawing.Size(106, 44);
            this.trem.TabIndex = 0;
            this.trem.Text = "||||||})";
            // 
            // tempo
            // 
            this.tempo.Interval = 8;
            this.tempo.Tick += new System.EventHandler(this.tempo_Tick);
            // 
            // FormTrem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 253);
            this.Controls.Add(this.trem);
            this.Name = "FormTrem";
            this.Text = "Trem";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label trem;
		private System.Windows.Forms.Timer tempo;
	}
}

