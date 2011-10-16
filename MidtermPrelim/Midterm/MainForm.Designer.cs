namespace Midterm
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataFileLabel = new System.Windows.Forms.Label();
            this.chooseDataFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.hiddenNodes = new System.Windows.Forms.TextBox();
            this.learningRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorMargin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maxEpochs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maxInitWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.minInitWeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.trainButton = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data File:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataFileLabel
            // 
            this.dataFileLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataFileLabel.BackColor = System.Drawing.SystemColors.Info;
            this.dataFileLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFileLabel.Location = new System.Drawing.Point(71, 8);
            this.dataFileLabel.Name = "dataFileLabel";
            this.dataFileLabel.Size = new System.Drawing.Size(600, 23);
            this.dataFileLabel.TabIndex = 1;
            this.dataFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chooseDataFile
            // 
            this.chooseDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseDataFile.Location = new System.Drawing.Point(677, 8);
            this.chooseDataFile.Name = "chooseDataFile";
            this.chooseDataFile.Size = new System.Drawing.Size(35, 23);
            this.chooseDataFile.TabIndex = 2;
            this.chooseDataFile.Text = "...";
            this.chooseDataFile.UseVisualStyleBackColor = true;
            this.chooseDataFile.Click += new System.EventHandler(this.chooseDataFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hidden Nodes";
            // 
            // hiddenNodes
            // 
            this.hiddenNodes.Enabled = false;
            this.hiddenNodes.Location = new System.Drawing.Point(106, 40);
            this.hiddenNodes.Name = "hiddenNodes";
            this.hiddenNodes.Size = new System.Drawing.Size(100, 20);
            this.hiddenNodes.TabIndex = 4;
            this.hiddenNodes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // learningRate
            // 
            this.learningRate.Enabled = false;
            this.learningRate.Location = new System.Drawing.Point(106, 66);
            this.learningRate.Name = "learningRate";
            this.learningRate.Size = new System.Drawing.Size(100, 20);
            this.learningRate.TabIndex = 6;
            this.learningRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Learning Rate";
            // 
            // errorMargin
            // 
            this.errorMargin.Enabled = false;
            this.errorMargin.Location = new System.Drawing.Point(106, 92);
            this.errorMargin.Name = "errorMargin";
            this.errorMargin.Size = new System.Drawing.Size(100, 20);
            this.errorMargin.TabIndex = 8;
            this.errorMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Error Margin";
            // 
            // maxEpochs
            // 
            this.maxEpochs.Enabled = false;
            this.maxEpochs.Location = new System.Drawing.Point(106, 118);
            this.maxEpochs.Name = "maxEpochs";
            this.maxEpochs.Size = new System.Drawing.Size(100, 20);
            this.maxEpochs.TabIndex = 10;
            this.maxEpochs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Max Epochs";
            // 
            // maxInitWeight
            // 
            this.maxInitWeight.Enabled = false;
            this.maxInitWeight.Location = new System.Drawing.Point(106, 144);
            this.maxInitWeight.Name = "maxInitWeight";
            this.maxInitWeight.Size = new System.Drawing.Size(100, 20);
            this.maxInitWeight.TabIndex = 12;
            this.maxInitWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Max Initial Weight";
            // 
            // minInitWeight
            // 
            this.minInitWeight.Enabled = false;
            this.minInitWeight.Location = new System.Drawing.Point(106, 170);
            this.minInitWeight.Name = "minInitWeight";
            this.minInitWeight.Size = new System.Drawing.Size(100, 20);
            this.minInitWeight.TabIndex = 14;
            this.minInitWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Min Initial Weight";
            // 
            // trainButton
            // 
            this.trainButton.Enabled = false;
            this.trainButton.Location = new System.Drawing.Point(254, 169);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(75, 23);
            this.trainButton.TabIndex = 15;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(15, 211);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(699, 365);
            this.output.TabIndex = 16;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 588);
            this.Controls.Add(this.output);
            this.Controls.Add(this.trainButton);
            this.Controls.Add(this.minInitWeight);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maxInitWeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maxEpochs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.errorMargin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.learningRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hiddenNodes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseDataFile);
            this.Controls.Add(this.dataFileLabel);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Rick Haffey\'s Midterm - FeedForward ANN using Backpropagation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dataFileLabel;
        private System.Windows.Forms.Button chooseDataFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hiddenNodes;
        private System.Windows.Forms.TextBox learningRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox errorMargin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maxEpochs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maxInitWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox minInitWeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

