using System.Runtime.InteropServices;
using System.Diagnostics;

namespace jmp
{
    public partial class FormJmp : Form
    {
        JmpSaveAndLoad jmpSaveAndLoad;
        FromJmpWrite? fromJmpWrite;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public FormJmp()
        {
            InitializeComponent();
            jmpSaveAndLoad = new JmpSaveAndLoad();
            fromJmpWrite = null;
            KeyPreview = true;
        }

        // Handler Start  --------------------------------------------

        private void FormJmp_Load(object sender, EventArgs e)
        {
            updateList();
            if (listBoxIndex.Items.Count != 0) listBoxIndex.SelectedIndex = 0;
            listBoxIndex.Focus();
        }
        private void listBoxIndex_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string? selected_item = listBoxIndex.SelectedItem?.ToString();
            // null の時
            if (selected_item == null)
            {
                return;
            }
            selectList(selected_item);

        }

        private void listBoxIndex_KeyDown(object sender, KeyEventArgs e)
        {
            string? selected_item = null;
            switch (e.KeyCode)
            {
                // エンターを押したとき
                case Keys.Enter:
                    selected_item = listBoxIndex.SelectedItem?.ToString();
                    // nullの時
                    if (selected_item == null)
                    {
                        return;
                    }
                    selectList(selected_item);
                    break;

                // 登録 w
                case Keys.W:
                    showFromJmpWrite();
                    break;

                // 閉じる x
                case Keys.Escape:
                case Keys.X:
                    this.Close();
                    break;

                // 消去
                case Keys.Delete:
                case Keys.D:
                    selected_item = listBoxIndex.SelectedItem?.ToString();
                    // nullの時
                    if (selected_item == null)
                    {
                        return;
                    }
                    deleteList(selected_item);
                    listBoxIndex.Update();
                    break;

                //全消去
                case Keys.C:
                    allClearList();
                    break;

                case Keys.J:
                    SendKeys.Send("{DOWN}");
                    e.Handled = true;
                    break;
                case Keys.K:
                    SendKeys.Send("{UP}");
                    e.Handled = true;
                    break;

            }
        }

        // Handler End --------------------------------------------------

        public void updateList()
        {
            listBoxIndex.Items.Clear();
            foreach (var message in jmpSaveAndLoad.getMessage())
            {
                listBoxIndex.Items.Add(message);
            }
        }

        private void showFromJmpWrite()
        {
            fromJmpWrite = new FromJmpWrite(this, jmpSaveAndLoad);
            fromJmpWrite.Show();
        }


        private void selectList(string selected_item)
        {
            jmpSaveAndLoad.jmp(selected_item);
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 2500;
            timer.Tick += (sender, e) =>
            {
                SetForegroundWindow(this.Handle);
                timer.Stop();
            };
            

            timer.Start();
            

        }

        private void deleteList(string selectd_item)
        {
            jmpSaveAndLoad.del(selectd_item);
            updateList();
        }

        private void allClearList()
        {
            DialogResult result = MessageBox.Show("全消去します本当に実行しますか？", "確認", MessageBoxButtons.YesNo);

            switch (result)
            {
                case DialogResult.Yes:
                    jmpSaveAndLoad.clear();
                    updateList();
                    break;

                case DialogResult.No:
                    break;
            }

        }

    }
}

