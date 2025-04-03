using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace jmp
{
    class JmpDstData
    {
        public string?   path_string { set; get; }
        public DateTime? time_stamp  { set; get; }
        public int? r { set; get; }
        public int? g { set; get; }
        public int? b { set; get; }
        public bool? bold_flag { set; get; } // 太字フラグ

        public JmpDstData() { } // デシリアライズ用

        // コンストラクタ
        public JmpDstData(string path_string,Color brush_color,bool bold_flag,DateTime time_stamp) {
            this.path_string = path_string;
            this.r = brush_color.R;
            this.g = brush_color.G;
            this.b = brush_color.B;
            this.time_stamp = time_stamp; // 現在時刻を設定 
            
        }

        public void setColor(Color brush_color)
        {
            this.r = brush_color.R;
            this.g = brush_color.G;
            this.b = brush_color.B;
        }
        public Color getColor()
        {
            return Color.FromArgb(this.r ?? 255, this.g ?? 255, this.b ?? 255);
        }

        public void changeTimeStamp()
        {
            this.time_stamp = DateTime.Now;
        }

    }
}
