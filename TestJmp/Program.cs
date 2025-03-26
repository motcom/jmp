using jmp;

class Program
{
    static void Main(string[] args)
    {
        var tmp_jmp = new jmp.JmpSaveAndLoad();

        tmp_jmp.add("nsk", "\\\\3D_EX88\\Ex_3DWork\\NSK");
        tmp_jmp.add("honda", "\\\\3D_DELL48\\3DWork_H01");
        tmp_jmp.add("nwgn", "\\\\3D_DELL48\\3DWork_H01\\NWGN");
        foreach(var a in tmp_jmp.getMessage())
        {
            Console.WriteLine(a);
        }
        tmp_jmp.jmp("honda");

    }
}