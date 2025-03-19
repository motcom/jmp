using jmp;

class Program
{
    static void Main(string[] args)
    {
        var tmp_jmp = new jmp.JmpSaveAndLoad();

        tmp_jmp.add("nsk", "\\\\3D_EX88\\Ex_3DWork\\NSK");
        tmp_jmp.jmp("nsk");

    }
}