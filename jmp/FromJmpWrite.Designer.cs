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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // TextBox_Message
            // 
            TextBox_Message.Cursor = Cursors.IBeam;
            TextBox_Message.Location = new Point(85, 9);
            TextBox_Message.Name = "TextBox_Message";
            TextBox_Message.Size = new Size(1051, 27);
            TextBox_Message.TabIndex = 0;
            TextBox_Message.KeyPress += TextBox_Message_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Location = new Point(85, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1051, 27);
            textBox1.TabIndex = 1;
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
            // button1
            // 
            button1.BackColor = Color.PowderBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1142, 9);
            button1.Name = "button1";
            button1.Size = new Size(61, 60);
            button1.TabIndex = 4;
            button1.Text = "SAVE";
            button1.UseVisualStyleBackColor = false;
            // 
            // FromJmpWrite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1211, 79);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(TextBox_Message);
            Name = "FromJmpWrite";
            Text = "Message";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBox_Message;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}