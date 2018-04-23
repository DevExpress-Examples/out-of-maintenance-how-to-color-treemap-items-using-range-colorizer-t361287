namespace RangeColorizerSample {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.treeMap = new DevExpress.XtraTreeMap.TreeMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeMap)).BeginInit();
            this.SuspendLayout();
            // 
            // treeMap
            // 
            this.treeMap.BorderOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeMap.BorderOptions.Visible = false;
            this.treeMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMap.Location = new System.Drawing.Point(0, 0);
            this.treeMap.Name = "treeMap";
            this.treeMap.Size = new System.Drawing.Size(624, 321);
            this.treeMap.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.treeMap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeMap.TreeMapControl treeMap;
    }
}

