using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jmp
{
    public partial class FromJmpWrite : Form
    {
        private FormJmp formJmp;
        private JmpSaveAndLoad jmpSaveAndLoad;


        // コンストラクタ
        public FromJmpWrite(FormJmp formJmp, JmpSaveAndLoad jmpSaveAndLoad)
        {
            if (formJmp == null) throw new ArgumentNullException(nameof(formJmp));
            if (jmpSaveAndLoad == null) throw new ArgumentNullException(nameof(jmpSaveAndLoad));

            InitializeComponent();

            this.jmpSaveAndLoad = jmpSaveAndLoad;
            this.formJmp = formJmp;
            this.TextBox_Message.Focus();
        }


        // イベントハンドラ start ------------------------------------------------------------
        private void FromJmpWrite_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                case Keys.X:
                    close_form();
                    break;

                case Keys.Enter:
                    save();
                    break;
            }
        }

        private void TextBox_Message_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    save();
                    break;
            }

        }


        private void textBox_path_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    save();
                    break;
            }
        }

        // イベントハンドラ end ------------------------------------------------------------

        private void save()
        {
            var message = TextBox_Message.Text;
            var path = textBox_path.Text;
            // ディレクトリが存在しない場合
            if (!Directory.Exists(path))
            {
                MessageBox.Show("ディレクトリが存在しません");
                return;
            }

            jmpSaveAndLoad.add(message, path);
            close_form();

        }

        private void close_form()
        {
            formJmp.Focus();
            formJmp.updateList();
            this.Close();
        }

    }
}
