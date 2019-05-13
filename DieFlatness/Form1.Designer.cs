namespace DieFlatness
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbClient = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.MainDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.LiveDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.btn3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiveDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn3);
            this.splitContainer1.Panel1.Controls.Add(this.cbClient);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(983, 554);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbClient
            // 
            this.cbClient.AutoSize = true;
            this.cbClient.Location = new System.Drawing.Point(893, 12);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(78, 16);
            this.cbClient.TabIndex = 1;
            this.cbClient.Text = "checkBox1";
            this.cbClient.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "初始化";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.MainDisplay);
            this.splitContainer2.Panel1.Controls.Add(this.LiveDisplay);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(983, 415);
            this.splitContainer2.SplitterDistance = 750;
            this.splitContainer2.TabIndex = 0;
            // 
            // MainDisplay
            // 
            this.MainDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MainDisplay.ColorMapLowerRoiLimit = 0D;
            this.MainDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MainDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MainDisplay.ColorMapUpperRoiLimit = 1D;
            this.MainDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDisplay.DoubleTapZoomCycleLength = 2;
            this.MainDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.MainDisplay.Location = new System.Drawing.Point(0, 0);
            this.MainDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MainDisplay.MouseWheelSensitivity = 1D;
            this.MainDisplay.Name = "MainDisplay";
            this.MainDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MainDisplay.OcxState")));
            this.MainDisplay.Size = new System.Drawing.Size(750, 415);
            this.MainDisplay.TabIndex = 3;
            // 
            // LiveDisplay
            // 
            this.LiveDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.LiveDisplay.ColorMapLowerRoiLimit = 0D;
            this.LiveDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.LiveDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.LiveDisplay.ColorMapUpperRoiLimit = 1D;
            this.LiveDisplay.DoubleTapZoomCycleLength = 2;
            this.LiveDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.LiveDisplay.Location = new System.Drawing.Point(0, 0);
            this.LiveDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LiveDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.LiveDisplay.MouseWheelSensitivity = 1D;
            this.LiveDisplay.Name = "LiveDisplay";
            this.LiveDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("LiveDisplay.OcxState")));
            this.LiveDisplay.Size = new System.Drawing.Size(214, 287);
            this.LiveDisplay.TabIndex = 4;
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(149, 34);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 56);
            this.btn3.TabIndex = 2;
            this.btn3.Text = "开始采集";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 56);
            this.button2.TabIndex = 0;
            this.button2.Text = "配置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片宽";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(70, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 554);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LiveDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Cognex.VisionPro.CogRecordDisplay MainDisplay;
        private Cognex.VisionPro.CogRecordDisplay LiveDisplay;
        private System.Windows.Forms.CheckBox cbClient;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

