using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

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
            listBoxIndex.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxIndex.DrawItem += new DrawItemEventHandler(listBoxIndex_DrawItem);
            if (listBoxIndex.Items.Count != 0) listBoxIndex.SelectedIndex = 0;
            listBoxIndex.Focus();
        }

        // リストボックスのItemを描画する
        private void listBoxIndex_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // 背景を描画
            e.DrawBackground();
            // 文字列を描画
            string? text = listBoxIndex.Items[e.Index].ToString();

            // 色の初期化
            Brush brush;
            if (text == null)
            { 
                brush = Brushes.White; 
            }
            else
            {
               brush =  new SolidBrush(jmpSaveAndLoad.getColor(text)); 
            }

            //　文字の太さを反映

            if (jmpSaveAndLoad.getBold(text))
            {
                Font font = new Font(e.Font!, FontStyle.Bold);
                e.Graphics.DrawString(text, font, brush, e.Bounds, StringFormat.GenericDefault);
            }
            else
            {
                e.Graphics.DrawString(text, e.Font!, brush, e.Bounds, StringFormat.GenericDefault);
            }


                //  フォーカスを示す四角形を描画
                e.DrawFocusRectangle();
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
                    updateList();
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

                //カラーの変更
                case Keys.C:
                    using(ColorDialog colorDialog = new ColorDialog())
                    {
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            string? message = listBoxIndex.SelectedItem?.ToString();
                            if(message == null)
                            {
                                MessageBox.Show("リストが選択されていません");
                                return;
                            }else
                            {
                                jmpSaveAndLoad.setColor(message, colorDialog.Color);
                            }
                        }
                    }
                    break;

                // 文字列の太さの変更
                 case Keys.B:
                    string? message_for_bold = listBoxIndex.SelectedItem?.ToString();
                    if (message_for_bold == null)
                    {
                        MessageBox.Show("リストが選択されていません");
                        return;
                    }

                    if(jmpSaveAndLoad.getBold(message_for_bold))
                    {
                        jmpSaveAndLoad.setBold(message_for_bold, false);
                    }
                    else
                    {
                        jmpSaveAndLoad.setBold(message_for_bold, true);
                    }
                    
                    break;

                //全消去
                case Keys.A:
                    allClearList();
                    break;

                // 下へ
                case Keys.J:
                    SendKeys.Send("{DOWN}");
                    e.Handled = true;
                    break;
                // 上へ
                case Keys.K:
                    SendKeys.Send("{UP}");
                    e.Handled = true;
                    break;

                // 透明度設定
                case Keys.D1:
                    changeOpacity(0.1f);
                    break;
                case Keys.D2:
                    changeOpacity(0.2f);
                    break;
                case Keys.D3:
                    changeOpacity(0.3f);
                    break;
                case Keys.D4:
                    changeOpacity(0.4f);
                    break;
                case Keys.D5:
                    changeOpacity(0.5f);
                    break;
                case Keys.D6:
                    changeOpacity(0.6f);
                    break;
                case Keys.D7:
                    changeOpacity(0.7f);
                    break;
                case Keys.D8:
                    changeOpacity(0.8f);
                    break;
                case Keys.D9:
                    changeOpacity(0.9f);
                    break;
                case Keys.D0:
                    changeOpacity(1.0f);
                    break;

                case Keys.Tab:
                    toggleTop(); 
                    break;

                case Keys.T:
                    // time stampの更新
                    onTimeStampChange();
                    break;

            }
        }

        private void onTimeStampChange()
        {
            string? tmp_str = listBoxIndex.SelectedItem?.ToString();
            if (tmp_str == null)
            {
                MessageBox.Show("リストが選択されていません");
                return;
            }
            jmpSaveAndLoad.changeTimeStamp(tmp_str);
            updateList();
        }

        // Handler End --------------------------------------------------

        private void toggleTop()
        {
            bool flag = this.TopMost;
            if (flag)
            {
                this.TopMost = false;
            }
            else
            {
                this.TopMost = true;
            }
        }


        private void changeOpacity(float opacity)
        {
            this.Opacity = opacity;
            this.Update();
        }

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

