namespace Chess.Forms
{
    partial class Promote
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
            this.btnQueen = new System.Windows.Forms.Button();
            this.btnRook = new System.Windows.Forms.Button();
            this.btnBishop = new System.Windows.Forms.Button();
            this.btnKnight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQueen
            // 
            this.btnQueen.Location = new System.Drawing.Point(36, 33);
            this.btnQueen.Name = "btnQueen";
            this.btnQueen.Size = new System.Drawing.Size(125, 125);
            this.btnQueen.TabIndex = 0;
            this.btnQueen.UseVisualStyleBackColor = true;
            this.btnQueen.Click += new System.EventHandler(this.btnQueen_Click);
            // 
            // btnRook
            // 
            this.btnRook.Location = new System.Drawing.Point(178, 33);
            this.btnRook.Name = "btnRook";
            this.btnRook.Size = new System.Drawing.Size(125, 125);
            this.btnRook.TabIndex = 1;
            this.btnRook.UseVisualStyleBackColor = true;
            this.btnRook.Click += new System.EventHandler(this.btnRook_Click);
            // 
            // btnBishop
            // 
            this.btnBishop.Location = new System.Drawing.Point(178, 189);
            this.btnBishop.Name = "btnBishop";
            this.btnBishop.Size = new System.Drawing.Size(125, 125);
            this.btnBishop.TabIndex = 3;
            this.btnBishop.UseVisualStyleBackColor = true;
            this.btnBishop.Click += new System.EventHandler(this.btnBishop_Click);
            // 
            // btnKnight
            // 
            this.btnKnight.Location = new System.Drawing.Point(36, 189);
            this.btnKnight.Name = "btnKnight";
            this.btnKnight.Size = new System.Drawing.Size(125, 125);
            this.btnKnight.TabIndex = 2;
            this.btnKnight.UseVisualStyleBackColor = true;
            this.btnKnight.Click += new System.EventHandler(this.btnKnight_Click);
            // 
            // Promote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 353);
            this.Controls.Add(this.btnBishop);
            this.Controls.Add(this.btnKnight);
            this.Controls.Add(this.btnRook);
            this.Controls.Add(this.btnQueen);
            this.Name = "Promote";
            this.Text = "Promote";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnQueen;
        private Button btnRook;
        private Button btnBishop;
        private Button btnKnight;
    }
}