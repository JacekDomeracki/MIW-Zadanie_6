namespace Zadanie_6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxEkran = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxLicznik = new System.Windows.Forms.TextBox();
            this.textBoxParBeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxParMi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLiczEpok = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMarBledu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(905, 51);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(114, 31);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // textBoxEkran
            // 
            this.textBoxEkran.Location = new System.Drawing.Point(175, 26);
            this.textBoxEkran.Multiline = true;
            this.textBoxEkran.Name = "textBoxEkran";
            this.textBoxEkran.ReadOnly = true;
            this.textBoxEkran.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEkran.Size = new System.Drawing.Size(698, 589);
            this.textBoxEkran.TabIndex = 1;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(905, 156);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(114, 31);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // textBoxLicznik
            // 
            this.textBoxLicznik.Location = new System.Drawing.Point(905, 108);
            this.textBoxLicznik.Name = "textBoxLicznik";
            this.textBoxLicznik.ReadOnly = true;
            this.textBoxLicznik.Size = new System.Drawing.Size(114, 23);
            this.textBoxLicznik.TabIndex = 3;
            this.textBoxLicznik.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxParBeta
            // 
            this.textBoxParBeta.Location = new System.Drawing.Point(29, 83);
            this.textBoxParBeta.Name = "textBoxParBeta";
            this.textBoxParBeta.Size = new System.Drawing.Size(114, 23);
            this.textBoxParBeta.TabIndex = 4;
            this.textBoxParBeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxParBeta.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxParBeta_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Parametr Beta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Parametr Mi";
            // 
            // textBoxParMi
            // 
            this.textBoxParMi.Location = new System.Drawing.Point(29, 156);
            this.textBoxParMi.Name = "textBoxParMi";
            this.textBoxParMi.Size = new System.Drawing.Size(114, 23);
            this.textBoxParMi.TabIndex = 6;
            this.textBoxParMi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxParMi.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxParMi_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Liczba epok";
            // 
            // textBoxLiczEpok
            // 
            this.textBoxLiczEpok.Location = new System.Drawing.Point(29, 234);
            this.textBoxLiczEpok.Name = "textBoxLiczEpok";
            this.textBoxLiczEpok.Size = new System.Drawing.Size(114, 23);
            this.textBoxLiczEpok.TabIndex = 8;
            this.textBoxLiczEpok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxLiczEpok.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxLiczEpok_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Margines błędu";
            // 
            // textBoxMarBledu
            // 
            this.textBoxMarBledu.Location = new System.Drawing.Point(29, 311);
            this.textBoxMarBledu.Name = "textBoxMarBledu";
            this.textBoxMarBledu.Size = new System.Drawing.Size(114, 23);
            this.textBoxMarBledu.TabIndex = 10;
            this.textBoxMarBledu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxMarBledu.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxMarBledu_Validating);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 641);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMarBledu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLiczEpok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxParMi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxParBeta);
            this.Controls.Add(this.textBoxLicznik);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxEkran);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wsteczna propagacja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonStart;
        private TextBox textBoxEkran;
        private Button buttonReset;
        private TextBox textBoxLicznik;
        private TextBox textBoxParBeta;
        private Label label1;
        private Label label2;
        private TextBox textBoxParMi;
        private Label label3;
        private TextBox textBoxLiczEpok;
        private Label label4;
        private TextBox textBoxMarBledu;
    }
}