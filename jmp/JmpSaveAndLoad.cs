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
        private Dictionary<string, string> message_path_dict;

        // コンストラクタ
        public JmpSaveAndLoad()
        {
            jmp_data_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "jmp", "config.json");
            message_path_dict = load_json();
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
        private Dictionary<string,string> load_json()
        {
            first_file_access();
            var all_tex = File.ReadAllText(jmp_data_path);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(all_tex)
                ?? new Dictionary<string, string>();
        }

        // util: jsonデータを追記セーブ
        private void save_json(string message,string path)
        {
            message_path_dict = load_json();
            message_path_dict[message] = path;
            var message_path_json = JsonSerializer.Serialize<Dictionary<string, string>>(message_path_dict);
            File.WriteAllText(jmp_data_path, message_path_json);
        }

        // --------------------------------------- public function ------------------------------------------------------

        

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
            return this.message_path_dict.Keys;
        }

        /// <summary>
        /// メッセージを渡しパスへジャンプ
        /// </summary>
        /// <param name="message"></param>
        public void jmp(string message)
        {
            string jmp_path = message_path_dict[message];
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
            var message_path_json = JsonSerializer.Serialize<Dictionary<string, string>>(message_path_dict);
            File.WriteAllText(jmp_data_path, message_path_json);
        }

        /// <summary>
        /// データをすべて消去
        /// </summary>
        public void clear()
        {
            message_path_dict = new Dictionary<string, string>();
            string path = jmp_data_path;
            File.WriteAllText(path, "{}");
        }
    }
}
