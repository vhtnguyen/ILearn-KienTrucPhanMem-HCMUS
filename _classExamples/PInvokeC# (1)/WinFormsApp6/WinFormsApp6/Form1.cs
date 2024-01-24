using System.Runtime.InteropServices;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", 
            SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern 
            bool SetWindowText(int hWnd, string lpString);


        [DllImport("user32.dll", SetLastError = true)]
        static extern int FindWindow
            (IntPtr lpClassName, string lpWindowName);

        private void button1_Click(object sender, EventArgs e)
        {
            
            String s = textBox1.Text;
            int hWnd = FindWindow(IntPtr.Zero, s);
            SetWindowText(hWnd, textBox2.Text);
            MessageBox.Show(hWnd.ToString());

        }
    }
}