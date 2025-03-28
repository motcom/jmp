namespace jmp
{
    partial class FromJmpWrite
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
            TextBox_Message = new TextBox();
            textBox_path = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // TextBox_Message
            // 
            TextBox_Message.Cursor = Cursors.IBeam;
            TextBox_Message.Location = new Point(85, 9);
            TextBox_Message.Name = "TextBox_Message";
            TextBox_Message.Size = new Size(1051, 27);
            TextBox_Message.TabIndex = 0;
            TextBox_Message.KeyDown += TextBox_Message_KeyDown;
            // 
            // textBox_path
            // 
            textBox_path.Cursor = Cursors.IBeam;
            textBox_path.Location = new Point(85, 42);
            textBox_path.Name = "textBox_path";
            textBox_path.Size = new Size(1051, 27);
            textBox_path.TabIndex = 1;
            textBox_path.KeyDown += textBox_path_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.SlateGray;
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 2;
            label1.Text = "Message";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.SlateGray;
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 3;
            label2.Text = "Path";
            // 
            // FromJmpWrite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1147, 79);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_path);
            Controls.Add(TextBox_Message);
            Name = "FromJmpWrite";
            Text = "Message";
            KeyDown += FromJmpWrite_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBox_Message;
        private TextBox textBox_path;
        private Label label1;
        private Label label2;
    }
}