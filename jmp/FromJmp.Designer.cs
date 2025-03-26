namespace jmp
{
    partial class FormJmp
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
            listBoxIndex = new ListBox();
            SuspendLayout();
            // 
            // listBoxIndex
            // 
            listBoxIndex.BackColor = Color.SlateGray;
            listBoxIndex.BorderStyle = BorderStyle.None;
            listBoxIndex.Cursor = Cursors.IBeam;
            listBoxIndex.Dock = DockStyle.Fill;
            listBoxIndex.ForeColor = Color.SeaShell;
            listBoxIndex.FormattingEnabled = true;
            listBoxIndex.Location = new Point(0, 0);
            listBoxIndex.Name = "listBoxIndex";
            listBoxIndex.Size = new Size(759, 688);
            listBoxIndex.TabIndex = 0;
            // 
            // FormJmp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 688);
            Controls.Add(listBoxIndex);
            ForeColor = SystemColors.ButtonHighlight;
            Name = "FormJmp";
            Text = "jmp";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxIndex;
    }
}
