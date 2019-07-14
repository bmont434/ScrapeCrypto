namespace ScrapeCrypto
{
    partial class CryptoPrice
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
            this.txtBitcoin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Ethereum = new System.Windows.Forms.Label();
            this.txtEthereum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBitcoin
            // 
            this.txtBitcoin.Location = new System.Drawing.Point(80, 79);
            this.txtBitcoin.Name = "txtBitcoin";
            this.txtBitcoin.Size = new System.Drawing.Size(142, 20);
            this.txtBitcoin.TabIndex = 0;
            this.txtBitcoin.TextChanged += new System.EventHandler(this.txtBitcoin_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bitcoin";
            // 
            // Ethereum
            // 
            this.Ethereum.AutoSize = true;
            this.Ethereum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ethereum.Location = new System.Drawing.Point(253, 47);
            this.Ethereum.Name = "Ethereum";
            this.Ethereum.Size = new System.Drawing.Size(79, 20);
            this.Ethereum.TabIndex = 3;
            this.Ethereum.Text = "Ethereum";
            // 
            // txtEthereum
            // 
            this.txtEthereum.Location = new System.Drawing.Point(257, 79);
            this.txtEthereum.Name = "txtEthereum";
            this.txtEthereum.Size = new System.Drawing.Size(138, 20);
            this.txtEthereum.TabIndex = 4;
            this.txtEthereum.Text = "0";
            this.txtEthereum.TextChanged += new System.EventHandler(this.txtEthereum_TextChanged);
            // 
            // CryptoPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtEthereum);
            this.Controls.Add(this.Ethereum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBitcoin);
            this.Name = "CryptoPrice";
            this.Text = "CryptoPrice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBitcoin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Ethereum;
        private System.Windows.Forms.TextBox txtEthereum;
    }
}

