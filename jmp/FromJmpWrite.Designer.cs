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
            SuspendLayout();
            // 
            // TextBox_Message
            // 
            TextBox_Message.Dock = DockStyle.Fill;
            TextBox_Message.Location = new Point(0, 0);
            TextBox_Message.Name = "TextBox_Message";
            TextBox_Message.Size = new Size(1051, 27);
            TextBox_Message.TabIndex = 0;
            TextBox_Message.KeyPress += TextBox_Message_KeyPress;
            // 
            // FromJmpWrite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 27);
            Controls.Add(TextBox_Message);
            Name = "FromJmpWrite";
            Text = "Message";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBox_Message;
    }
}