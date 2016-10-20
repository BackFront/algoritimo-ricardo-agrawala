namespace Cliente
{
	partial class FormCI
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
			this.btnIniciar = new System.Windows.Forms.Button();
			this.btnPausarMovimento = new System.Windows.Forms.Button();
			this.btnReiniciar = new System.Windows.Forms.Button();
			this.btnLiberarControle = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnIniciar
			// 
			this.btnIniciar.Location = new System.Drawing.Point(39, 33);
			this.btnIniciar.Name = "btnIniciar";
			this.btnIniciar.Size = new System.Drawing.Size(203, 23);
			this.btnIniciar.TabIndex = 0;
			this.btnIniciar.Text = "Iniciar Controle";
			this.btnIniciar.UseVisualStyleBackColor = true;
			this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
			// 
			// btnPausarMovimento
			// 
			this.btnPausarMovimento.Location = new System.Drawing.Point(39, 62);
			this.btnPausarMovimento.Name = "btnPausarMovimento";
			this.btnPausarMovimento.Size = new System.Drawing.Size(203, 23);
			this.btnPausarMovimento.TabIndex = 1;
			this.btnPausarMovimento.Text = "Pausar Movimento";
			this.btnPausarMovimento.UseVisualStyleBackColor = true;
			this.btnPausarMovimento.Click += new System.EventHandler(this.btnPausarMovimento_Click);
			// 
			// btnReiniciar
			// 
			this.btnReiniciar.Location = new System.Drawing.Point(39, 91);
			this.btnReiniciar.Name = "btnReiniciar";
			this.btnReiniciar.Size = new System.Drawing.Size(203, 23);
			this.btnReiniciar.TabIndex = 2;
			this.btnReiniciar.Text = "Reiniciar Movimento";
			this.btnReiniciar.UseVisualStyleBackColor = true;
			this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
			// 
			// btnLiberarControle
			// 
			this.btnLiberarControle.Location = new System.Drawing.Point(39, 120);
			this.btnLiberarControle.Name = "btnLiberarControle";
			this.btnLiberarControle.Size = new System.Drawing.Size(203, 23);
			this.btnLiberarControle.TabIndex = 3;
			this.btnLiberarControle.Text = "Liberar Controle";
			this.btnLiberarControle.UseVisualStyleBackColor = true;
			this.btnLiberarControle.Click += new System.EventHandler(this.btnLiberarControle_Click);
			// 
			// FormCI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.btnLiberarControle);
			this.Controls.Add(this.btnReiniciar);
			this.Controls.Add(this.btnPausarMovimento);
			this.Controls.Add(this.btnIniciar);
			this.Name = "FormCI";
			this.Text = "FormCI";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnIniciar;
		private System.Windows.Forms.Button btnPausarMovimento;
		private System.Windows.Forms.Button btnReiniciar;
		private System.Windows.Forms.Button btnLiberarControle;
	}
}

