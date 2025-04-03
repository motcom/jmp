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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJmp));
            listBoxIndex = new ListBox();
            SuspendLayout();
            // 
            // listBoxIndex
            // 
            listBoxIndex.BackColor = Color.SlateGray;
            listBoxIndex.BorderStyle = BorderStyle.None;
            listBoxIndex.Cursor = Cursors.Hand;
            listBoxIndex.Dock = DockStyle.Fill;
            listBoxIndex.ForeColor = Color.SeaShell;
            listBoxIndex.FormattingEnabled = true;
            listBoxIndex.Location = new Point(0, 0);
            listBoxIndex.Name = "listBoxIndex";
            listBoxIndex.Size = new Size(759, 688);
            listBoxIndex.TabIndex = 0;
            listBoxIndex.KeyDown += listBoxIndex_KeyDown;
            listBoxIndex.KeyPress += listBoxIndex_KeyPress;
            listBoxIndex.MouseDoubleClick += listBoxIndex_MouseDoubleClick;
            // 
            // FormJmp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 688);
            Controls.Add(listBoxIndex);
            ForeColor = SystemColors.ButtonHighlight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormJmp";
            Text = "jmp";
            Load += FormJmp_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxIndex;
    }
}
