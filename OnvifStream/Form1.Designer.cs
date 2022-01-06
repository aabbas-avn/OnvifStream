
namespace OnvifStream
{
    partial class Form1
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Reset = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.Right = new System.Windows.Forms.Button();
            this.Zoom_Out = new System.Windows.Forms.Button();
            this.Zoom_In = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Stream_Player = new WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1079, 616);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.Zoom_In, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Zoom_Out, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Right, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Down, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Left, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Up, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Reset, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 209);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 3);
            this.textBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(10, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 31);
            this.textBox1.TabIndex = 9;
            // 
            // Reset
            // 
            this.Reset.BackColor = System.Drawing.Color.SteelBlue;
            this.Reset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset.ForeColor = System.Drawing.Color.Lavender;
            this.Reset.Location = new System.Drawing.Point(89, 85);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(80, 35);
            this.Reset.TabIndex = 7;
            this.Reset.Text = "RESET";
            this.Reset.UseVisualStyleBackColor = false;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Up
            // 
            this.Up.BackColor = System.Drawing.Color.LightBlue;
            this.Up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Up.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Up.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Up.Location = new System.Drawing.Point(89, 44);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(80, 35);
            this.Up.TabIndex = 0;
            this.Up.Text = "UP";
            this.Up.UseVisualStyleBackColor = false;
            this.Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Up_MouseDown);
            this.Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Up_MouseUp);
            // 
            // Left
            // 
            this.Left.BackColor = System.Drawing.Color.LightBlue;
            this.Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Left.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Left.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Left.Location = new System.Drawing.Point(3, 85);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(80, 35);
            this.Left.TabIndex = 1;
            this.Left.Text = "LEFT";
            this.Left.UseVisualStyleBackColor = false;
            this.Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Left_MouseDown);
            this.Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Left_MouseUp);
            // 
            // Down
            // 
            this.Down.BackColor = System.Drawing.Color.LightBlue;
            this.Down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Down.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Down.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Down.Location = new System.Drawing.Point(89, 126);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(80, 35);
            this.Down.TabIndex = 2;
            this.Down.Text = "DOWN";
            this.Down.UseVisualStyleBackColor = false;
            this.Down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Down_MouseDown);
            this.Down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Down_MouseUp);
            // 
            // Right
            // 
            this.Right.BackColor = System.Drawing.Color.LightBlue;
            this.Right.Cursor = System.Windows.Forms.Cursors.Default;
            this.Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Right.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Right.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Right.Location = new System.Drawing.Point(175, 85);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(81, 35);
            this.Right.TabIndex = 3;
            this.Right.Text = "RIGHT";
            this.Right.UseVisualStyleBackColor = false;
            this.Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Right_MouseDown);
            this.Right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Right_MouseUp);
            // 
            // Zoom_Out
            // 
            this.Zoom_Out.BackColor = System.Drawing.Color.LightBlue;
            this.Zoom_Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Zoom_Out.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Zoom_Out.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zoom_Out.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Zoom_Out.Location = new System.Drawing.Point(175, 167);
            this.Zoom_Out.Name = "Zoom_Out";
            this.Zoom_Out.Size = new System.Drawing.Size(81, 39);
            this.Zoom_Out.TabIndex = 4;
            this.Zoom_Out.Text = "ZOOM OUT";
            this.Zoom_Out.UseVisualStyleBackColor = false;
            this.Zoom_Out.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zoom_Out_MouseDown);
            this.Zoom_Out.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Zoom_Out_MouseUp);
            // 
            // Zoom_In
            // 
            this.Zoom_In.BackColor = System.Drawing.Color.LightBlue;
            this.Zoom_In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Zoom_In.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Zoom_In.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zoom_In.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Zoom_In.Location = new System.Drawing.Point(3, 167);
            this.Zoom_In.Name = "Zoom_In";
            this.Zoom_In.Size = new System.Drawing.Size(80, 39);
            this.Zoom_In.TabIndex = 6;
            this.Zoom_In.Text = "ZOOM IN";
            this.Zoom_In.UseVisualStyleBackColor = false;
            this.Zoom_In.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Zoom_In_MouseDown);
            this.Zoom_In.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Zoom_In_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(810, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 235);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PTZ Control";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Stream_Player);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 616);
            this.panel1.TabIndex = 0;
            // 
            // Stream_Player
            // 
            this.Stream_Player.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Stream_Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Stream_Player.Location = new System.Drawing.Point(0, 0);
            this.Stream_Player.Name = "Stream_Player";
            this.Stream_Player.Size = new System.Drawing.Size(807, 616);
            this.Stream_Player.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1079, 616);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(1095, 655);
            this.MinimumSize = new System.Drawing.Size(1095, 655);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Onvif Streaming With Digest";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl Stream_Player;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Zoom_In;
        private System.Windows.Forms.Button Zoom_Out;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.TextBox textBox1;
    }
}

