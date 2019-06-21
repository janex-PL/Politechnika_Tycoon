namespace JanKliszczZadDom1
{
    partial class FormGameEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameEvent));
            this.labelEventTitle = new System.Windows.Forms.Label();
            this.labelEventContent = new System.Windows.Forms.Label();
            this.buttonEventResponse1 = new System.Windows.Forms.Button();
            this.buttonEventResponse2 = new System.Windows.Forms.Button();
            this.buttonEventResponse3 = new System.Windows.Forms.Button();
            this.labelEventResultA = new System.Windows.Forms.Label();
            this.labelEventResultB = new System.Windows.Forms.Label();
            this.labelEventResultC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelEventTitle
            // 
            this.labelEventTitle.AutoSize = true;
            this.labelEventTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEventTitle.Location = new System.Drawing.Point(12, 9);
            this.labelEventTitle.Name = "labelEventTitle";
            this.labelEventTitle.Size = new System.Drawing.Size(66, 31);
            this.labelEventTitle.TabIndex = 0;
            this.labelEventTitle.Text = "Title";
            // 
            // labelEventContent
            // 
            this.labelEventContent.AutoSize = true;
            this.labelEventContent.Location = new System.Drawing.Point(15, 63);
            this.labelEventContent.Name = "labelEventContent";
            this.labelEventContent.Size = new System.Drawing.Size(44, 13);
            this.labelEventContent.TabIndex = 1;
            this.labelEventContent.Text = "Content";
            // 
            // buttonEventResponse1
            // 
            this.buttonEventResponse1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEventResponse1.Location = new System.Drawing.Point(18, 193);
            this.buttonEventResponse1.Name = "buttonEventResponse1";
            this.buttonEventResponse1.Size = new System.Drawing.Size(143, 49);
            this.buttonEventResponse1.TabIndex = 2;
            this.buttonEventResponse1.Text = "answer";
            this.buttonEventResponse1.UseVisualStyleBackColor = true;
            this.buttonEventResponse1.Click += new System.EventHandler(this.buttonEventResponse_Click);
            // 
            // buttonEventResponse2
            // 
            this.buttonEventResponse2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEventResponse2.Location = new System.Drawing.Point(18, 248);
            this.buttonEventResponse2.Name = "buttonEventResponse2";
            this.buttonEventResponse2.Size = new System.Drawing.Size(143, 49);
            this.buttonEventResponse2.TabIndex = 3;
            this.buttonEventResponse2.Text = "answer";
            this.buttonEventResponse2.UseVisualStyleBackColor = true;
            this.buttonEventResponse2.Click += new System.EventHandler(this.buttonEventResponse_Click);
            // 
            // buttonEventResponse3
            // 
            this.buttonEventResponse3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEventResponse3.Location = new System.Drawing.Point(18, 303);
            this.buttonEventResponse3.Name = "buttonEventResponse3";
            this.buttonEventResponse3.Size = new System.Drawing.Size(143, 49);
            this.buttonEventResponse3.TabIndex = 4;
            this.buttonEventResponse3.Text = "answer";
            this.buttonEventResponse3.UseVisualStyleBackColor = true;
            this.buttonEventResponse3.Click += new System.EventHandler(this.buttonEventResponse_Click);
            // 
            // labelEventResultA
            // 
            this.labelEventResultA.AutoSize = true;
            this.labelEventResultA.Location = new System.Drawing.Point(167, 211);
            this.labelEventResultA.Name = "labelEventResultA";
            this.labelEventResultA.Size = new System.Drawing.Size(35, 13);
            this.labelEventResultA.TabIndex = 5;
            this.labelEventResultA.Text = "label1";
            // 
            // labelEventResultB
            // 
            this.labelEventResultB.AutoSize = true;
            this.labelEventResultB.Location = new System.Drawing.Point(167, 266);
            this.labelEventResultB.Name = "labelEventResultB";
            this.labelEventResultB.Size = new System.Drawing.Size(35, 13);
            this.labelEventResultB.TabIndex = 6;
            this.labelEventResultB.Text = "label2";
            // 
            // labelEventResultC
            // 
            this.labelEventResultC.AutoSize = true;
            this.labelEventResultC.Location = new System.Drawing.Point(167, 321);
            this.labelEventResultC.Name = "labelEventResultC";
            this.labelEventResultC.Size = new System.Drawing.Size(35, 13);
            this.labelEventResultC.TabIndex = 7;
            this.labelEventResultC.Text = "label3";
            // 
            // FormGameEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.labelEventResultC);
            this.Controls.Add(this.labelEventResultB);
            this.Controls.Add(this.labelEventResultA);
            this.Controls.Add(this.buttonEventResponse3);
            this.Controls.Add(this.buttonEventResponse2);
            this.Controls.Add(this.buttonEventResponse1);
            this.Controls.Add(this.labelEventContent);
            this.Controls.Add(this.labelEventTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGameEvent";
            this.Text = "Nowe wydarzenie!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEventTitle;
        private System.Windows.Forms.Label labelEventContent;
        private System.Windows.Forms.Button buttonEventResponse1;
        private System.Windows.Forms.Button buttonEventResponse2;
        private System.Windows.Forms.Button buttonEventResponse3;
        private System.Windows.Forms.Label labelEventResultA;
        private System.Windows.Forms.Label labelEventResultB;
        private System.Windows.Forms.Label labelEventResultC;
    }
}