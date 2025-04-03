using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Diagnostics;

namespace jmp
{
    public class JmpSaveAndLoad
    {
        
        private string jmp_data_path;
        private Dictionary<string, JmpDstData> message_path_dict;
        private SortedList<DateTime, string> time_stamp_list;
        private Comparer<DateTime> date_reverse_compare = Comparer<DateTime>.Create((x, y) => y.CompareTo(x)); // 降順ソート用

        // コンストラクタ
        public JmpSaveAndLoad()
        {
            jmp_data_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "jmp", "config.json");
            message_path_dict = load_json();
            time_stamp_list = new SortedList<DateTime, string>(date_reverse_compare);

        }
        // -------------------------------------------------- private util --------------------------------------------------


        // util: データファイルがない場合、空のデータファイルを作成
        private void first_file_access()
        {
            string path = jmp_data_path;
            // パスが存在しない場合はパスを追加
            if (!File.Exists(path))
            {
                string? dir_name = Path.GetDirectoryName(path);
                // ディレクトリ名取得失敗
                if (dir_name == null) 
                { 
                    MessageBox.Show("ジャンプリストファイルのディレクトリ名を取得できません");
                    Environment.Exit(1); 
                }
                try
                {
                    Directory.CreateDirectory(dir_name);
                }catch(Exception ex)
                {
                    MessageBox.Show("ジャンプリストのファイルディレクトリ作成失敗:{0}",ex.Message);
                    Environment.Exit(1);
                }
                
                File.WriteAllText(path, "{}");
            }
        }

        // util: jsonデータをロードしてデシリアライズ
        private Dictionary<string,JmpDstData> load_json()
        {
            first_file_access();

            var all_tex = File.ReadAllText(jmp_data_path);

            var result_data =  JsonSerializer.Deserialize<Dictionary<string, JmpDstData>>(all_tex)
                ?? new Dictionary<string, JmpDstData>();

            return result_data;
        }

        // util: jsonデータを追記セーブ
        private void save_json(string message,string path)
        {
            message_path_dict = load_json();
            message_path_dict[message] = new JmpDstData(path,Color.White,false,DateTime.Now);
            var message_path_json = JsonSerializer.Serialize<Dictionary<string, JmpDstData>>(message_path_dict);
            File.WriteAllText(jmp_data_path, message_path_json);
        }

        // --------------------------------------- public function ------------------------------------------------------

        /// <summary>
        /// ｔｉｍｅスタンプを更新する
        /// </summary>
        /// <param name="message"></param>
        public void changeTimeStamp(string message)
        {
            message_path_dict = load_json();
            message_path_dict[message].changeTimeStamp();
            var message_path_json = JsonSerializer.Serialize<Dictionary<string, JmpDstData>>(message_path_dict);
            File.WriteAllText(jmp_data_path, message_path_json);
        }

        /// <summary>
        /// メッセージに対応する文字の太さを設定する
        /// </summary>
        /// <param name="message"></param>
        /// <param name="bold_flag"></param>
        public void setBold(string message, bool bold_flag)
        {
            message_path_dict[message].bold_flag = bold_flag;
            var message_path_json = JsonSerializer.Serialize<Dictionary<string, JmpDstData>>(message_path_dict);
            File.WriteAllText(jmp_data_path, message_path_json);
        }

        /// <summary>
        /// メッセージに対応する文字の太さを返す
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool getBold(string? message)
        {
            if (message == null) return false;
            return message_path_dict[message].bold_flag ?? false;
        }

        /// <summary>
        /// メッセージに対応する色を設定する
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public void setColor(string message,Color color)
        {
            message_path_dict[message].setColor(color);
            var message_path_json = JsonSerializer.Serialize<Dictionary<string, JmpDstData>>(message_path_dict);
            File.WriteAllText(jmp_data_path, message_path_json);
        }

        /// <summary>
        /// メッセージに対応する色を返す
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Color getColor(string message)
        {
            return message_path_dict[message].getColor();
        }



        /// <summary>
        /// ジャンプリストに追加する
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path"></param>
        public void add(string message,string path)
        {
            // 作成するデータのディレクトリが無い場合
            if (!Directory.Exists(path)){
                MessageBox.Show("ディレクトリは存在しません:{0}", path);
                Environment.Exit(1);
            }
            save_json(message, path);
            
        }

        /// <summary>
        /// メッセージリストを返す
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> getMessage()
        {
            time_stamp_list.Clear();

            foreach (var k in this.message_path_dict.Keys)
            {
                var tmp_stamp = message_path_dict[k].time_stamp ?? DateTime.Now;

                time_stamp_list.Add(tmp_stamp, k);
            }

            foreach (var k in time_stamp_list)
            {
                yield return k.Value;
            }
        }

        /// <summary>
        /// メッセージを渡しパスへジャンプ
        /// </summary>
        /// <param name="message"></param>
        public void jmp(string message)
        {
            string? jmp_path = message_path_dict[message].path_string;
            if (jmp_path == null)
            {
                MessageBox.Show("ジャンプ先のパスがありません");
                return;
            }
            Process.Start("explorer", jmp_path);
        }

        /// <summary>
        /// メッセージで辞書を消す
        /// </summary>
        /// <param name="message"></param>
        public void del(string message)
        {
            message_path_dict = load_json();
            message_path_dict.Remove(message);
            var message_path_json = JsonSerializer.Serialize<Dictionary<string, JmpDstData>>(message_path_dict);
            File.WriteAllText(jmp_data_path, message_path_json);
        }

        /// <summary>
        /// データをすべて消去
        /// </summary>
        public void clear()
        {
            message_path_dict = new Dictionary<string, JmpDstData>();
            string path = jmp_data_path;
            File.WriteAllText(path, "{}");
        }
    }
}
