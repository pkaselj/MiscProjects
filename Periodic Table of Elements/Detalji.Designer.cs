namespace Periodni_Sustav_Elemenata
{
    partial class Detalji
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
            this.simbol = new System.Windows.Forms.Label();
            this.protonskiBroj = new System.Windows.Forms.Label();
            this.maseniBroj = new System.Windows.Forms.Label();
            this.temperaturaTaljenja = new System.Windows.Forms.Label();
            this.temperaturaIsparavanja = new System.Windows.Forms.Label();
            this.opis = new System.Windows.Forms.Label();
            this.koristenje = new System.Windows.Forms.Label();
            this.ime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simbol
            // 
            this.simbol.AutoSize = true;
            this.simbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.simbol.Location = new System.Drawing.Point(55, 21);
            this.simbol.Name = "simbol";
            this.simbol.Size = new System.Drawing.Size(41, 37);
            this.simbol.TabIndex = 0;
            this.simbol.Text = "H";
            // 
            // protonskiBroj
            // 
            this.protonskiBroj.AutoSize = true;
            this.protonskiBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.protonskiBroj.Location = new System.Drawing.Point(11, 1);
            this.protonskiBroj.Name = "protonskiBroj";
            this.protonskiBroj.Size = new System.Drawing.Size(18, 20);
            this.protonskiBroj.TabIndex = 1;
            this.protonskiBroj.Text = "1";
            // 
            // maseniBroj
            // 
            this.maseniBroj.AutoSize = true;
            this.maseniBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.maseniBroj.Location = new System.Drawing.Point(84, 1);
            this.maseniBroj.Name = "maseniBroj";
            this.maseniBroj.Size = new System.Drawing.Size(49, 20);
            this.maseniBroj.TabIndex = 2;
            this.maseniBroj.Text = "1.008";
            // 
            // temperaturaTaljenja
            // 
            this.temperaturaTaljenja.AutoSize = true;
            this.temperaturaTaljenja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.temperaturaTaljenja.Location = new System.Drawing.Point(12, 81);
            this.temperaturaTaljenja.Name = "temperaturaTaljenja";
            this.temperaturaTaljenja.Size = new System.Drawing.Size(51, 20);
            this.temperaturaTaljenja.TabIndex = 3;
            this.temperaturaTaljenja.Text = "label1";
            // 
            // temperaturaIsparavanja
            // 
            this.temperaturaIsparavanja.AutoSize = true;
            this.temperaturaIsparavanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.temperaturaIsparavanja.Location = new System.Drawing.Point(74, 101);
            this.temperaturaIsparavanja.Name = "temperaturaIsparavanja";
            this.temperaturaIsparavanja.Size = new System.Drawing.Size(51, 20);
            this.temperaturaIsparavanja.TabIndex = 4;
            this.temperaturaIsparavanja.Text = "label1";
            // 
            // opis
            // 
            this.opis.AutoSize = true;
            this.opis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opis.Location = new System.Drawing.Point(12, 132);
            this.opis.MaximumSize = new System.Drawing.Size(100, 0);
            this.opis.Name = "opis";
            this.opis.Size = new System.Drawing.Size(35, 13);
            this.opis.TabIndex = 5;
            this.opis.Text = "label1";
            // 
            // koristenje
            // 
            this.koristenje.AutoSize = true;
            this.koristenje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.koristenje.Location = new System.Drawing.Point(12, 236);
            this.koristenje.MaximumSize = new System.Drawing.Size(100, 0);
            this.koristenje.Name = "koristenje";
            this.koristenje.Size = new System.Drawing.Size(35, 13);
            this.koristenje.TabIndex = 6;
            this.koristenje.Text = "label1";
            // 
            // ime
            // 
            this.ime.AutoSize = true;
            this.ime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ime.Location = new System.Drawing.Point(45, 58);
            this.ime.Name = "ime";
            this.ime.Size = new System.Drawing.Size(51, 20);
            this.ime.TabIndex = 7;
            this.ime.Text = "label1";
            // 
            // Detalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(145, 305);
            this.ControlBox = false;
            this.Controls.Add(this.ime);
            this.Controls.Add(this.koristenje);
            this.Controls.Add(this.opis);
            this.Controls.Add(this.temperaturaIsparavanja);
            this.Controls.Add(this.temperaturaTaljenja);
            this.Controls.Add(this.maseniBroj);
            this.Controls.Add(this.protonskiBroj);
            this.Controls.Add(this.simbol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Detalji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Detalji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label simbol;
        private System.Windows.Forms.Label protonskiBroj;
        private System.Windows.Forms.Label maseniBroj;
        private System.Windows.Forms.Label temperaturaTaljenja;
        private System.Windows.Forms.Label temperaturaIsparavanja;
        private System.Windows.Forms.Label opis;
        private System.Windows.Forms.Label koristenje;
        private System.Windows.Forms.Label ime;
    }
}