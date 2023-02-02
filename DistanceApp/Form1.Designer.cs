namespace DistanceApp
{
    partial class frmDistanceCalc
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
            this.btnFileLoad = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnClassicExec = new System.Windows.Forms.Button();
            this.btnPerfExec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFileLoad
            // 
            this.btnFileLoad.Location = new System.Drawing.Point(12, 316);
            this.btnFileLoad.Name = "btnFileLoad";
            this.btnFileLoad.Size = new System.Drawing.Size(75, 23);
            this.btnFileLoad.TabIndex = 0;
            this.btnFileLoad.Text = "Load File";
            this.btnFileLoad.UseVisualStyleBackColor = true;
            this.btnFileLoad.Click += new System.EventHandler(this.btnFileLoad_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(12, 12);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(698, 298);
            this.rtbOutput.TabIndex = 1;
            this.rtbOutput.Text = "";
            // 
            // btnClassicExec
            // 
            this.btnClassicExec.Enabled = false;
            this.btnClassicExec.Location = new System.Drawing.Point(554, 316);
            this.btnClassicExec.Name = "btnClassicExec";
            this.btnClassicExec.Size = new System.Drawing.Size(75, 23);
            this.btnClassicExec.TabIndex = 3;
            this.btnClassicExec.Text = "Slow";
            this.btnClassicExec.UseVisualStyleBackColor = true;
            this.btnClassicExec.Click += new System.EventHandler(this.btnClassicExec_Click);
            // 
            // btnPerfExec
            // 
            this.btnPerfExec.Enabled = false;
            this.btnPerfExec.Location = new System.Drawing.Point(635, 316);
            this.btnPerfExec.Name = "btnPerfExec";
            this.btnPerfExec.Size = new System.Drawing.Size(75, 23);
            this.btnPerfExec.TabIndex = 4;
            this.btnPerfExec.Text = "Fast";
            this.btnPerfExec.UseVisualStyleBackColor = true;
            this.btnPerfExec.Click += new System.EventHandler(this.btnPerfExec_Click);
            // 
            // frmDistanceCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 351);
            this.Controls.Add(this.btnPerfExec);
            this.Controls.Add(this.btnClassicExec);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.btnFileLoad);
            this.Name = "frmDistanceCalc";
            this.Text = "Distance Calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnFileLoad;
        private RichTextBox rtbOutput;
        private Button btnClassicExec;
        private Button btnPerfExec;
    }
}