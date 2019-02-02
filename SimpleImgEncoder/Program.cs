using System;
using System.Windows.Forms;

namespace SimpleImgEncoder
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var strConverter = new StringConverter();
            var imgConverter = new ImageConverter();
            var form = new SimpleImgEncoderForm(strConverter, imgConverter);
            Application.Run(form);
        }
    }
}