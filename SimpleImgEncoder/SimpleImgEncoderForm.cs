using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleImgEncoder
{
    public partial class SimpleImgEncoderForm : Form
    {
        private IStringConverter stringConverter;
        private IImageConverter _imageConverter;

        public SimpleImgEncoderForm(IStringConverter stringConverter, IImageConverter imageConverter)
        {
            this.stringConverter = stringConverter;
            _imageConverter = imageConverter;
            InitializeComponent();
        }

        private void Encode_Click(object sender, EventArgs e)
        {
            var text = tbText.Text;
            var list = stringConverter.GetInts(text).ToList();
            pbImage.BackgroundImage = _imageConverter.GetImage(list);
        }
    }
}
